using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace CodeBase.Screens.Menu
{
    public class MenuScreen : MonoBehaviour
    {
        [SerializeField] private Button _toGalleryButton;

        private void OnEnable() =>
            _toGalleryButton.onClick.AddListener(ToGalleryScreen);

        private void OnDisable() =>
            _toGalleryButton.onClick.RemoveListener(ToGalleryScreen);

        private void ToGalleryScreen() =>
            SceneManager.LoadSceneAsync(Constants.GALLERY_SCENE);
    }
}