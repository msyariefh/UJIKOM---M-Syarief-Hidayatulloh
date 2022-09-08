namespace Quiz.Global
{
    public static class CurrencyController
    {
        public static int GetCoin()
        {
            return SaveDataController.Instance.PlayerData.Coin;
        }
        public static void AddCoin(int amount)
        {
            SaveDataController.Instance.PlayerData.AddCoin(amount);
        }
        public static bool SpendCoin(int amount)
        {
            if (GetCoin() - amount < 0) return false;
            SaveDataController.Instance.PlayerData.SpendCoin(amount);
            return true;
        }
    }

}
