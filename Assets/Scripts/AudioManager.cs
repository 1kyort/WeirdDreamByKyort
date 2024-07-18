using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private List<AudioSource> Sources;
    
    public void PlaySound(int index)
    {
        Sources[index].Play();
    }
}
