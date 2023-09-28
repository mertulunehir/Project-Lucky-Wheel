using LWheel.CollectedRewardsNameSpace;
using LWheel.RewardSceneNamespace;
using UnityEngine;
using Zenject;

public class CollectedRewardsDependecyInstaller : MonoInstaller
{
    [SerializeField] private CollectedRewardsPanel collectedRewardsPanel;
    [SerializeField] private CollectedRewardsPanelDataController collectedRewardsPanelDataController;

    public override void InstallBindings()
    {
        Container.BindInstance(collectedRewardsPanel).AsSingle();
        Container.BindInstance(collectedRewardsPanelDataController).AsSingle();

    }
}