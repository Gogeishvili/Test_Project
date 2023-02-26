
using DG.Tweening;
using UnityEngine;

namespace Test_Project
{
    public  class PlayerWinState : BaseState<Player>
    {
        private LevelManager _levelManager;
        private Finish _finish;
        public PlayerWinState(Player i_main,
            LevelManager i_levelManager) : base(i_main)
        {
            _levelManager = i_levelManager;
        }

        public override void Enter()
        {
          
            _finish = _levelManager.currentLevel.finish;

            _main.transform.DOMove(_finish.playerMovePoint.position, 1).OnComplete(() =>
            {
                _main.transform.DOJump(_finish.playerOnFinishPoint.position, 3, 1, 0.5f).OnComplete(() =>
                {

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