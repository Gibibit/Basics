using TMPro;

using UnityEngine;
using UnityEngine.UI;

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

            Button button = GetComponentInParent<Button>();
            if(button && !button.interactable)
            {
                SetDisabledColor();
            }
            else
            {
                SetNormalColor();
            }
        }

        public void SetDisabledColor()
        {
            text.color = disabledColor;
        }

        public void SetNormalColor()
        {
            text.color = normalColor;
        }

        private void OnValidate()
        {
            text = GetComponent<TMP_Text>();

            Button button = GetComponentInParent<Button>();
            if(button && !button.interactable)
            {
                SetDisabledColor();
            }
            else
            {
                SetNormalColor();
            }
        }
    }
}
