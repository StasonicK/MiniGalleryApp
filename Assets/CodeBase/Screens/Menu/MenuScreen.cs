using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.Screens.Menu
{
    public class MenuScreen : MonoBehaviour
    {
        [SerializeField] private Button _toGalleryButton;
        
        private const string URL = "http://data.ikppbb.com/test-task-unity-data/pics/";
        
     private   void OnEnable()
        {
        _toGalleryButton.onClick.AddListener(ToGalleryScreen);
        }
        
     private   void OnDisable()
        {
        _toGalleryButton.onClick.RemoveListener(ToGalleryScreen);
        }

     private void ToGalleryScreen()
     {
         StartCoroutine(DownloadImages());
     }

     private IEnumerator DownloadImages()
     {
         
         
         yield return null;
     }
    }
}
