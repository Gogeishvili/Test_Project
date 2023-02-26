
using UnityEngine;
using Zenject;

namespace Test_Project
{
    
    public class GameManager : MonoBehaviour
    {
        public static bool gameOn = false;
        
        [Inject] private Player _player;
        [Inject] private LevelManager _levelManager;
        [Inject] private UiManager _uiManager;
        [Inject] private CameraManager _cameraManager;

        private void Awake()
        {
            OnGameLoad();
        }

        private void OnGameLoad()
        {
            _levelManager.LoadLevel();
            _uiManager.SwitchUI(_uiManager.menuUI);
            _player.playerStateMachine.SwichState(_player.playerStateMachine.playerIdleState);
            _cameraManager.SwichCamera(_cameraManager.menuCamera);
            gameOn = false;
        }

        public void StartGame()
        {
            _uiManager.SwitchUI(_uiManager.inGameUI);
            _player.playerStateMachine.SwichState(_player.playerStateMachine.playerActiveState);
            _cameraManager.SwichCamera(_cameraManager.inGameCamera);
            gameOn = true;

        }

        public void Win()
        {
            _uiManager.SwitchUI(_uiManager.winUI);
            _levelManager.CompliteLevel();
            gameOn = false;
        }
        
        public void Lose()
        {
            _uiManager.SwitchUI(_uiManager.loseUI);
            gameOn = false;
        }
        public void NextLeve()
        {
            _levelManager.LoadLevel();
            _player.playerStateMachine.SwichState(_player.playerStateMachine.playerIdleState);
            _uiManager.SwitchUI(_uiManager.inGameUI);
            _player.playerStateMachine.SwichState(_player.playerStateMachine.playerActiveState);
            _cameraManager.SwichCamera(_cameraManager.inGameCamera);
            gameOn = true;
        }
        
        public void PlayAgain()
        {
            _levelManager.LoadLevel();
            _player.playerStateMachine.SwichState(_player.playerStateMachine.playerIdleState);
            _uiManager.SwitchUI(_uiManager.inGameUI);
            _player.playerStateMachine.SwichState(_player.playerStateMachine.playerActiveState);
            _cameraManager.SwichCamera(_cameraManager.inGameCamera);
            gameOn = true;
        }
        
    }
}