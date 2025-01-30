using TMPro;

using UnityEngine;

namespace Basics
{
    public class TMPHelper : MonoBehaviour
    {
        private TMP_Text text;

        public Color normalColor = Color.white;
        public Color disabledColor = Color.gray;

        private void Awake()
        {
            text = GetComponent<TMP_Text>();
        }

        public void SetDisabledColor()
        {
            text.color = disabledColor;
        }

        public void SetNormalColor()
        {
            text.color = normalColor;
        }
    }
}
