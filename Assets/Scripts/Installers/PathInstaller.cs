using UnityEngine;
using Zenject;

public class PathInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<Path>().FromComponentInHierarchy().AsSingle();
    }
}