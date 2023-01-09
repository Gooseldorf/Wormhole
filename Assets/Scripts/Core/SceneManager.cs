using System.Collections;
using UnityEngine;

namespace Managers
{
    public class SceneManager: MonoBehaviour
    {
        public static SceneManager instance;

        void Start()
        {
            if (instance == null)
            {
                instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }

        public void ToMainMenu()
        {
            StartCoroutine(ToMainMenuRoutine());
        }

        private IEnumerator ToMainMenuRoutine()
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("Loading");
            yield return UnityEngine.SceneManagement.SceneManager.UnloadSceneAsync("Game");
            UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
        }
    }
}