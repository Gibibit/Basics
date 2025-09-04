using TriInspector;

using UnityEngine;
using UnityEngine.UI;

namespace Basics
{
    public class ImageProgressBar : MonoBehaviour
    {
        [SerializeField] private RectTransform fill;
        [SerializeField] private RectTransform background;

        private float barWidth;
        private float barHeight;

        private Image fillImage;
        private Image backgroundImage;

        private void Awake()
        {
            fillImage = fill.GetComponent<Image>();
            backgroundImage = background.GetComponent<Image>();

            barWidth = background.rect.width;
            barHeight = background.rect.height;
        }

        public void SetProgress(float factor)
        {
            factor = Mathf.Clamp01(factor);
            fill.sizeDelta = new Vector2(factor*barWidth, 0f);
        }

        public void SetFillColor(Color color)
        {
            fillImage.color = color;
        }

        public void SetBackgroundColor(Color color)
        {
            backgroundImage.color = color;
        }
    }
}
