using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu]
public class TextsObject : ScriptableObject
{
    [FormerlySerializedAs("text")]
    public string[] texts;
}
