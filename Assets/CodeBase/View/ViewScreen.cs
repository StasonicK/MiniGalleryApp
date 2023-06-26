using System.Collections;
using CodeBase.Common;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

namespace CodeBase.View
{
    public class ViewScreen : MonoBehaviour
    {
        [SerializeField] private RawImage _iconImage;
        [SerializeField] private TextMeshProUGUI _nameText;

        private void Start() =>
            StartCoroutine(CoroutineDownloadImage(DataTransfer.ToViewUrl, DataTransfer.ToViewName));

        private IEnumerator CoroutineDownloadImage(string url, string name)
        {
            UnityWebRequest request = UnityWebRequestTexture.GetTexture(url);
            yield return request.SendWebRequest();

            if (request.result == UnityWebRequest.Result.Success)
            {
                Texture2D texture2D = DownloadHandlerTexture.GetContent(request);
                SetImageData(name, texture2D);
            }
            else
            {
                Debug.Log($"DownloadImages error: {request.error}");
            }
        }

        private void SetImageData(string name, Texture2D texture2D)
        {
            _iconImage.texture = texture2D;
            _nameText.text = name;
        }
    }
}