using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace CodeBase.Screens.Gallery
{
    public class BackAction : MonoBehaviour
    {
        [SerializeField] private Button _backButton;

        private void Awake()
        {
            if (Application.platform == RuntimePlatform.Android)
            {
                // _backButton.gameObject.SetActive(true);
                _backButton.onClick.AddListener(Back);
            }
            else
                _backButton.gameObject.SetActive(false);
        }

        private void Back() =>
            SceneManager.LoadSceneAsync(Constants.MenuScene);
    }
}