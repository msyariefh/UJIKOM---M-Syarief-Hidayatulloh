using Quiz.Global;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Quiz.Level
{
    public class LevelView : MonoBehaviour
    {
        [SerializeField] private Button _backButton;
        [SerializeField] private string _prevScene;
        [SerializeField] private string _nextScene;
        [SerializeField] private GameObject _levelItemTemplate;
        [SerializeField] private RectTransform _listContainer;

        private void Awake()
        {
            _backButton.onClick.RemoveAllListeners();
            _backButton.onClick.AddListener(GoBack);
        }

        private void Start()
        {
            ListLevel();
        }

        private void GoBack()
        {
            SceneManager.LoadScene(_prevScene);
        }

        private void ListLevel()
        {
            string _choosenPack = DatabaseController.Instance.ChoosenPack;
            string[] _levelList = DatabaseController.Instance.GetLevelList(_choosenPack);

            for (int i = 0; i < _levelList.Length; i++)
            {
                GameObject _go = Instantiate(_levelItemTemplate, _listContainer);
                _go.GetComponent<ILevelData>().SetLevelData(_levelList[i]);
                int x = i;
                _go.GetComponent<Button>().onClick.AddListener(() => SelectLevel(_levelList[x]));
            }

        }

        private void SelectLevel(string levelId)
        {
            DatabaseController.Instance.ChoosenLevel = levelId;
            SceneManager.LoadScene(_nextScene);
        }
    }

}
