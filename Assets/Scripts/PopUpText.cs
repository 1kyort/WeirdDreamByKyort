using TMPro;
using UnityEngine;

public class PopUpText : MonoBehaviour
{
    [SerializeField]private TMP_Text m_Text;
    private void Update()
    {
        Vector3 pos = transform.position;

        pos.y += Time.deltaTime * 2;
        transform.position = pos;

        Color color = m_Text.color;
        color.a -= Time.deltaTime / 2;
        m_Text.color = color;

        if (color.a <= 0)
        {
            Destroy(gameObject);
        }
    }
}
