using System.Collections;

using UnityEngine;

namespace Basics
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class FlashSpriteOpacity : MonoBehaviour
    {
        public bool startActive;
        public bool hideWhenInactive;
        public float alpha = 0.5f;
        public float interval = 0.15f;

        private SpriteRenderer _sr;
        private int _counter;

        private void Start()
        {
            _sr = GetComponent<SpriteRenderer>();
            if(startActive)
            {
                StartFlash();
            }
            else if(hideWhenInactive)
            {
                _sr.enabled = false;
            }
        }

        public void StartFlash()
        {
            if(_flashRoutine != null) return;

            _sr.enabled = true;
            _flashRoutine = StartCoroutine(FlashRoutine());
        }

        public void StopFlash()
        {
            _sr.color = _sr.color.WithAlpha(1f);
            _counter = 0;
            _sr.enabled = !hideWhenInactive;

            StopCoroutine(_flashRoutine);
            _flashRoutine = null;
        }

        private Coroutine _flashRoutine;
        private IEnumerator FlashRoutine()
        {
            while(true)
            {
                _sr.color = _sr.color.WithAlpha(_counter == 0 ? alpha : 1f);
                _counter = (_counter + 1) % 2;
                yield return new WaitForSeconds(interval);
            }
        }
    }
}
