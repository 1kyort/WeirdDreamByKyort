using TarodevController;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class PauseButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    [SerializeField] private SaveLoadData _saveLoadData;
    private bool isHovered = false;
    [SerializeField] private PlayerController playerController;
    [SerializeField] private Rigidbody2D rb;
    public void OnPointerClick(PointerEventData eventData)
    {
        switch (gameObject.name)
        {
            case "Continue":
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;

                rb.simulated = true;
                playerController.enabled = true;
                transform.parent.gameObject.SetActive(false);
                break;
            case "MainMenu":
                SceneManager.LoadScene(0);
                break;
            case "Exit":
                _saveLoadData.SaveToJson();
                Invoke("ExitGame", 0.5f);
                break;
            default:
                break;
        }
    }
    private void ExitGame()
    {
        Application.Quit();
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        isHovered = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isHovered = false;
    }
    private void LateUpdate()
    {
        if (isHovered)
        {
            if (transform.localScale.x < 1.2f)
            {
                transform.localScale += Vector3.one * Time.deltaTime * 5f;
            }

        }
        else
        {
            if (transform.localScale.x > 1)
            {
                transform.localScale -= Vector3.one * Time.deltaTime * 5f;
            }
        }
    }
}
