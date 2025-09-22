using Basics;

using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Collider or trigger that deals out hits to Hurtboxes
/// </summary>
public class Hitbox2D : MonoBehaviour
{
    [TagSelector, SerializeField]
    private string _targetTag;
    public bool canHitTerrain;
    public UnityEvent<GameObject> hit;
    public UnityEvent<GameObject> continuousHit;

    private TagHandle? _tagHandle;

    private void Awake()
    {
        if(!string.IsNullOrEmpty(_targetTag))
        {
            _tagHandle = TagHandle.GetExistingTag(_targetTag);
        }
    }

#if UNITY_EDITOR
    private void OnValidate()
    {
        if(gameObject.layer != LayerMask.NameToLayer("Hitbox"))
        {
            Debug.LogError("Hitbox is not in the correct layer", this);
        }
    }
#endif

    public void SetTargetTag(TagHandle? handle)
    {
        _tagHandle = handle;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(!_tagHandle.HasValue || other.CompareTag(_tagHandle.Value))
        {
            Hurtbox hurtbox = other.GetComponent<Hurtbox>();
            hurtbox.hit.Invoke(gameObject);
            hit.Invoke(other.gameObject);
        }

        if(canHitTerrain && other.CompareTag("Terrain"))
        {
            hit?.Invoke(other.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(string.IsNullOrEmpty(_targetTag) || collision.gameObject.CompareTag(_tagHandle.Value))
        {
            Hurtbox hurtbox = collision.gameObject.GetComponent<Hurtbox>();
            hurtbox.hit.Invoke(gameObject);
            hit.Invoke(collision.gameObject);
        }

        if(canHitTerrain && collision.gameObject.CompareTag("Terrain"))
        {
            hit?.Invoke(collision.gameObject);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(string.IsNullOrEmpty(_targetTag) || collision.gameObject.CompareTag(_tagHandle.Value))
        {
            Hurtbox hurtbox = collision.gameObject.GetComponent<Hurtbox>();
            hurtbox.continuousHit.Invoke(gameObject);
            continuousHit.Invoke(collision.gameObject);
        }

        if(canHitTerrain && collision.gameObject.CompareTag("Terrain"))
        {
            continuousHit?.Invoke(collision.gameObject);
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if(string.IsNullOrEmpty(_targetTag) || collision.gameObject.CompareTag(_tagHandle.Value))
        {
            Hurtbox hurtbox = collision.gameObject.GetComponent<Hurtbox>();
            hurtbox.continuousHit.Invoke(gameObject);
            continuousHit.Invoke(collision.gameObject);
        }

        if(canHitTerrain && collision.gameObject.CompareTag("Terrain"))
        {
            continuousHit?.Invoke(collision.gameObject);
        }
    }
}
