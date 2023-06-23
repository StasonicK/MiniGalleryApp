using UnityEngine.SceneManagement;

namespace CodeBase.Screens.Gallery
{
    public class GalleryPresenter : IGalleryPresenter
    {
        public void Back() =>
            SceneManager.LoadSceneAsync(Constants.MenuScene);
        
        // public void 
    }
}