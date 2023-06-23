using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.Screens.Gallery
{
    public class GalleryScreen : MonoBehaviour
    {
        [SerializeField] private GameObject _imagesContainer;

        private IGalleryPresenter _galleryPresenter;

        private void Awake()
        {
            _galleryPresenter = new GalleryPresenter();
        }
    }
}