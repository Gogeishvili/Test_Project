
using Sirenix.OdinInspector;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Serialization;


namespace Test_Project
{
    public class Player : MonoBehaviour
    {
        public PlayerStateMachine playerStateMachine { get;private set; }

        [SerializeField] private StatesComponents _statesComponents;
        

        private void Awake()
        {
            playerStateMachine = new PlayerStateMachine(this,_statesComponents);
        }

        private void Update()
        {
            playerStateMachine.currentState.Update();
        }

        [Button]
        public void ActiveState()
        {
            playerStateMachine.SwichState(playerStateMachine.playerActiveState);
        }
        
    }
    
    [System.Serializable]
    public struct StatesComponents
    {
        public IdleStateComponents idleStateComponents => _idleStateComponents;
        public ActiveComponents activeStateComponents => _activeStateComponents;
        
        
        [SerializeField] private IdleStateComponents _idleStateComponents;
        [SerializeField] private ActiveComponents _activeStateComponents;
        
        
        [System.Serializable]
        public struct IdleStateComponents
        {
            public Transform visual => _visual;
            public PlayerData playerData => _playerData;
        
            [SerializeField] private Transform _visual;
            [SerializeField] private PlayerData _playerData;
        }
        
        [System.Serializable]
        public struct ActiveComponents
        {
            public Transform visual => _visual;
            public PlayerData playerData => _playerData;
        
            [SerializeField] private Transform _visual;
            [SerializeField] private PlayerData _playerData;
        }
    }
}

