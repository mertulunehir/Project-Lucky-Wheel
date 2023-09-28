using LWheel.CollectedRewardsNameSpace;
using LWheel.MoneyManagerNameSpace;
using LWheel.PanelChangeNameSpace;
using LWheel.RewardDatabase;
using UnityEngine;
using Zenject;

public class DependencyInstaller : MonoInstaller
{
    [SerializeField] private RewardsDatabase rewardsDatabase;
    [SerializeField] private PanelChangeManager panelManager;
    [SerializeField] private MoneyManager moneyManager;

    public override void InstallBindings()
    {
        Container.BindInstance(rewardsDatabase).AsSingle();
        Container.BindInstance(panelManager).AsSingle();
        Container.BindInstance(moneyManager).AsSingle();
    }
}