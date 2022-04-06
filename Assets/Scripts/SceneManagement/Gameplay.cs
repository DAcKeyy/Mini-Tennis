using UnityEngine;

namespace UnityProject.SceneManagement
{
    //TODO: Класс скоро станет слишком жирным...нужно подумать над разделением логики
    public class Gameplay : MonoBehaviour
    {
        //TODO: Сделать Instance через DI
        public static Gameplay Instance;
        
        private bool _isGameInProgress;
        private float _losesLeftToShowAdd = 5;
        
        private void Start()
        {
            if (Instance == null) Instance = this; 
            else if(Instance == this) Destroy(gameObject);
                
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

        public void Lose()
        {
            _losesLeftToShowAdd--;
            if(_losesLeftToShowAdd <= 0)
            {
                //Appodeal.show(Appodeal.REWARDED_VIDEO);
                _losesLeftToShowAdd = 5;
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
