using UnityEngine;
using UnityEngine.SceneManagement;

public class WaitingEnding : MonoBehaviour
{
    private bool isButtonPressed = false;

    private float time = 0;

    private void LateUpdate()
    {
        if (isButtonPressed) return;
        if (Input.anyKeyDown)
        {
            isButtonPressed = true;
        }

        time += Time.deltaTime;

        if (time >= 30)
        {
            StaticEndings.Save.endings[4].isCompleted = true;
            SceneManager.LoadScene(0);
        }
    }
}
