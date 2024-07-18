using UnityEngine;

public class SoundDrop : MonoBehaviour
{
    public AudioSource m_AudioSource;
    public AudioClip m_Clip;
    public float Volume = 1f;

    private void Start()
    {
        m_AudioSource.clip = m_Clip;
        m_AudioSource.volume = Volume;
        m_AudioSource.Play();
    }
    private void LateUpdate()
    {
        if (!m_AudioSource.isPlaying)
        {
            Destroy(gameObject);
        }
    }
}
