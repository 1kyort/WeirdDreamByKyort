using UnityEngine;
using UnityEngine.SceneManagement;

public class CompleteEndingTrigger : MonoBehaviour
{
    [SerializeField] private int Index = 0;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StaticEndings.Save.endings[Index].isCompleted = true;
            Invoke("LoadScene",2f);
        }
    }
    private void LoadScene()
    {
        SceneManager.LoadScene(0);
    }
}
