using LWheel.RewardSceneNamespace;
using UnityEngine;
using Zenject;

public class RewardPanelInstaller : MonoInstaller
{
    [SerializeField] private RewardScene rewardScene;
    [SerializeField] private RewardSceneDataController rewardSceneDataController;
    [SerializeField] private RewardSceneButtonController rewardSceneButtonController;

    public override void InstallBindings()
    {
        Container.BindInstance(rewardScene).AsSingle();
        Container.BindInstance(rewardSceneDataController).AsSingle();
        Container.BindInstance(rewardSceneButtonController).AsSingle();

    }
}