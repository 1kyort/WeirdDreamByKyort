using UnityEngine;

public class GunTrigger : MonoBehaviour
{
    public GameObject Gun;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Gun.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;

            Invoke("StartCheck", 1f);

            gameObject.SetActive(false);
        }
    }
    private void StartCheck()
    {
        Gun.GetComponent<Gun>().isChecking = true;
    } 
}
