using UnityEngine;
using Zenject;

public class DependencyInstaller : MonoInstaller
{
    [SerializeField] private RewardsDatabase rewardsDatabase;
    [SerializeField] private SceneChangeManager sceneManager;
    [SerializeField] private CollectedRewardsPanel collectedRewardsPanel;

    public override void InstallBindings()
    {
        Container.BindInstance(rewardsDatabase).AsSingle();
        Container.BindInstance(sceneManager).AsSingle();
        Container.BindInstance(collectedRewardsPanel).AsSingle();
    }
}