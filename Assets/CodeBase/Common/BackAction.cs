using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace CodeBase.Common
{
    public class BackAction : MonoBehaviour
    {
        [SerializeField] private Button _backButton;
        [SerializeField] private ScreenType screenType;
        [SerializeField] private SwipeDetector _swipeDetector;

        private void Awake()
        {
            if (Application.platform == RuntimePlatform.Android || Application.isEditor)
            {
                _swipeDetector.TurnOn();
                _swipeDetector.SwipedLeft += Back;
            }
            else
            {
                _swipeDetector.TurnOff();
            }

            _backButton.onClick.AddListener(Back);
        }

        private void Update()
        {
            if (Application.platform == RuntimePlatform.Android && Input.GetKey(KeyCode.Escape))
                Back();
        }

        private void Back() =>
            SceneManager.LoadSceneAsync(screenType.ToString());
    }
}