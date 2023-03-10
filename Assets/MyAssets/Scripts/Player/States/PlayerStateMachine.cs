using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Test_Project
{
    public class PlayerStateMachine : BaseStateMachine<Player>
    {
        public PlayerIdleState playerIdleState { get; private set; }
        public PlayerActiveState playerActiveState { get; private set; }
        public PlayerWinState playerWinState { get; private set; }
        public PlayerDeathState playerDeathState { get; private set; }


        public PlayerStateMachine(Player i_main,
            PlayerStatesComponents i_playerStatesComponents,
            LevelManager i_levelManager,
            GameManager i_gameManager,
            UiManager i_uiManager,
            CameraManager i_cameraManager) : base(i_main)
        {
            playerIdleState = new PlayerIdleState(i_main, i_playerStatesComponents.idleStateComponents,i_levelManager);
            playerActiveState = new PlayerActiveState(i_main, i_playerStatesComponents.activeStateComponents,i_levelManager,i_uiManager);
            playerWinState = new PlayerWinState(i_main,i_levelManager,i_gameManager,i_cameraManager);
            playerDeathState = new PlayerDeathState(i_main,i_gameManager);

            SwichState(playerIdleState);
        }
    }
}