using System.Collections.Generic;
using System.IO;
using System;
using UnityEngine;

public class SaveData : IDisposable
{
    private CoinModifierFactory _factory;

    public int coinCoint { get; private set; }
    public CoinModifier[] coinModifiers { get; private set; }
    public CoinModifier[] shopModifiers { get; private set; }

    public SaveData(CoinModifierFactory factory)
    {
        _factory = factory;
    }

    public SaveData(int coinCoint, List<CoinModifier> coinModifiers, List<CoinModifier> shopModifiers)
    {
        this.coinCoint = coinCoint;
        this.coinModifiers = coinModifiers.ToArray();
        this.shopModifiers = shopModifiers.ToArray();
    }

    public void Write(string saveName)
    {
        var path = Saver.GetFullPath(saveName);
        using (MemoryStream stream = new MemoryStream())
        {
            stream.WriteInt(coinCoint);
            stream.WriteArray(coinModifiers, (x, y) => x.WriteInt(y.modifierID));
            stream.WriteArray(shopModifiers, (x, y) => x.WriteInt(y.modifierID));
            File.WriteAllBytes(path, stream.ToArray());
        }
    }

    public bool Read(string saveName)
    {
        var path = Saver.GetFullPath(saveName);
        if (!File.Exists(path)) return false;
        using (Stream stream = File.OpenRead(path))
        {
            coinCoint = stream.ReadInt();
            coinModifiers = stream.ReadArray((x) => _factory.GetCoinModifier(x.ReadInt()));
            shopModifiers = stream.ReadArray((x) => _factory.GetCoinModifier(x.ReadInt()));
            return true;
        }
    }

    public void Dispose()
    {
        _factory = null;
        coinModifiers = null;
        shopModifiers = null;
    }
}
