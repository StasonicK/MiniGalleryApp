using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.Screens.Gallery
{
    public class GalleryScreen : MonoBehaviour
    {
        [SerializeField] private Button _backButton;
        [SerializeField] private GameObject _imagesContainer;

        private IGalleryPresenter _galleryPresenter;

        private void Awake()
        {
            _galleryPresenter = new GalleryPresenter();
        }

        private void Start()
        {
            if (Application.platform == RuntimePlatform.Android)
                _backButton.onClick.AddListener(Back);
            else
                _backButton.gameObject.SetActive(false);
        }

        private void OnDestroy()
        {
            if (Application.platform == RuntimePlatform.Android)
                _backButton.onClick.RemoveListener(Back);
        }

        private void Back()
        {
            _galleryPresenter.Back();
        }
    }
}