using System.Numerics;
using Vector3 = UnityEngine.Vector3;

namespace Test_Project
{
    public class PlayerIdleState : BaseState<Player>
    {
        private PlayerStatesComponents.IdleStateComponents _idleStateComponents;
        
        public PlayerIdleState(Player i_main,
            PlayerStatesComponents.IdleStateComponents i_idleStateComponents) : base(i_main)
        {
            _idleStateComponents = i_idleStateComponents;
        }

        public override void Enter()
        {
            _idleStateComponents.visual.localScale =Vector3.one * _idleStateComponents.playerData.initScale;
        }

        public override void Update()
        {
            
        }

        public override void Exit()
        {
            
        }
    }
}