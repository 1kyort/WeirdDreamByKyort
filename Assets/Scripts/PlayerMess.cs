using TMPro;
using UnityEngine;

public class PlayerMess : MonoBehaviour
{
    [SerializeField] private GameObject popUpMessage;

    private void LateUpdate()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            GameObject obj = Instantiate(popUpMessage);
            obj.transform.GetChild(0).GetComponent<TMP_Text>().text = "You can't drop your thoughts";
            obj.transform.position = transform.position;
        }
    }
}
