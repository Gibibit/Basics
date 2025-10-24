using UnityEngine;

namespace Basics
{
    public class SpriteProgressBar : MonoBehaviour
    {
        [SerializeField] private GameObject fill;
        [SerializeField] private GameObject background;

        private float barWidth;
        private float barHeight;

        private void Awake()
        {
            barWidth = background.transform.localScale.x;
            barHeight = background.transform.localScale.y;
        }

        public void SetProgress(float factor)
        {
            fill.transform.localScale = new Vector3(factor*barWidth, barHeight, 1);
            fill.transform.localPosition = new Vector3(barWidth*factor*0.5f - barWidth*0.5f, 0f, 0f);
        }

        public void SetFillColor(Color color)
        {
            fill.GetComponent<SpriteRenderer>().color = color;
        }

        public void SetBackgroundColor(Color color)
        {
            background.GetComponent<SpriteRenderer>().color = color;
        }
    }
}
