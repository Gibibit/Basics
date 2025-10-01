#if !DISABLE_PHYSICS
using Basics;

using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Collider or trigger that deals out hits to Hurtboxes
/// </summary>
public class Hitbox : MonoBehaviour
{
    [TagSelector, SerializeField]
    private string _targetTag;
    public bool canHitTerrain;
    public UnityEvent<GameObject> hit;

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

    private void OnTriggerEnter(Collider other)
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

    private void OnCollisionEnter(Collision collision)
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
}
#endif