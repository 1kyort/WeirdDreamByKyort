using TMPro;
using UnityEngine;

public class PineAppleTrigger : MonoBehaviour
{
    public GameObject PineApple;
    public GameObject PopUpText;
    public GameObject Wall;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Wall.SetActive(true);

            PineApple.SetActive(true);
            PineApple.transform.position = new Vector3(324.309998f, -87.5500031f, 0);

            GameObject obj = Instantiate(PopUpText);
            obj.transform.GetChild(0).gameObject.GetComponent<TMP_Text>().text = "IT'S TIME TO SHINE";
            obj.transform.position = transform.position;

            Invoke("createText", 2f);



            gameObject.SetActive(false);
        }
    }
    private void createText()
    {
        GameObject obj = Instantiate(PopUpText);
        obj.transform.GetChild(0).gameObject.GetComponent<TMP_Text>().text = "KILL THE PINEAPPLE";
        obj.transform.position = transform.position;
    }
}
