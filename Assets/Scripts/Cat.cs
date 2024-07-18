using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cat : MonoBehaviour
{
    [SerializeField] private GameObject PopUpText;

    [SerializeField] private List<string> Lines;

    [SerializeField] private GameObject Explosion;
    [SerializeField] private AudioSource source;

    private void Start()
    {
        StartCoroutine(DisplayLine());
    }

    private IEnumerator DisplayLine()
    {
        yield return new WaitForSeconds(10f);
        GameObject obj = Instantiate (PopUpText);

        Vector3 pos = transform.position;
        pos.y += 2f;

        obj.transform.position = pos;
        obj.transform.GetChild(0).gameObject.GetComponent<TMP_Text>().text = Lines[Random.Range(0, Lines.Count)];
        source.Play();
        StartCoroutine(DisplayLine());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PineApple"))
        {
            GameObject obj = Instantiate(Explosion);
            obj.transform.position = collision.transform.position;

            Destroy(collision.gameObject);


            GameObject obj2 = Instantiate(PopUpText);

            Vector3 pos = transform.position;
            pos.y += 2f;

            obj2.transform.position = pos;
            obj2.transform.GetChild(0).gameObject.GetComponent<TMP_Text>().text = "Thank you ^_^";

            StaticEndings.Save.endings[6].isCompleted = true;

            Invoke("LoadScene", 1f);
        }
    }
    private void LoadScene()
    {
        SceneManager.LoadScene(0);
    }
}
