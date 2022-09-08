using UnityEngine;
using System.Linq;
using System.Collections.Generic;

namespace Quiz.Global
{
    [System.Serializable]
    public class PlayerData
    {
        [SerializeField] private int _coin;
        [SerializeField] private string[] _unlockedPack;
        [SerializeField] private string[] _completedPack;
        [SerializeField] private string[] _completedLevel;

        public int Coin => _coin;

        public PlayerData()
        {
            _coin = 0;
            _completedLevel = new string[0];
            _completedPack = new string[0];
            _unlockedPack = new string[0];
        }

        public void AddUnlockedPack(string packId)
        {
            if (!_unlockedPack.Contains(packId))
                _unlockedPack = AddToArray(_unlockedPack, packId);
        }
        public void AddCompeletedPack(string packId)
        {
            if (!_completedPack.Contains(packId))
                _completedPack = AddToArray(_completedPack, packId);
        }
        public void AddCompletedLevel(string levelId)
        {
            if (!_completedLevel.Contains(levelId))
                _completedLevel = AddToArray(_completedLevel, levelId);
        }
        public void AddCoin(int amount)
        {
            _coin += amount;
        }
        public void SpendCoin(int amount)
        {
            _coin -= amount;
        }

        private T[] AddToArray<T>(T[] array, T valueToBeAdded)
        {
            return array.Concat(new T[] { valueToBeAdded }).ToArray();
        }

        public bool IsPackUnlocked(string packId)
        {
            return _unlockedPack.Contains(packId);
        }
        public bool IsPackCompleted(string packId)
        {
            return _completedPack.Contains(packId);
        }
        public bool IsLevelCompleted(string levelId)
        {
            return _completedLevel.Contains(levelId);
        }

    }
}
