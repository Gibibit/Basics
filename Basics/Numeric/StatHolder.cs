using System;

using UnityEngine;

[CreateAssetMenu]
public class StatHolder : ScriptableObject
{
    public Stat[] Stats;

    [Serializable]
    public struct Stat
    {
        public string Name;
        public float StartingValue;
    }
}
