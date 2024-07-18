using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundAudio : MonoBehaviour
{
    private int index = 0;
    [SerializeField] private List<AudioSource> Sources;

    private void LateUpdate()
    {
        if (index > Sources.Count - 1)
        {
            index = 0;
        }
        if (!Sources[index].isPlaying)
        {
            Sources[index].Play();
            index++;
        }
    }
}
