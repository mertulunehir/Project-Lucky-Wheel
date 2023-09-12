using UnityEngine;
using Zenject;

public class DependencyInstaller : MonoInstaller
{
    [SerializeField] private RewardsDatabase rewardsDatabase;

    public override void InstallBindings()
    {
        Container.BindInstance(rewardsDatabase).AsSingle();
    }
}