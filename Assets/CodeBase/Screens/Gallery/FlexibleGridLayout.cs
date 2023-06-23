using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.Screens.Gallery
{
    public class FlexibleGridLayout : LayoutGroup
    {
        [SerializeField] private int _rows;
        [SerializeField] private int _columns;
        [SerializeField] private Vector2 _cellSize;
        [SerializeField] private Vector2 _spacing;

        public override void CalculateLayoutInputHorizontal()
        {
            base.CalculateLayoutInputHorizontal();

            float sqrRt = Mathf.Sqrt(transform.childCount);
            _rows = Mathf.CeilToInt(sqrRt);
            _columns = Mathf.CeilToInt(sqrRt);

            float parentWidth = rectTransform.rect.width;
            float parentHeight = rectTransform.rect.height;

            // float cellWidth = parentWidth / (float)_columns;
            // float cellHeight = parentHeight / (float)_rows;
            float cellWidth = (parentWidth / (float)_columns) - ((_spacing.x / (float)_columns) * 2);
            float cellHeight = (parentHeight / (float)_rows) - ((_spacing.y / (float)_rows) * 2);
            // float cellWidth = (parentWidth / (float)_columns) - ((_spacing.x / (float)_columns) * (_columns - 1));
            // float cellHeight = (parentHeight / (float)_rows) - ((_spacing.y / (float)_rows) * (_rows - 1));

            _cellSize.x = cellWidth;
            _cellSize.y = cellHeight;

            int columnCount = 0;
            int rowCount = 0;

            for (int i = 0; i < rectChildren.Count; i++)
            {
                rowCount = i / _columns;
                columnCount = i % _columns;

                var item = rectChildren[i];

                var xPos = (_cellSize.x * columnCount); // + (_spacing.x * columnCount);
                var yPos = (_cellSize.y * rowCount); // + (_spacing.y * rowCount);

                SetChildAlongAxis(item, 0, xPos, _cellSize.x);
                SetChildAlongAxis(item, 1, yPos, _cellSize.y);
            }
        }

        public override void CalculateLayoutInputVertical()
        {
        }

        public override void SetLayoutHorizontal()
        {
        }

        public override void SetLayoutVertical()
        {
        }
    }
}