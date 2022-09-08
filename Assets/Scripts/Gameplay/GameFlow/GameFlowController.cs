using Quiz.Global;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Quiz.Gameplay
{
    public class GameFlowController : MonoBehaviour
    {
        [SerializeField] private GameplayScene _gameplayScene;
        [SerializeField] private CountdownController _countdownController;
        [SerializeField] private QuizController _quizController;
        private LevelStruct _levelStruct;
        private string[] _levelList;

        private void Start()
        {
            string _packId = DatabaseController.Instance.ChoosenPack;
            _levelList = DatabaseController.Instance.GetLevelList(_packId);
        }

        private void OnEnable()
        {
            _quizController.onPlayerAnswer += AnswerQuestion;
            _countdownController.onFinishCountdown += TimesUp;
        }

        private void OnDisable()
        {
            _quizController.onPlayerAnswer -= AnswerQuestion;
            _countdownController.onFinishCountdown -= TimesUp;
        }

        private void TimesUp()
        {
            _gameplayScene.GoToLevelScene();
        } 
        private void AnswerQuestion(int answer)
        {
            _countdownController.StopCountdown();
            string _levelId = DatabaseController.Instance.ChoosenLevel;
            _levelStruct = DatabaseController.Instance.GetLevelStruct(_levelId);
            if (answer != _levelStruct.Answer)
            {
                _gameplayScene.GoToLevelScene();
                return;
            }

            if (!DatabaseController.Instance.CheckIfLevelAlreadyCompleted())
            {
                CurrencyController.AddCoin(20);
                SaveDataController.Instance.PlayerData.AddCompletedLevel(_levelId);
                SaveDataController.Instance.Save();
                AnalyticController.Instance.TrackFinishLevel(_levelId);
            }
            

            int _currentLevelIndex = System.Array.FindIndex(_levelList, item => item == _levelId);
            if (_currentLevelIndex == _levelList.Length - 1)
            {
                if (DatabaseController.Instance.CheckIfAllLevelsInPackCompleted())
                {
                    string _packId = DatabaseController.Instance.ChoosenPack;
                    SaveDataController.Instance.PlayerData.AddCompeletedPack(_packId);
                    SaveDataController.Instance.Save();
                    _gameplayScene.GoToPackScene();

                }

                else
                    _gameplayScene.GoToLevelScene();

            }
            else
            {
                DatabaseController.Instance.ChoosenLevel = _levelList[_currentLevelIndex + 1];
                _quizController.InitQuiz(DatabaseController.Instance.GetLevelStruct(_levelList[_currentLevelIndex + 1]));
                _countdownController.StartCountdown();
            }
        }


    }

}
