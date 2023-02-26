using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using UniRx;
using UniRx.Triggers;
using UnityEngine.Serialization;
using Zenject;


namespace Test_Project
{
    public class Level : MonoBehaviour
    {
        public Action onLevelComplite;

        public Finish finish => _finish;
        public Vector3 bulletTarget => _bulletTarget.position;
        public LevelPath LevelPath => _levelPath;
        public int level => _level;
        public int countOfBullest => _countOfBullets;
        public Transform playerStaypoint => _playerStayPoint;


        [SerializeField] private int _countOfBullets = 10;
        [SerializeField] private Finish _finish;
        [SerializeField] private LevelPath _levelPath;
        [SerializeField] private int _level = 1;
        [SerializeField] private Transform _bulletTarget;
        [SerializeField] private List<Enemy> _enemies = new List<Enemy>();
        [SerializeField] private Collider _playerPathCollider;
        [SerializeField] private Transform _playerStayPoint;



        [Inject] private GameManager _gameManager;

        private readonly CompositeDisposable _compositeDisposable = new CompositeDisposable();
        private readonly Dictionary<GameObject, Enemy> _allEnemiesDictionaty = new Dictionary<GameObject, Enemy>();
        private bool _completed;
        private readonly List<Enemy> _enemiesOnPath = new List<Enemy>();
        
        public void On()
        {
            gameObject.SetActive(true);
            _completed = false;
            _allEnemiesDictionaty.Clear();
            _enemiesOnPath.Clear();

            foreach (var enemy in _enemies)
            {
                enemy.ResetEnemy();
                enemy.onEnemyDeathEvent += RemoveEnemy;
                _allEnemiesDictionaty.Add(enemy.gameObject, enemy);
            }

            _playerPathCollider.OnTriggerEnterAsObservable().Where(c => c.gameObject.layer
                                                                        == MyStatics.ENEMY_LAYER)
                .Subscribe(c =>
                {
                    Enemy enemy = _allEnemiesDictionaty[c.gameObject];
                    _enemiesOnPath.Add(enemy);
                }).AddTo(_compositeDisposable);
            
            _playerPathCollider.OnTriggerExitAsObservable().Where(c => c.gameObject.layer
                                                                        == MyStatics.ENEMY_LAYER)
                .Subscribe(c =>
                {
                    Enemy enemy = _allEnemiesDictionaty[c.gameObject];
                    RemoEnemyFromPath(enemy);
                    
                }).AddTo(_compositeDisposable);
        }

        public void Off()
        {
            foreach (var enemy in _enemies)
            {
                enemy.ResetEnemy();
            }
            _compositeDisposable.Clear();
            gameObject.SetActive(false);
        }

        void RemoveEnemy(Enemy i_enemy)
        {
            if (_allEnemiesDictionaty.ContainsKey(i_enemy.gameObject))
            {
                i_enemy.onEnemyDeathEvent -= RemoveEnemy;
                _allEnemiesDictionaty.Remove(i_enemy.gameObject);
            }

            RemoEnemyFromPath(i_enemy);
        }

        void RemoEnemyFromPath(Enemy i_enemy)
        {
            _enemiesOnPath.Remove(i_enemy);
            i_enemy.onEnemyDeathEvent -= RemoveEnemy;
            if (_enemiesOnPath.Count == 0)
            {
                if (_completed == false)
                {
                    _completed = true;
                    onLevelComplite?.Invoke();
                }
            }
        }
        
        public Enemy GetEnemyRef(GameObject i_key)
        {
            Enemy enemy = null;
            if (_allEnemiesDictionaty.ContainsKey(i_key))
            {
                enemy = _allEnemiesDictionaty[i_key];
            }

            return enemy;
        }
    }
}