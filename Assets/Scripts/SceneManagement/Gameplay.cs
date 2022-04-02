using UnityEngine;

namespace UnityProject.SceneManagement
{
    public class Gameplay : MonoBehaviour
    {
        private bool isGameInProgress;

        private void Start()
        {
            isGameInProgress = false;
            PauseGame();
        }

        private void Update()
        {
            if (isGameInProgress) return;
            
            if(Input.touchCount > 0)
            {
                ContinueGame();
            }
        }

        private void PauseGame()
        {
            Time.timeScale = 0;
            isGameInProgress = false;
        }

        private void ContinueGame()
        {
            Time.timeScale = 1;
            isGameInProgress = true;
        }
    }
}
