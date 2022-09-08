using Quiz.Global;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Quiz.Gameplay
{
    public class QuizController : MonoBehaviour
    {
        [SerializeField] private TMP_Text _questionText;
        [SerializeField] private Image _hintImage;
        [SerializeField] private Button[] _answerButtons;
        public Action<int> onPlayerAnswer;

        private void Start()
        {
            string _levelId = DatabaseController.Instance.ChoosenLevel;
            InitQuiz(DatabaseController.Instance.GetLevelStruct(_levelId));
        }

        public void InitQuiz(LevelStruct level)
        {
            _questionText.text = level.Question;

            for(int i = 0; i < _answerButtons.Length; i++)
            {
                _answerButtons[i].GetComponentInChildren<TMP_Text>().text = level.Choice[i];
                _answerButtons[i].onClick.RemoveAllListeners();
                int x = i;
                _answerButtons[i].onClick.AddListener(() => onPlayerAnswer?.Invoke(x));
            }

            _hintImage.sprite = Resources.Load<Sprite>($"LevelHints/Level Pack {level.PackID}/{level.Hint}");

        }
    }

}
