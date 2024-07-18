using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Mess : MonoBehaviour
{
    private GameObject Player;
    private bool isPlayerDetected;
    [SerializeField] private GameObject TipPrefab;
    [SerializeField] private GameObject PopUpText;

    [SerializeField] private List<string> Lines;

    [SerializeField] private GameObject Gun;
    [SerializeField] private GameObject GunTrigger;
    [HideInInspector]public GameObject Tip;
    [SerializeField] private GameObject Wall;

    private void Start()
    {
        Tip = Instantiate(TipPrefab);
        Vector3 pos = transform.position;
        pos.y += 3.6f;
        pos.x -= 1;
        Tip.transform.position = pos;
    }
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
            isPlayerDetected = true;
        }
    }

    private void LateUpdate()
    {
        if (isPlayerDetected)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Player.transform.GetChild(0).GetChild(0).GetChild(1).gameObject.SetActive(true);

                StartCoroutine(CreateMessage(Lines, 0));

                Destroy(Tip);

                gameObject.GetComponent<BoxCollider2D>().enabled = false;
                gameObject.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().enabled = false;
                Wall.SetActive(true);
                Gun.SetActive(false);
                GunTrigger.SetActive(false);
            }
        }
    }
    private IEnumerator CreateMessage(List<string> list, int index)
    {
        
        GameObject obj = Instantiate(PopUpText);

        Vector3 pos = Player.transform.position;
        pos.y += 1.8f;

        obj.transform.position = pos;

        obj.transform.GetChild(0).gameObject.GetComponent<TMP_Text>().text = Lines[index];

        yield return new WaitForSeconds(1.5f);
        if (index < list.Count - 1)
        {
            StartCoroutine(CreateMessage(list, index + 1));
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
}
