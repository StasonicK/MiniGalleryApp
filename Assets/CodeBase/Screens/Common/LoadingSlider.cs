using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.Screens.Common
{
    public class LoadingSlider : MonoBehaviour
    {
        [SerializeField] private Slider _slider;
        [SerializeField] private float _loadingTime;

        private float _spentTime = 0f;

        private void Start() =>
            StartCoroutine(MoveSlider());

        private IEnumerator MoveSlider()
        {
            while (_spentTime < _loadingTime)
            {
                _slider.value = _spentTime / _loadingTime;
                _spentTime += Time.deltaTime;
                yield return null;
            }

            if (_spentTime >= _loadingTime)
                gameObject.SetActive(false);
        }
    }
}