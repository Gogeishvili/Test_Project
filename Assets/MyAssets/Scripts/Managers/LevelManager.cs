using UnityEngine;
using Zenject;
using System.Collections;
using System.Collections.Generic;

namespace Test_Project
{
    public class LevelManager : MonoBehaviour
    {
        public Level currentLevel => _currentLevel;
        
        [SerializeField] List<Level> _levels = new List<Level>();
        [SerializeField] Level _currentLevel;
        [SerializeField] int _currentlevelIndex;
        
        public void LoadLevel()
        {
            _currentlevelIndex = PlayerPrefs.GetInt("Level", 1);
            _currentLevel?.Off();
            _currentLevel = _levels.Find(l => _currentlevelIndex == l.level);
            _currentLevel?.On();
        }
        
        public void CompliteLevel()
        {
            PlayerPrefs.SetInt("Level", _currentlevelIndex += 1);
        }

    }
}