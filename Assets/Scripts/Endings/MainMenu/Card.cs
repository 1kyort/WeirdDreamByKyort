using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Card : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    private bool isHovered;
    [SerializeField] private GameObject bigCard;
    public string Description;
    [SerializeField] private TMP_Text text;

    [SerializeField] private int HowerIndex = 0;
    [SerializeField] private int ClickIndex = 0;
    [SerializeField] private AudioManager audioManager;

    public void OnPointerClick(PointerEventData eventData)
    {
        bigCard.transform.GetChild(0).gameObject.GetComponent<Image>().sprite = gameObject.GetComponent<Image>().sprite;
        text.text = Description;

        audioManager.PlaySound(ClickIndex);

        bigCard.SetActive(true);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        audioManager.PlaySound(HowerIndex);
        isHovered = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isHovered=false;
    }
    private void LateUpdate()
    {
        if (isHovered) 
        {
            if (transform.localScale.x < 1)
            {
                transform.localScale += Vector3.one * Time.deltaTime;
            }

        }
        else
        {
            if (transform.localScale.x > 0.66412f)
            {
                transform.localScale -= Vector3.one * Time.deltaTime;
            }
        }
    }
}
