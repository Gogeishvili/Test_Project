using UnityEngine;
using System.Collections.Generic;
using Zenject;

namespace Test_Project
{
    public class LevelManager : MonoBehaviour
    {
        public Level currentLevel => _currentLevel;
        
        [SerializeField] List<Level> _levels = new List<Level>();
        [SerializeField] Level _currentLevel;
        [SerializeField] int _currentlevelIndex;

        [Inject] private UiManager _uiManager;
        
        public void LoadLevel()
        {
            _currentlevelIndex = PlayerPrefs.GetInt("Level", 1);
            _currentLevel?.Off();
            _currentLevel = _levels.Find(l => _currentlevelIndex == l.level);
            if (_currentLevel != null)
                _currentLevel.On();

            else
            {
                PlayerPrefs.SetInt("Level", 1);
                _currentlevelIndex = PlayerPrefs.GetInt("Level", 1);
                _currentLevel = _levels.Find(l => _currentlevelIndex == l.level);
                if (_currentLevel != null)
                    _currentLevel.On();
            }
            
            _uiManager.gameInfo.SetLevel(_currentLevel.level);
            _uiManager.gameInfo.SetBullets(_currentLevel.countOfBullest, 0);

        }
        
        public void CompliteLevel()
        {
            PlayerPrefs.SetInt("Level", _currentlevelIndex += 1);
        }

    }
}