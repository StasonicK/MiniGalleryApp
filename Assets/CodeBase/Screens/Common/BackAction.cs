using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace CodeBase.Screens.Common
{
    public class BackAction : MonoBehaviour
    {
        [SerializeField] private Button _backButton;
        [SerializeField] private ScreenType screenType;

        private void Awake()
        {
            if (Application.platform == RuntimePlatform.Android || Application.isEditor)
            {
                // _backButton.gameObject.SetActive(true);
                _backButton.onClick.AddListener(Back);
            }
            else
                _backButton.gameObject.SetActive(false);
        }

        private void Back() =>
            SceneManager.LoadSceneAsync(screenType.ToString());
    }
}