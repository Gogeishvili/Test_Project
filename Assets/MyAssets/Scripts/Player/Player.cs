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
        
        private void Awake()
        {
            playerStateMachine = new PlayerStateMachine(this, _playerStatesComponents);
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

    #region Components
    
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
    #endregion 
}