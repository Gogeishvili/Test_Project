using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using UniRx;
using UniRx.Triggers;
using UnityEngine.Serialization;


namespace Test_Project
{
    public class Level : MonoBehaviour
    {
        public Action onLevelComplite;

        public Finish finish => _finish;
        public Vector3 bulletTarget => _bulletTarget.position;
        public LevelPath LevelPath => _levelPath;
        public int level => _level;


        [SerializeField] private Finish _finish;
        [SerializeField] private LevelPath _levelPath;
        [SerializeField] private int _level = 1;
        [SerializeField] private Transform _bulletTarget;
        [SerializeField] private List<Enemy> _enemies = new List<Enemy>();
        [SerializeField] private Collider _playerPathCollider;
        [SerializeField] private List<Enemy> _enemiesOnPath = new List<Enemy>();



      
        private readonly Dictionary<GameObject, Enemy> _allEnemiesDictionaty = new Dictionary<GameObject, Enemy>();
        private readonly Dictionary<GameObject, Enemy> _enemiesOnPathDictionaty = new Dictionary<GameObject, Enemy>();
        
        
        public void On()
        {
            gameObject.SetActive(true);

            _allEnemiesDictionaty.Clear();
            _enemiesOnPathDictionaty.Clear();
            
            foreach (var enemy in _enemies)
            {
                enemy.ResetEnemy();
                enemy.onEnemyDeathEvent += RemoveEnemy;
                _allEnemiesDictionaty.Add(enemy.gameObject,enemy);
            }
            
            _playerPathCollider.OnTriggerEnterAsObservable().Where(c => c.gameObject.layer 
                                                                        == MyStatics.ENEMY_LAYER)
                .Subscribe(c =>
                {
                    Enemy enemy = _allEnemiesDictionaty[c.gameObject];
                    _enemiesOnPathDictionaty.Add(enemy.gameObject,enemy);
                    _enemiesOnPath.Add(enemy);
                   
                });
        }
        
        public void Off()
        {
            foreach (var enemy in _enemies)
            {
                enemy.ResetEnemy();
            }
            gameObject.SetActive(false);
            
        }

        void RemoveEnemy(Enemy i_enemy)
        {
            if (_allEnemiesDictionaty.ContainsKey(i_enemy.gameObject))
            {
                i_enemy.onEnemyDeathEvent -= RemoveEnemy;
                _allEnemiesDictionaty.Remove(i_enemy.gameObject);
            }
            if (_enemiesOnPathDictionaty.ContainsKey(i_enemy.gameObject))
            {
                i_enemy.onEnemyDeathEvent -= RemoveEnemy;
                _enemiesOnPathDictionaty.Remove(i_enemy.gameObject);
                if (_enemiesOnPathDictionaty.Count <= 0)
                {
                    onLevelComplite?.Invoke();
                } 
            }
        }

        [Button]
        public void TestCompliteLevel()
        {
            foreach (var VARIABLE in _enemiesOnPath)
            {
                VARIABLE.TakeDamage();
            }
            
        }
        
        public Enemy GetEnemyRef(GameObject i_key)
        {
            Enemy enemy=null;
            if (_allEnemiesDictionaty.ContainsKey(i_key))
            {
                enemy = _allEnemiesDictionaty[i_key];
            }

            return enemy;
        }

    }
}