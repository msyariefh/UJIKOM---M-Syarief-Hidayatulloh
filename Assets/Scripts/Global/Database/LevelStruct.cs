using UnityEngine;

namespace Quiz.Global
{
    [System.Serializable]
    public struct LevelStruct 
    {
        [SerializeField] string _levelId;
        [SerializeField] string _packId;
        [SerializeField] string _question;
        [SerializeField] string _hint;
        [SerializeField] string[] _choice;
        [SerializeField] int _answer;
        public string LevelID => _levelId;
        public string PackID => _packId;
        public string Question => _question;
        public string Hint => _hint;
        public string[] Choice => _choice;
        public int Answer => _answer;
    }

}
