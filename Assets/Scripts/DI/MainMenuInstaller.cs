using UnityEngine;
using Zenject;

public class MainMenuInstaller : MonoInstaller
{
    [SerializeField] private MainMenu _mainMenu;

    public override void InstallBindings()
    {
        BindMainMenu();
    }

    private void BindMainMenu()
    {
        var mainMenu = Container.InstantiatePrefabForComponent<MainMenu>(_mainMenu, Vector3.zero, Quaternion.identity, null);
        Container.Bind<MainMenu>().FromInstance(mainMenu).AsSingle();
    }
}