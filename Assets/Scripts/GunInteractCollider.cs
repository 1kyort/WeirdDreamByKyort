using UnityEngine;

public class GunInteractCollider : MonoBehaviour
{
    private bool isPlayerDetected = false;
    GameObject Player;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Player = collision.gameObject;
            isPlayerDetected = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayerDetected = false;
        }
    }

    private void LateUpdate()
    {
        if (!isPlayerDetected) return;

        if (Input.GetKeyDown(KeyCode.E))
        {
            Destroy(transform.root.gameObject.GetComponent<Gun>().InstTip);
            Destroy(transform.root.gameObject);

            Player.transform.GetChild(0).GetChild(0).GetChild(0).gameObject.SetActive(true);
        }
    }
}
