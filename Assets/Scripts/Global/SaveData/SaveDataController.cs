
using UnityEngine;
namespace Quiz.Global
{
    public class SaveDataController : MonoBehaviour
    {
        public static SaveDataController Instance;
        public PlayerData PlayerData { get; private set; }

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
            Load();
        }

        private void Load()
        {
            if (!PlayerPrefs.HasKey("PlayerData"))
            {
                PlayerData _temp = new();
                var freePacks = DatabaseController.Instance.GetFreePackList();
                for (int i = 0; i < freePacks.Length; i++)
                {
                    _temp.AddUnlockedPack(freePacks[i]);
                }
                PlayerData = _temp;
                Save();
            }
            PlayerData = JsonUtility.FromJson<PlayerData>(
                PlayerPrefs.GetString("PlayerData"));
        }
        public void Save()
        {
            PlayerPrefs.SetString("PlayerData", JsonUtility.ToJson(PlayerData));
        }
    }

}
