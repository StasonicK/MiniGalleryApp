using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

namespace CodeBase.Gallery
{
    public class GalleryGrid : MonoBehaviour
    {
        [SerializeField] private ScrollRect _scrollRect;
        [SerializeField] private RectTransform _imagesContainer;
        [SerializeField] private ImageItem _imageItemPrefab;
        [SerializeField] private float _bottomLoadingMargin = 0.2f;

        private const int DataLength = 66;

        private int _loadedImageItemsCount = 0;
        private bool _isDownloading;

        private void Awake()
        {
            DownloadInitialImages();
        }

        private void DownloadInitialImages()
        {
            float scrollHeight = _scrollRect.GetComponent<RectTransform>().rect.height;
            float imageItemHeight = _imagesContainer.GetComponent<GridLayoutGroup>().cellSize.y;
            int columns = _imagesContainer.GetComponent<GridLayoutGroup>().constraintCount;

            int visibleImagesLimit = Mathf.CeilToInt((scrollHeight / imageItemHeight) * columns) + 3;

            for (int i = 1; i <= visibleImagesLimit; i++)
                DownloadImage(i);
        }

        private void DownloadImage(int number)
        {
            _isDownloading = true;
            string imageUrl = $"{Constants.URL}{number}{Constants.JpgFormat}";
            _loadedImageItemsCount++;
            StartCoroutine(CoroutineDownloadImage(imageUrl, number.ToString()));
            _isDownloading = false;
        }

        private IEnumerator CoroutineDownloadImage(string url, string name)
        {
            UnityWebRequest request = UnityWebRequestTexture.GetTexture(url);
            yield return request.SendWebRequest();

            if (request.result == UnityWebRequest.Result.Success)
            {
                Texture2D texture2D = DownloadHandlerTexture.GetContent(request);
                CreateImageItem(texture2D, name, url);
            }
            else
            {
                Debug.Log($"DownloadImages error: {request.error}");
            }
        }

        private void CreateImageItem(Texture2D texture2D, string name, string url)
        {
            ImageItem imageItem = Instantiate(_imageItemPrefab, _imagesContainer);
            imageItem.Construct(texture2D, name, url);
        }

        public void OnScrollChanged()
        {
            if (!_isDownloading && _loadedImageItemsCount < DataLength &&
                _scrollRect.verticalNormalizedPosition <= _bottomLoadingMargin)
            {
                for (int i = 1; i <= 3; i++)
                    DownloadImage(_loadedImageItemsCount + 1);
            }
        }
    }
}