using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Basics
{
    [RequireComponent(typeof(Button))]
    public class ButtonInteractable : MonoBehaviour
    {
        public UnityEvent<bool> interactableChanged;
        public UnityEvent interactableEnabled;
        public UnityEvent interactableDisabled;

        private Button button;

        private void Awake()
        {
            button = GetComponent<Button>();
        }

        public void DisableInteractable()
        {
            if(button.interactable)
            {
                button.interactable = false;
                interactableChanged?.Invoke(false);
                interactableDisabled?.Invoke();
            }
        }

        public void EnableInteractable()
        {
            if(!button.interactable)
            {
                button.interactable = true;
                interactableChanged?.Invoke(true);
                interactableEnabled?.Invoke();
            }
        }
    }
}
