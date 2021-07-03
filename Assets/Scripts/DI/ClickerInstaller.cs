using UnityEngine;
using Zenject;

public class ClickerInstaller : MonoInstaller
{
    [SerializeField] private Clicker _clicker;
    [SerializeField] private ClickerUI _clickerUI;

    [SerializeField] private ShopUI _shopUI;
    [SerializeField] private Shop _shop;

    [SerializeField] private Saver _saver;
    [SerializeField] private Background _background;

    public override void InstallBindings()
    {
        Container.Bind<Clicker>().FromInstance(_clicker).AsSingle();
        Container.Bind<Shop>().FromInstance(_shop).AsSingle();
        Container.Bind<Saver>().FromInstance(_saver).AsSingle();

        Container.Bind<ClickerUI>().FromInstance(_clickerUI).AsSingle();
        Container.Bind<ShopUI>().FromInstance(_shopUI).AsSingle();
        Container.Bind<Background>().FromInstance(_background).AsSingle();
    }
}