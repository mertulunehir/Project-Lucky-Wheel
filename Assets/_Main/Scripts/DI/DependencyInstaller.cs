using UnityEngine;
using Zenject;

public class DependencyInstaller : MonoInstaller
{
    [SerializeField] private RewardsDatabase rewardsDatabase;
    [SerializeField] private PanelChangeManager panelManager;
    [SerializeField] private CollectedRewardsPanel collectedRewardsPanel;
    [SerializeField] private MoneyManager moneyManager;

    public override void InstallBindings()
    {
        Container.BindInstance(rewardsDatabase).AsSingle();
        Container.BindInstance(panelManager).AsSingle();
        Container.BindInstance(collectedRewardsPanel).AsSingle();
        Container.BindInstance(moneyManager).AsSingle();
    }
}