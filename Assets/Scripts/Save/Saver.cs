using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;
using Zenject;

public class Saver : MonoBehaviour
{
    private static string savePath => Application.persistentDataPath + "/Saves";
    public static string GetFullPath(string saveName) => $"{savePath}/{saveName}.cabt";

    [SerializeField] private CoinModifierFactory _factory;

    private Clicker _clicker;
    private Shop _shop;

    private static string saveName = "first";

    [Inject]
    private void Construct(Clicker clicker, Shop shop)
    {
        _clicker = clicker;
        _shop = shop;
        Application.quitting += OnApplicationQuitting;
        _clicker.CoinCountChanged += OnClickerCointCountChanged;
        CreateDirectory();
        Load("first");
    }

    private void OnClickerCointCountChanged()
    {
        if (_clicker.currentCoinCount > 3333)
        {
            RemoveSave();
            Application.quitting -= OnApplicationQuitting;
        }
    }

    private void CreateDirectory()
    {
        if (!Directory.Exists(savePath))
        {
            Directory.CreateDirectory(savePath);
        }
    }

    private void OnApplicationQuitting()
    {
        Save("first");
        Application.quitting -= OnApplicationQuitting;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.X)) Save(saveName);
        if (Input.GetKeyDown(KeyCode.Y)) Load(saveName);
    }

    private void RemoveSave()
    {
        var path = GetFullPath(saveName);
        File.Delete(path);
    }

    private void Load(string saveName)
    {
        using (SaveData saveData = new SaveData(_factory))
        {
            if (saveData.Read(saveName))
            {
                _clicker.currentCoinCount = saveData.coinCoint;
                _clicker.coinModifiersCalculator.coinModifiers = saveData.coinModifiers.ToList();
                _shop.SetAssortiment(saveData.shopModifiers.ToList());
            }
            else
            {
                Save(saveName);
            }
        }
    }

    private void Save(string saveName)
    {
        using (SaveData saveData = new SaveData(_clicker.currentCoinCount, _clicker.coinModifiersCalculator.coinModifiers, _shop.coinModifiers))
        {
            saveData.Write(saveName);
        }
    }
}
