using Unity.Mathematics;
using UnityEngine;

namespace Test_Project
{
    public class PlayerActiveState : BaseState<Player>
    {
        private readonly PlayerStatesComponents.ActiveComponents _activeStateComponents;
        private readonly LevelManager _levelManager;


        private float _initScaleValue;
        private int _usedBullets = 0;
        private bool _touched = false;

        public PlayerActiveState(Player i_main,
            PlayerStatesComponents.ActiveComponents i_activeStateComponents,
            LevelManager i_levelManager) : base(i_main)
        {
            _activeStateComponents = i_activeStateComponents;
            _levelManager = i_levelManager;
        }

        public override void Enter()
        {
            _usedBullets = 0;
            _initScaleValue = _activeStateComponents.playerVisual.localScale.x;

            _levelManager.currentLevel.onLevelComplite += Win;
        }

        public override void Update()
        {
            if (UnityEngine.Input.GetMouseButton(0))
            {
                _touched = true;
                GenerateBullet();
            }

            if (UnityEngine.Input.GetMouseButtonUp(0))
            {
                if (_touched)
                    Shoot();
                _touched = false;
            }
        }

        public override void Exit()
        {
            
            _touched = false;
        }

        private void GenerateBullet()
        {
            _activeStateComponents.playerVisual.localScale -=
                Vector3.one * (_activeStateComponents.playerData.scaleTime * Time.deltaTime);
            _levelManager.currentLevel.LevelPath.SetScale(_activeStateComponents.playerVisual.localScale.x);

            if (_activeStateComponents.playerVisual.localScale.x <= _activeStateComponents.playerData.minScaleValue)
            {
                _main.playerStateMachine.SwichState(_main.playerStateMachine.playerDeathState);
            }
        }

        private void Shoot()
        {
            _usedBullets += 1;
            float currentScaleValue = _activeStateComponents.playerVisual.localScale.x;

            Bullet bullet = GameObject.Instantiate(_activeStateComponents.playerData.bulletPref,
                _main.transform.position, quaternion.identity);

            float bulletScale = _initScaleValue - currentScaleValue;

            bullet.Init(bulletScale, _levelManager.currentLevel.bulletTarget, _levelManager,
                _activeStateComponents.playerData.enemylayer,
                _activeStateComponents.playerData.enemyDetectRadiusIncrement);

            _initScaleValue = _activeStateComponents.playerVisual.localScale.x;

            if (_usedBullets == _levelManager.currentLevel.countOfBullest)
            {
                _main.playerStateMachine.SwichState(_main.playerStateMachine.playerDeathState);
            }
        }

        void Win()
        {
            _main.playerStateMachine.SwichState(_main.playerStateMachine.playerWinState);
        }
    }
}