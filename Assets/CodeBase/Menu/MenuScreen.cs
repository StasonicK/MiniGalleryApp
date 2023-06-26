using CodeBase.Common;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace CodeBase.Menu
{
    public class MenuScreen : MonoBehaviour
    {
        [SerializeField] private Button _toGalleryButton;

        private void Awake() =>
            _toGalleryButton.onClick.AddListener(ToGalleryScreen);

        private void ToGalleryScreen() =>
            SceneManager.LoadSceneAsync(ScreenType.Gallery.ToString());
    }
}