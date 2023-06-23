using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.Screens.Gallery
{
    public class FixedGridLayoutCellSize : MonoBehaviour
    {
        [SerializeField] private GameObject _imagesContainer;
        [SerializeField] private int _columnsCount;

        private RectTransform _rectTransform;
        private GridLayoutGroup _gridLayoutGroup;

        private void Update()
        {
            float width = _imagesContainer.GetComponent<RectTransform>().rect.width;
            Vector2 newSize = new Vector2(width / _columnsCount, width / _columnsCount);
            _imagesContainer.GetComponent<GridLayoutGroup>().cellSize = newSize;
        }
    }
}