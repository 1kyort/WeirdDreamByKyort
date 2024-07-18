using UnityEngine;

public class MessCollider : MonoBehaviour
{
    [SerializeField] private GameObject Tip;
    [SerializeField] private GameObject PineApple;
    [SerializeField] private GameObject PineAppleObject;
    [SerializeField] private GameObject FollowText;
    [SerializeField] private GameObject PlayerMess;
    [SerializeField] private GameObject Explosion;
    [SerializeField] private GameObject Wall;

    public bool isActivated = false;

    private GameObject Player = null;

    private bool isMessDetected = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Player = collision.gameObject;
            if (collision.transform.GetChild(0).GetChild(0).GetChild(1).gameObject.activeInHierarchy)
            {
                Tip.SetActive(true);
                isMessDetected =true;
            }
        }
    }
    private void LateUpdate()
    {
        if (Player != null)
        {
            if (isActivated) return;
            if (!isMessDetected) return;
            if (Input.GetKeyDown(KeyCode.E))
            {
                isActivated = true;

                PineAppleObject.SetActive(true);
                PineAppleObject.transform.position = PineApple.transform.position;

                PineApple.SetActive(false);

                Tip.SetActive(false);
                PlayerMess.SetActive(false);

                GameObject obj = Instantiate(Explosion);
                obj.transform.position = PlayerMess.transform.position;

                FollowText.SetActive(true);
                Wall.SetActive(false);

                Player = null;
                isActivated = false;
                isMessDetected=true;
            }
        }
    }
}
