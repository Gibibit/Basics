using System.Collections;

using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class FadeAfterTime : MonoBehaviour
{
    public float lifetime = 1f;
    public float fadeDuration = 1f;

    private SpriteRenderer sprite;

    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        StartCoroutine(DestroyRoutine());
    }


    IEnumerator DestroyRoutine()
    {
        yield return new WaitForSeconds(lifetime);

        float start = Time.time;
        while (Time.time < start + fadeDuration)
        {
            float t = (Time.time - start) / fadeDuration;
            sprite.color = new Color(1, 1, 1, 1 - t);
            yield return null;
        }

        Destroy(gameObject);
    }
}
