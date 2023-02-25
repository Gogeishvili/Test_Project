using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Test_Project
{

    public class PlayerStateMachine : BaseStateMachine<Player>
    {
        public PlayerIdleState playerIdleState { get;private set; }
        public PlayerActiveState playerActiveState { get;private set; }
        public PlayerWinState playerWinState { get;private set; }
        public PlayerDeathState playerDeathState { get;private set; }

        
        public PlayerStateMachine(Player i_main,
            StatesComponents iStatesComponents) : base(i_main)
        {
            playerIdleState = new PlayerIdleState(i_main);
            playerActiveState = new PlayerActiveState(i_main,iStatesComponents.activeStateComponents);
            playerWinState = new PlayerWinState(i_main);
            playerDeathState = new PlayerDeathState(i_main);
            
            SwichState(playerIdleState);
        }
    }
}