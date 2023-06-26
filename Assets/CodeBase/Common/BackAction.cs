using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace CodeBase.Common
{
    public class BackAction : MonoBehaviour
    {
        [SerializeField] private Button _backButton;
        [SerializeField] private ScreenType screenType;
        [SerializeField] private SwipeDetector _swipeDetector;

        private void Awake()
        {
            if (Application.platform == RuntimePlatform.Android || Application.isEditor)
            {
                if (_swipeDetector != null)
                {
                    _swipeDetector.TurnOn();
                    _swipeDetector.SwipedLeft += Back;
                }

                _backButton.onClick.AddListener(Back);
            }
            else
            {
                if (_swipeDetector != null)
                    _swipeDetector.TurnOff();

                _backButton.gameObject.SetActive(false);
            }
        }

        private void Back() =>
            SceneManager.LoadSceneAsync(screenType.ToString());
    }
}