using UnityEngine;
using Zenject;
using Test_Project;


public class ManagersInstaller : MonoInstaller
{
    [SerializeField] private GameManager _gameManager;
    [SerializeField] private LevelManager _levelManager;
    
    public override void InstallBindings()
    {
        Container.Bind<GameManager>().FromInstance(_gameManager).AsSingle().NonLazy();
        Container.Bind<LevelManager>().FromInstance(_levelManager).AsSingle().NonLazy();

    }
}