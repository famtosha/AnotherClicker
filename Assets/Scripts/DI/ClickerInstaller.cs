using UnityEngine;
using Zenject;

public class ClickerInstaller : MonoInstaller
{
    [SerializeField] private Clicker _clickerPrefub;
    [SerializeField] private ClickerUI _clickerUIPrefub;

    [SerializeField] private ShopUI _shopUIPrefub;
    [SerializeField] private Shop _shopPrefub;

    [SerializeField] private Saver _saverPrefub;
    [SerializeField] private Background _backgrondPrefub;

    public override void InstallBindings()
    {
        BindClicker();
        BindShop();
        BindSaver();
        BindClickerUI();
        BindShopUI();
        BindBackground();
    }

    private void BindClickerUI()
    {
        var clickerUI = Container.InstantiatePrefabForComponent<ClickerUI>(_clickerUIPrefub, Vector3.zero, Quaternion.identity, null);
        Container.Bind<ClickerUI>().FromInstance(clickerUI).AsSingle();
    }

    private void BindClicker()
    {
        var clicker = Container.InstantiatePrefabForComponent<Clicker>(_clickerPrefub, Vector3.zero, Quaternion.identity, null);
        Container.Bind<Clicker>().FromInstance(clicker).AsSingle();
    }

    private void BindShopUI()
    {
        var shopUI = Container.InstantiatePrefabForComponent<ShopUI>(_shopUIPrefub, Vector3.zero, Quaternion.identity, null);
        Container.Bind<ShopUI>().FromInstance(shopUI).AsSingle();
    }

    private void BindShop()
    {
        var shop = Container.InstantiatePrefabForComponent<Shop>(_shopPrefub, Vector3.zero, Quaternion.identity, null);
        Container.Bind<Shop>().FromInstance(shop).AsSingle();
    }

    private void BindSaver()
    {
        var saver = Container.InstantiatePrefabForComponent<Saver>(_saverPrefub, Vector3.zero, Quaternion.identity, null);
        Container.Bind<Saver>().FromInstance(saver).AsSingle();
    }

    private void BindBackground()
    {
        var background = Container.InstantiatePrefabForComponent<Background>(_backgrondPrefub, Vector3.zero, Quaternion.identity, null);
        Container.Bind<Background>().FromInstance(background).AsSingle();
    }
}
