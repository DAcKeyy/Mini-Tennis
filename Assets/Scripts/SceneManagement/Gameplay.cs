using UnityEngine;

namespace UnityProject.SceneManagement
{
    public class Gameplay : MonoBehaviour
    {
        private bool _isGameInProgress;

        private void Start()
        {
            _isGameInProgress = false;
            PauseGame();
        }

        private void Update()
        {
            if (_isGameInProgress) return;
            
            if(Input.touchCount > 0)
            {
                ContinueGame();
            }
        }

        private void PauseGame()
        {
            Time.timeScale = 0;
            _isGameInProgress = false;
        }

        private void ContinueGame()
        {
            Time.timeScale = 1;
            _isGameInProgress = true;
        }
    }
}
