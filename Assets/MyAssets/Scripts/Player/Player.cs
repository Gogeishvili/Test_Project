using Sirenix.OdinInspector;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;


namespace Test_Project
{
    public class Player : MonoBehaviour
    {
        public PlayerStateMachine playerStateMachine { get; private set; }

        [SerializeField] private PlayerStatesComponents _playerStatesComponents;
        
        [Inject] private LevelManager _levelManager;
        [Inject] private GameManager _gameManager;
        [Inject] private UiManager _uiManager;
        [Inject] private CameraManager _cameraManager;
        
        private void Start()
        {
            playerStateMachine = new PlayerStateMachine(this, _playerStatesComponents,_levelManager,
                _gameManager,_uiManager,_cameraManager);
            
            playerStateMachine.SwichState(playerStateMachine.playerIdleState);
        }

        private void Update()
        {
            playerStateMachine.currentState.Update();
        }
    }

    
    [System.Serializable]
    public struct PlayerStatesComponents
    {
        public IdleStateComponents idleStateComponents => _idleStateComponents;
        public ActiveComponents activeStateComponents => _activeStateComponents;


        [SerializeField] private IdleStateComponents _idleStateComponents;
        [SerializeField] private ActiveComponents _activeStateComponents;


        [System.Serializable]
        public struct IdleStateComponents
        {
            public Transform playerVisual => _playerVisual;
            public PlayerData playerData => _playerData;
           

            
            [SerializeField] private Transform _playerVisual;
            [SerializeField] private PlayerData _playerData;
            
        }

        [System.Serializable]
        public struct ActiveComponents
        {
            public Transform playerVisual => _playerVisual;
            public PlayerData playerData => _playerData;
            

            [SerializeField] private Transform _playerVisual;
            [SerializeField] private PlayerData _playerData;
            
        }
    }
}