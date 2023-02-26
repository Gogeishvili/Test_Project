
using UnityEngine;
using Zenject;

namespace Test_Project
{
    
    public class GameManager : MonoBehaviour
    {
        [Inject] private Player _player;
        [Inject] private LevelManager _levelManager;
        [Inject] private UiManager _uiManager;

        private void Awake()
        {
            OnGameLoad();
        }

        private void OnGameLoad()
        {
            _levelManager.LoadLevel();
            _uiManager.SwitchUI(_uiManager.menuUI);
            _player.playerStateMachine.SwichState(_player.playerStateMachine.playerIdleState);
        }

        public void StartGame()
        {
            _uiManager.SwitchUI(_uiManager.inGameUI);
            _player.playerStateMachine.SwichState(_player.playerStateMachine.playerActiveState);
           
        }

        public void Win()
        {
            _uiManager.SwitchUI(_uiManager.winUI);
            _levelManager.CompliteLevel();
        }

        public void Lose()
        {
            _uiManager.SwitchUI(_uiManager.loseUI);
        }
        public void NextLeve()
        {
            _levelManager.LoadLevel();
            _player.playerStateMachine.SwichState(_player.playerStateMachine.playerIdleState);
            _player.playerStateMachine.SwichState(_player.playerStateMachine.playerActiveState);
            _uiManager.SwitchUI(_uiManager.inGameUI);
        }
        
        public void PlayAgain()
        {
            _levelManager.LoadLevel();
            _player.playerStateMachine.SwichState(_player.playerStateMachine.playerIdleState);
            _player.playerStateMachine.SwichState(_player.playerStateMachine.playerActiveState);
            _uiManager.SwitchUI(_uiManager.inGameUI);
        }
        
    }
}