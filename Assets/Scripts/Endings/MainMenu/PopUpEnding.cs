using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopUpEnding : MonoBehaviour
{
    public int index = 0;
    public List<Transform> Positions;
    [SerializeField] private GameObject Explosion;
    public string Description;

    //0.3446083f
    private float Delay = 0;


    private void LateUpdate()
    {
        if (Delay < 1f)
        {
            Delay += Time.deltaTime;
            return;
        }
        if (transform.GetChild(0).localScale.x > 0.36f)
        {
            transform.GetChild(0).localScale -= (Vector3.one * Time.deltaTime) * 5f;
        }
        else
        {
            Positions[index].gameObject.GetComponent<Image>().sprite = transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite;
            Positions[index].gameObject.GetComponent<Card>().Description = Description;
            GameObject obj = Instantiate(Explosion);
            obj.transform.position = transform.position;
            Destroy(gameObject);
        }
        
    }
}
