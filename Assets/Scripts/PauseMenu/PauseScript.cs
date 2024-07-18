using TarodevController;
using UnityEngine;

public class PauseScript : MonoBehaviour
{
    [SerializeField] private GameObject PauseMenu;
    [SerializeField] private GameObject Player;


    private Rigidbody2D rb;
    private PlayerController controller;
    private void Start()
    {
        rb = Player.GetComponent<Rigidbody2D>();
        controller = Player.GetComponent<PlayerController>();

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    private void LateUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(!PauseMenu.activeInHierarchy)
            {
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;

                PauseMenu.SetActive(true);
                controller.enabled = false;
                rb.simulated = false;
            }
            else
            {
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;

                PauseMenu.SetActive(false);
                controller.enabled = true;
                rb.simulated= true;
            }
        }
    }
}
