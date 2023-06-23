using UnityEngine;

namespace CodeBase.Screens.Gallery
{
    public class GalleryScreen : MonoBehaviour
    {
        private IGalleryPresenter _galleryPresenter;

        private void Awake() =>
            _galleryPresenter = new GalleryPresenter();
    }
}