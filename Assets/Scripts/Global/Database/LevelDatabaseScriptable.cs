using UnityEngine;

namespace Quiz.Global
{
    [CreateAssetMenu(fileName = "LevelDatabase", menuName = "Scriptable/LevelDatabase")]
    public class LevelDatabaseScriptable : ScriptableObject
    {
        [SerializeField] private string[] _freePacks;
        [SerializeField] private LevelStruct[] _levelStructs;
        public LevelStruct[] LevelStruct => _levelStructs;
        public string[] FreePacks => _freePacks;
    }

}
