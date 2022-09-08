namespace Quiz.Level
{
    public interface ILevelData
    {
        public void SetLevelData(string levelId);
        public LevelData GetLevelData();
    }
}