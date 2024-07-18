using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BigCard : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    private bool isHovered;
    [SerializeField] private GameObject Object;
    [SerializeField] private GameObject MySprite;
    [SerializeField] private Sprite img;
    [SerializeField] private TMP_Text text;

    [SerializeField] private int ClickSoundIndex = 1;
    [SerializeField] private AudioManager audioManager;

    public void OnPointerClick(PointerEventData eventData)
    {
        MySprite.GetComponent<Image>().sprite = img;
        text.text = "You didn't open this Ending";
        transform.parent.localScale = new Vector3(11, 11, 11);

        audioManager.PlaySound(ClickSoundIndex);

        Object.SetActive(false);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        isHovered = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isHovered= false;
    }
    private void LateUpdate()
    {
        if (isHovered)
        {
            if (transform.parent.localScale.x < 12)
            {
                transform.parent.localScale += Vector3.one * Time.deltaTime * 5f;
            }

        }
        else
        {
            if (transform.parent.localScale.x > 11)
            {
                transform.parent.localScale -= Vector3.one * Time.deltaTime * 5f;
            }
        }
    }
}
