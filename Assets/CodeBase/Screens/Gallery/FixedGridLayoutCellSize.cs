using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.Screens.Gallery
{
    public class FixedGridLayoutCellSize : MonoBehaviour
    {
        [SerializeField] private GameObject _imagesContainer;
        [SerializeField] private GameObject _verticalScrollContainer;
        [SerializeField] private int _columnsCount;

        private const float AdditionalWidth = 20f;
        
        private RectTransform _rectTransform;
        private GridLayoutGroup _gridLayoutGroup;
        private float _verticalScrollWidth;

        private void Awake()
        {
            _verticalScrollWidth = _verticalScrollContainer.GetComponent<RectTransform>().rect.width;
        }

        private void Update()
        {
            float width = _imagesContainer.GetComponent<RectTransform>().rect.width;
            float itemWidth = ((width 
                                // - _verticalScrollWidth
                                ) / _columnsCount);
            Vector2 newSize = new Vector2(itemWidth, itemWidth);
            _imagesContainer.GetComponent<GridLayoutGroup>().cellSize = newSize;
        }
    }
}