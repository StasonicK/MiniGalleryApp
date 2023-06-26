using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace CodeBase.Common
{
    public class SwipeDetector : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
    {
        [SerializeField] private float swipeThreshold = 100f;

        private Direction direction;
        private Vector2 startPos, endPos;
        private bool draggingStarted;

        public event Action SwipedLeft;

        private void Awake()
        {
            draggingStarted = false;
            direction = Direction.None;
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            draggingStarted = true;
            startPos = eventData.pressPosition;
        }

        public void OnDrag(PointerEventData eventData)
        {
            if (draggingStarted)
            {
                endPos = eventData.position;

                Vector2 difference = endPos - startPos;

                if (difference.magnitude > swipeThreshold)
                {
                    if (Mathf.Abs(difference.x) > Mathf.Abs(difference.y))
                    {
                        direction = difference.x > 0
                            ? Direction.Right
                            : Direction.Left;
                    }
                    else //Do vertical swipe
                    {
                        direction = difference.y > 0
                            ? Direction.Up
                            : Direction.Down;
                    }
                }
                else
                {
                    direction = Direction.None;
                }
            }
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            if (draggingStarted && direction != Direction.None)
            {
                if (direction == Direction.Left)
                    SwipedLeft?.Invoke();

                Debug.Log("Swipe direction: " + direction);
            }

            startPos = Vector2.zero;
            endPos = Vector2.zero;
            draggingStarted = false;
        }

        public void TurnOn() =>
            gameObject.SetActive(true);

        public void TurnOff() =>
            gameObject.SetActive(false);

        private enum Direction
        {
            Left,
            Up,
            Right,
            Down,
            None
        }
    }
}