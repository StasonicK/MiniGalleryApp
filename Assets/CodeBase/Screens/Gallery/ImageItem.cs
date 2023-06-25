using CodeBase.Screens.Common;
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

        private string _url;

        private void Awake() =>
            _toViewButton.onClick.AddListener(ToViewScreen);

        private void ToViewScreen()
        {
            DataTransfer.ToViewUrl = _url;
            DataTransfer.ToViewName = _nameText.text;
            SceneManager.LoadSceneAsync(ScreenType.View.ToString());
        }

        public void Construct(Texture2D icon, string name, string url)
        {
            _iconImage.texture = icon;
            _nameText.text = name;
            _url = url;
        }
    }
}