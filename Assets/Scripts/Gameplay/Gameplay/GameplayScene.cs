using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Quiz.Gameplay
{
    public class GameplayScene : MonoBehaviour
    {
        [SerializeField] private Button _backButton;
        [SerializeField] private string _packSceneName;
        [SerializeField] private string _levelSceneName;
        [SerializeField] private string _homeSceneName;

        private void Awake()
        {
            _backButton.onClick.RemoveAllListeners();
            _backButton.onClick.AddListener(QuitGame);
        }

        private void QuitGame()
        {
            SceneManager.LoadScene(_homeSceneName);
        }

        public void GoToLevelScene()
        {
            SceneManager.LoadScene(_levelSceneName);
        }
        public void GoToPackScene()
        {
            SceneManager.LoadScene(_packSceneName);
        }
    }
}

