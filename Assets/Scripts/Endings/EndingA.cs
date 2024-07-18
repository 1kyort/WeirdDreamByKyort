using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EndingA : MonoBehaviour
{
    [SerializeField] private List<string> Lines;
    [SerializeField] private Transform popUpPos;
    [SerializeField] private Transform popUpPos2;

    public int TriesAmount = 0;
    [SerializeField] private GameObject PopUpText;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (TriesAmount >= Lines.Count) return;
        if (collision.gameObject.CompareTag("Player"))
        {
            Vector3 pos = collision.gameObject.transform.position;
            pos.x += 30;

            GameObject obj = Instantiate(PopUpText);
            obj.transform.GetChild(0).gameObject.GetComponent<TMP_Text>().text = Lines[TriesAmount];
            if (TriesAmount < Lines.Count - 1)
            {
                obj.transform.position = popUpPos.position;
                TriesAmount++;
                collision.gameObject.transform.position = pos;
            }
            else
            {
                obj.transform.position = popUpPos2.position;
                TriesAmount++;
            }

        }
    }
    
}
