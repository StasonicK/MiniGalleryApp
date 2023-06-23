using CodeBase.Screens.Common;
using UnityEngine.SceneManagement;

namespace CodeBase.Screens.Menu
{
    public class MenuPresenter : IPresenter, IMenuPresenter
    {
        public void LaunchGalleryScreen() =>
            SceneManager.LoadSceneAsync(Constants.GalleryScene);
    }
}