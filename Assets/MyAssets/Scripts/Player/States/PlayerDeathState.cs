using UnityEngine;
using Zenject;

namespace Test_Project
{
    public class PlayerDeathState : BaseState<Player>
    {
        private readonly GameManager _gameManager;

        public PlayerDeathState(Player i_main,
            GameManager i_gameManager) : base(i_main)
        {
            _gameManager = i_gameManager;
        }

        public override void Enter()
        {
            _gameManager.Lose();
        }

        public override void Update()
        {
        }

        public override void Exit()
        {
        }
    }
}