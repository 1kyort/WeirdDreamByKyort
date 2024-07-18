using UnityEngine;
using UnityEngine.SceneManagement;

public class Coin : MonoBehaviour
{
    public GameObject ParticleExplosion;
    [SerializeField] private AudioClip clip;
    [SerializeField] private GameObject soundDrop;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            CoinSystemStatic.System.AmountCollected++;
            
            //Doing stuf lol
            GameObject obj = Instantiate(ParticleExplosion);
            obj.transform.position = transform.position;

            GameObject sound = Instantiate(soundDrop);
            sound.transform.position = transform.position;
            sound.GetComponent<SoundDrop>().m_Clip = clip;
            sound.GetComponent<SoundDrop>().Volume = 0.01f;

            if (CoinSystemStatic.System.AmountCollected >= 15f)
            {
                StaticEndings.Save.endings[0].isCompleted = true;
                SceneManager.LoadScene(0);
            }
            Destroy(gameObject);
        }
    }
}
