using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace CodeBase.Screens.Gallery
{
    public class ImageItem : MonoBehaviour
    {
        [SerializeField] private RawImage _iconImage;
        [SerializeField] private TextMeshProUGUI _nameText;
        [SerializeField] private Button _toViewButton;

        // private void Awake() => 
        //     _toViewButton.onClick.AddListener(ToViewScreen);

        private void ToViewScreen() =>
            SceneManager.LoadSceneAsync(Constants.ViewScene);

        public void Construct(Texture2D icon, string name)
        {
            _iconImage.texture = icon;
            _nameText.text = name;
        }
    }
}