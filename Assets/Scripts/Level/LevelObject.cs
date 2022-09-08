using Quiz.Global;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Quiz.Level
{
    public class LevelObject : MonoBehaviour, ILevelData
    {
        public LevelData LevelData { get; private set; }
        [SerializeField] private TMP_Text _levelNameLabel;
        [SerializeField] private Image _completeImage;

        private void LoadLevelList()
        {
            _levelNameLabel.text = LevelData.LevelName;

            if (!LevelData.IsCompleted)
                _completeImage.gameObject.SetActive(false);
        }


        public LevelData GetLevelData()
        {
            return LevelData;
        }

        public void SetLevelData(string levelId)
        {
            LevelData _temp = new();
            _temp.LevelId = levelId;
            _temp.LevelName = $"Level {levelId}";
            _temp.IsCompleted = SaveDataController.Instance.PlayerData.IsLevelCompleted(levelId);
            LevelData = _temp;

            LoadLevelList();
        }
    }

}
