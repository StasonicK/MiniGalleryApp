using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

namespace CodeBase.Screens.Gallery
{
    public class GalleryGrid : MonoBehaviour
    {
        [SerializeField] private ScrollRect _scrollRect;
        [SerializeField] private RectTransform _imagesContainer;
        [SerializeField] private ImageItem _imageItemPrefab;
        [SerializeField] private float _bottomThreshold = 0.2f;

        private const int InitialDataLength = 25;
        private const int DataLength = 66;

        private int _loadedImageItemsCount = 0;
        private bool _isDownloading;

        private void Awake()
        {
            DownloadInitialImages();
        }

        private void DownloadInitialImages()
        {
            for (int i = 1; i <= InitialDataLength; i++)
                DownloadImage(i);
        }

        private void DownloadImage(int number)
        {
            _isDownloading = true;
            string imageUrl = $"{Constants.URL}{number}{Constants.JpgFormat}";
            _loadedImageItemsCount++;
            StartCoroutine(DownloadImages(imageUrl, number.ToString()));
            Debug.Log(imageUrl);
            _isDownloading = false;
        }

        private IEnumerator DownloadImages(string url, string name)
        {
            UnityWebRequest request = UnityWebRequestTexture.GetTexture(url);
            yield return request.SendWebRequest();

            if (request.result == UnityWebRequest.Result.Success)
            {
                Texture2D texture2D = DownloadHandlerTexture.GetContent(request);
                CreateImageItem(texture2D, name);
            }
            else
            {
                Debug.Log($"DownloadImages error: {request.error}");
            }
        }

        private void CreateImageItem(Texture2D texture2D, string name)
        {
            ImageItem imageItem = Instantiate(_imageItemPrefab, _imagesContainer);
            imageItem.Construct(texture2D, name);
        }

        public void OnScrollChanged()
        {
            if (!_isDownloading && _scrollRect.verticalNormalizedPosition <= _bottomThreshold &&
                _loadedImageItemsCount < DataLength)
            {
                for (int i = 1; i <= 3; i++)
                    DownloadImage(_loadedImageItemsCount + 1);
            }
        }
    }
}