
using DG.Tweening;
using UnityEngine;

namespace Test_Project
{
    public  class PlayerWinState : BaseState<Player>
    {
        private readonly LevelManager _levelManager;
        private readonly GameManager _gameManager;
        private readonly CameraManager _cameraManager;
        private Finish _finish;
        
        
        public PlayerWinState(Player i_main,
            LevelManager i_levelManager,
            GameManager i_gameManager,
            CameraManager i_cameraManager) : base(i_main)
        {
            _levelManager = i_levelManager;
            _gameManager = i_gameManager;
            _cameraManager = i_cameraManager;
        }

        public override void Enter()
        {
            GameManager.gameOn = false;
            _finish = _levelManager.currentLevel.finish;

            _main.transform.DOMove(_finish.playerMovePoint.position, 2).OnComplete(() =>
            {
                _main.transform.DOJump(_finish.playerOnFinishPoint.position, 5, 1, 1).OnComplete(() =>
                {
                    _gameManager.Win();
                }).SetEase(Ease.Linear);
            });
            _cameraManager.SwichCamera(_cameraManager.winCamera);
        }

        public override void Update()
        {
            
        }

        public override void Exit()
        {
            
        }
    }
}