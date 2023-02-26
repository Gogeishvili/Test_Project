
using DG.Tweening;
using UnityEngine;

namespace Test_Project
{
    public  class PlayerWinState : BaseState<Player>
    {
        private readonly LevelManager _levelManager;
        private readonly GameManager _gameManager;
        private Finish _finish;
        
        
        public PlayerWinState(Player i_main,
            LevelManager i_levelManager,
            GameManager i_gameManager) : base(i_main)
        {
            _levelManager = i_levelManager;
            _gameManager = i_gameManager;
        }

        public override void Enter()
        {
          
            _finish = _levelManager.currentLevel.finish;

            _main.transform.DOMove(_finish.playerMovePoint.position, 1).OnComplete(() =>
            {
                _main.transform.DOJump(_finish.playerOnFinishPoint.position, 3, 1, 0.5f).OnComplete(() =>
                {
                    _gameManager.Win();
                });
            });
        }

        public override void Update()
        {
            
        }

        public override void Exit()
        {
            
        }
    }
}