using UnityEngine;
using Zenject;

public class ClickerProjectInstaller : MonoInstaller
{
    [SerializeField] private SceneLoader _sceneLoader;

    public override void InstallBindings()
    {
        BindSceneLoader();
    }

    private void BindSceneLoader()
    {
        var sceneLoader = Container.InstantiatePrefabForComponent<SceneLoader>(_sceneLoader, Vector3.zero, Quaternion.identity, null);
        Container.Bind<SceneLoader>().FromInstance(sceneLoader).AsSingle();
    }
}
