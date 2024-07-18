using UnityEngine;

public class RestartTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.transform.position = new Vector3(-39f, -3, 0);
        }
    }
}
