using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.Screens.Menu
{
    public class MenuScreen : MonoBehaviour
    {
        [SerializeField] private Button _toGalleryButton;

        private IMenuPresenter _menuPresenter;

        private void Awake() =>
            _menuPresenter = new MenuPresenter();

        private void OnEnable() =>
            _toGalleryButton.onClick.AddListener(ToGalleryScreen);

        private void OnDisable() =>
            _toGalleryButton.onClick.RemoveListener(ToGalleryScreen);

        private void ToGalleryScreen() =>
            _menuPresenter.LaunchGalleryScreen();
    }
}