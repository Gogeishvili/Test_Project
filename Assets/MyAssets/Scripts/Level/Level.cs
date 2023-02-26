using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Test_Project
{
    public class Level : MonoBehaviour
    {
        public Vector3 bulletTarget => _bulletTarget.position;
        public LevelPath LevelPath => _levelPath;
        public int level => _level;

        [SerializeField] private LevelPath _levelPath;
        [SerializeField] private int _level = 1;
        [SerializeField] private Transform _bulletTarget;
        
        public void On()
        {
            
        }

        public void Off()
        {
            
        }

    }
}