using LWheel.LuckyWheelNameSpace;
using UnityEngine;
using Zenject;

public class LuckyWheelDependencyInstaller : MonoInstaller
{
    [SerializeField] private LuckyWheel luckyWheel;
    [SerializeField] private LuckyWheelDataController wheelDataController;
    [SerializeField] private LuckyWheelRotateController wheelRotateController;
    [SerializeField] private LuckyWheelZoneController wheelZoneController;
    [SerializeField] private LuckyWheelButtonController wheelButtonController;
    [SerializeField] private LuckyWheelImageController wheelImageController;
    
    public override void InstallBindings()
    {
        Container.BindInstance(luckyWheel).AsSingle();
        Container.BindInstance(wheelDataController).AsSingle();
        Container.BindInstance(wheelRotateController).AsSingle();
        Container.BindInstance(wheelZoneController).AsSingle();
        Container.BindInstance(wheelButtonController).AsSingle();
        Container.BindInstance(wheelImageController).AsSingle();
    }
}
