using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Quiz.Global
{
    public class DatabaseController : MonoBehaviour, IPackList, ILevelList
    {
        public static DatabaseController Instance;
        [SerializeField] private LevelDatabaseScriptable _database;
        public string ChoosenPack { get; set; }
        public string ChoosenLevel { get; set; }

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
                return;
            }
            else
            {
                Instance = this;
            }
        }

        public LevelStruct GetLevelStruct(string levelId)
        {
            return System.Array.Find(_database.LevelStruct, db => db.LevelID == levelId);
        }

        public string[] GetLevelList(string packId)
        {
            LevelStruct[] _temp = System.Array.FindAll(_database.LevelStruct,
                level => level.PackID == packId);
            string[] _returner = new string[_temp.Length];
            for (int i = 0; i < _returner.Length; i++)
            {
                _returner[i] = _temp[i].LevelID;
            }
            return _returner;
        }

        public string[] GetPackList()
        {
            LevelStruct[] _temp = _database.LevelStruct.Distinct(new LevelComparer()).ToArray();
            string[] _returner = new string[_temp.Length];
            for (int i = 0; i < _returner.Length; i++)
            {
                _returner[i] = _temp[i].PackID;
            }
            return _returner;   
        }
        public string[] GetFreePackList()
        {
            return _database.FreePacks;
        }

        public bool CheckIfLevelAlreadyCompleted()
        {

            if (SaveDataController.Instance.PlayerData.IsLevelCompleted(ChoosenLevel)) 
                return true;
            return false;
        }


        public bool CheckIfAllLevelsInPackCompleted()
        {
            foreach (string levelId in GetLevelList(ChoosenPack))
            {
                if (!SaveDataController.Instance.PlayerData.IsLevelCompleted(levelId)) 
                    return false;
            }
            return true;
        }
       

    }

}
