
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Quiz.Home
{
    public class HomeView : MonoBehaviour
    {
        [SerializeField] private Button _playButton;
        [SerializeField] private string _nextScene;

        private void Awake()
        {
            _playButton.onClick.RemoveAllListeners();
            _playButton.onClick.AddListener(StartPlay);
        }
        private void StartPlay()
        {
            SceneManager.LoadScene(_nextScene);
        }
    }

}
