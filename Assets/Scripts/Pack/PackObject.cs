using Quiz.Global;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Quiz.Pack
{
    public class PackObject : MonoBehaviour, IPackData
    {
        public PackData PackData { get; private set; }

        [SerializeField] private TMP_Text _packNameLabel;
        [SerializeField] private TMP_Text _unlockCostLabel;
        [SerializeField] private Button _unlockButton;
        [SerializeField] private Image _completeImage;
        public Action<bool, PackData> onUnlockPack;


        private void LoadPackList()
        {
            _packNameLabel.text = PackData.PackName;

            switch (PackData.IsUnlocked)
            {
                case true:
                    _unlockButton.gameObject.SetActive(false);
                    _unlockCostLabel.gameObject.SetActive(false);
                    gameObject.GetComponent<Button>().interactable = true;
                    break;
                case false:
                    _unlockCostLabel.text = PackData.UnlockCost.ToString();
                    _unlockButton.onClick.RemoveAllListeners();
                    _unlockButton.onClick.AddListener(UnlockPack);
                    gameObject.GetComponent<Button>().interactable = false;
                    break;
            }
            if (!PackData.IsCompleted)
            {
                _completeImage.gameObject.SetActive(false);
            }
        }

        private void UnlockPack()
        {
            if (CurrencyController.SpendCoin(PackData.UnlockCost))
            {
                SaveDataController.Instance.PlayerData.AddUnlockedPack(PackData.PackId);
                SaveDataController.Instance.Save();
                SetPackData(PackData.PackId);
                onUnlockPack?.Invoke(true, PackData);
            }
            else
            {
                //display coin not enough
                onUnlockPack?.Invoke(false, PackData);
            }
        }

        public void SetPackData(string packId)
        {
            PackData _temp = new();
            _temp.PackId = packId;
            _temp.PackName = $"Pack {packId}";
            _temp.IsCompleted = SaveDataController.Instance.PlayerData.IsPackCompleted(packId);
            _temp.IsUnlocked = SaveDataController.Instance.PlayerData.IsPackUnlocked(packId);
            _temp.UnlockCost = 100;

            PackData = _temp;

            LoadPackList();
        }

        public PackData GetPackData()
        {
            return PackData;
        }
    }

}
