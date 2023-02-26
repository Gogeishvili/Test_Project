
using System;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace Test_Project
{
    
    public class GameManager : MonoBehaviour
    {

        [Inject] private LevelManager _levelManager;


        private void Awake()
        {
            OnGameLoad();
        }

        public void OnGameLoad()
        {
            _levelManager.LoadLevel();
        }
        
        
        
        public void Lose()
        {
            Debug.Log("Lose");
        }

        [Button]
        public void Load()
        {
            SceneManager.LoadScene(0);
        }
    }
}