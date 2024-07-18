using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Campfire : MonoBehaviour
{
    [SerializeField] private List<string> Lines;

    [SerializeField] private GameObject PopUpText;

    [SerializeField] private GameObject InteractText;
    private bool PlayerDetected;

    [SerializeField] private GameObject BonfireLitUi;
    private void Start()
    {
        StartCoroutine(displayLines());
    }

    private IEnumerator displayLines()
    {
        yield return new WaitForSeconds(10);

        GameObject obj = Instantiate(PopUpText);

        obj.transform.GetChild(0).gameObject.GetComponent<TMP_Text>().text = Lines[Random.Range(0, Lines.Count)];
        Vector3 pos = transform.position;
        pos.y += 1.5f;

        obj.transform.position = pos;

        StartCoroutine(displayLines());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerDetected = true;
            InteractText.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerDetected = false;
            InteractText.SetActive(false);
        }
    }

    private void LateUpdate()
    {
        if (!PlayerDetected) return;

        if (Input.GetKeyDown(KeyCode.E))
        {
            BonfireLitUi.SetActive(true);
            StaticEndings.Save.endings[7].isCompleted = true;
            Invoke("LoadScene", 1f);
        }
    }

    private void LoadScene()
    {
        
        SceneManager.LoadScene(0);
    }
}
