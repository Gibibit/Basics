using TMPro;

using UnityEngine;

namespace Basics
{
    public class TMP_TextLoader : MonoBehaviour
    {
        public TextObject textObject;

        private TMP_Text _tmp;

        void Start()
        {
            _tmp = GetComponent<TMP_Text>();
            _tmp.text = textObject.text;
        }
    }
}