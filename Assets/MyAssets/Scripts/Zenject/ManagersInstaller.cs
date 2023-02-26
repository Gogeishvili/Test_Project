using UnityEngine;
using Zenject;
using Test_Project;


public class ManagersInstaller : MonoInstaller
{
    [SerializeField] private GameManager _gameManager;
    [SerializeField] private LevelManager _levelManager;
    [SerializeField] private UiManager _uiManager;
    [SerializeField] private CameraManager _cameraManager;


    
    public override void InstallBindings()
    {
        Container.Bind<GameManager>().FromInstance(_gameManager).AsSingle().NonLazy();
        Container.Bind<LevelManager>().FromInstance(_levelManager).AsSingle().NonLazy();
        Container.Bind<UiManager>().FromInstance(_uiManager).AsSingle().NonLazy();
        Container.Bind<CameraManager>().FromInstance(_cameraManager).AsSingle().NonLazy();

        
    }
}