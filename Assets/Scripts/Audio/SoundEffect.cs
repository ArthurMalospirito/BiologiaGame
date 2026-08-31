using System;
using UnityEngine;

[Serializable]
public class SoundEffect
{
    public AudioClip clip;
    [Range(0,1)]public float volume=1;
}
