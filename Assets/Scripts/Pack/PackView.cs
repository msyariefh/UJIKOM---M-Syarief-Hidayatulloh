using Quiz.Global;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Quiz.Pack
{
    public class PackView : MonoBehaviour
    {
        [SerializeField] private Button _backButton;
        [SerializeField] private string _prevScene;
        [SerializeField] private string _nextScene;
        [SerializeField] private GameObject _PackItemTemplate;
        [SerializeField] private RectTransform _listContainer;
        [SerializeField] private TMP_Text _coinText;
        [SerializeField] private GameObject _popup;

        private void Awake()
        {
            _backButton.onClick.RemoveAllListeners();
            _backButton.onClick.AddListener(GoBack);
        }

        private void Start()
        {
            ListPack();
            _coinText.text = SaveDataController.Instance.PlayerData.Coin.ToString();
        }

        private void GoBack()
        {
            SceneManager.LoadScene(_prevScene);
        }
        
        private void ListPack()
        {
            string[] _packList = DatabaseController.Instance.GetPackList();
            for(int i = 0; i < _packList.Length; i++)
            {
                GameObject _go = Instantiate(_PackItemTemplate, _listContainer);

                _go.GetComponent<IPackData>().SetPackData(_packList[i]);
                _go.GetComponent<PackObject>().onUnlockPack += OnUnlockPack;
                int x = i;
                _go.GetComponent<Button>().onClick.AddListener(() => SelectPack(_packList[x]));
            }
            
        }
         private void OnUnlockPack(bool succes, PackData data)
        {
            if (!succes)
            {
                _popup.SetActive(true);
            }
            else
            {
                AnalyticController.Instance.TrackUnlockPack(data.PackId);
                _coinText.text = SaveDataController.Instance.PlayerData.Coin.ToString();
            }
        }

        private void SelectPack(string packId)
        {
            DatabaseController.Instance.ChoosenPack = packId;
            SceneManager.LoadScene(_nextScene);
        }
    }

}
