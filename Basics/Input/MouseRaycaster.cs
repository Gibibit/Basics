using UnityEngine;

namespace Basics
{
    public class MouseRaycaster2D : MonoBehaviour
    {
        [SerializeField]
        private LayerMask layerMask = int.MaxValue;
        public int mouseButton = 0;

        void Update()
        {
            if(Input.GetMouseButtonDown(mouseButton))
            {
                var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                var hits = Physics2D.OverlapPointAll(mousePos, layerMask.value);
                foreach(var hit in hits)
                {
                    IMouseHandler handler = hit.GetComponent<IMouseHandler>();
                    if(handler != null)
                    {
                        handler?.OnMouseClick(mouseButton);
                        break;
                    }
                }
            }
        }
    }
}