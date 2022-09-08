
using UnityEngine;
namespace Quiz.Global
{
    public class AnalyticController : MonoBehaviour
    {
        public static AnalyticController Instance;

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
        public void TrackFinishLevel(string levelId)
        {
            Debug.Log($"Analytic: Finish Level {levelId}");
        }

        public void TrackUnlockPack(string packId)
        {
            Debug.Log($"Analytic: Unlock New Pack {packId}");
        }
    }

}
