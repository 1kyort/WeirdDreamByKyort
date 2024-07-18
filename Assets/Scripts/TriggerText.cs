using TMPro;
using UnityEngine;

public class TriggerText : MonoBehaviour
{
    [SerializeField] private GameObject PopUpText;
    [SerializeField] private string Text;
    [SerializeField] private Transform popUpPos;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameObject obj = Instantiate(PopUpText);
            obj.transform.GetChild(0).GetComponent<TMP_Text>().text = Text;
            obj.transform.position = popUpPos.position;
            Debug.Log(123);
        }
    }
}
