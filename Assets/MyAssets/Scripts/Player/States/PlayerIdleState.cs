using System.Numerics;
using Zenject;
using Vector3 = UnityEngine.Vector3;

namespace Test_Project
{
    public class PlayerIdleState : BaseState<Player>
    {
        private readonly PlayerStatesComponents.IdleStateComponents _idleStateComponents;
        private readonly LevelManager _levelManager;
        
        public PlayerIdleState(Player i_main,
            PlayerStatesComponents.IdleStateComponents i_idleStateComponents,
            LevelManager i_levelManager) : base(i_main)
        {
            _idleStateComponents = i_idleStateComponents;
            _levelManager = i_levelManager;

        }
        
        
        public override void Enter()
        {
            
            _idleStateComponents.playerVisual.localScale =Vector3.one * _idleStateComponents.playerData.initScale;
            _levelManager.currentLevel.LevelPath.SetScale(_idleStateComponents.playerData.initScale);
        }

        public override void Update()
        {
            
        }

        public override void Exit()
        {
            
        }

       
    }
}