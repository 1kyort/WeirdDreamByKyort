using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PineApple : MonoBehaviour
{
    public GameObject PopUpText;
    public GameObject ActivationTrigger;

    private Collider2D collider = null;
    [SerializeField] private Transform HealthBar;

    private bool Dir = false;

    private void LateUpdate()
    {
        if (!Dir)
        {
            transform.position = transform.position + new Vector3(-1 * Time.deltaTime * 2, 0, 0);
        }
        else
        {
            transform.position = transform.position + new Vector3(Time.deltaTime * 2, 0, 0);
        }

        if (HealthBar.transform.localScale.x <= 0)
        {
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            gameObject.transform.GetChild(0).gameObject.SetActive(false);
            gameObject.transform.GetChild(1).gameObject.SetActive(false);

            StaticEndings.Save.endings[5].isCompleted = true;

            Invoke("LoadScene", 1f);
        }
        
    }
    private void LoadScene()
    {
        SceneManager.LoadScene(0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            Debug.Log("Wall Detected");
            if (Dir)
            {
                Dir = false;
            }
            else
            {
                Dir = true;
            }
        }
        if (collision.gameObject.CompareTag("Player"))
        {
            collider = collision;
            collision.gameObject.transform.position = new Vector3(-39f, -3, 0);

            Invoke("CreatePopUp", 2f);

            ActivationTrigger.SetActive(true);
            gameObject.SetActive(false);
        }
    }
    private void CreatePopUp()
    {
        GameObject obj = Instantiate(PopUpText);
        obj.transform.position = collider.transform.position + Vector3.up * 2f;
        obj.transform.GetChild(0).gameObject.GetComponent<TMP_Text>().text = "How... Did you manage to lose...";
    }
}
