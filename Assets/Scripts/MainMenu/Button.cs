using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    private TMP_Text m_Text;

    [SerializeField] private int SoundIndexHowered = 0 ;
    [SerializeField] private int SoundIndexClicked = 1;
    [SerializeField] private AudioManager m_AudioManager;

    [SerializeField] private Color ColorIdle; 
    [SerializeField] private Color ColorHowered; 
    [SerializeField] private Color ColorClicked;
    public SaveLoadData SaveLoadSystem;

    private void Start()
    {
        m_Text = GetComponent<TMP_Text>();
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        m_Text.color = ColorClicked;

        m_AudioManager.PlaySound(SoundIndexClicked);

        Invoke("ResetColor", 0.2f);

        if (gameObject.name == "Play")
        {
            SceneManager.LoadScene(1);
        }
        else if(gameObject.name == "Exit")
        {
            SaveLoadSystem.SaveToJson();
            Invoke("ExitGame", 2f);
        }
        else
        {
            SaveLoadSystem.DeleteSave();
            SceneManager.LoadScene(0);
        }
    }
    private void ExitGame()
    {
        Application.Quit();
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        m_AudioManager.PlaySound(SoundIndexHowered);
        m_Text.color = ColorHowered;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        m_Text.color = ColorIdle;
    }

    private void ResetColor()
    {
        m_Text.color = ColorIdle;
    }
}
