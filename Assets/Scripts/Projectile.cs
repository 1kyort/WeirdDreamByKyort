using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private Transform Aim;
    public GameObject Explosion;

    private Vector3 pos;
    [SerializeField] private float Speed = 5f;
    private void LateUpdate()
    {
        pos = transform.position;
        pos += (Aim.position - transform.position) * Time.deltaTime * Speed;

        transform.position = pos;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject obj = Instantiate(Explosion);
        obj.transform.position = transform.position;
        Destroy(gameObject);
        if (collision.gameObject.CompareTag("PineApple"))
        {
            Debug.Log("PineApple Hurt");

            

            Vector3 scale = collision.transform.GetChild(1).localScale;
            scale.x -= 1f;

            collision.transform.GetChild(1).localScale = scale;
            if (scale.x <= 0)
            {
                //Destroy(collision.gameObject);
                GameObject objj = Instantiate(Explosion);
                objj.transform.localScale = objj.transform.localScale * 2;
                objj.transform.position = collision.transform.position;
            }
        }
    }
    private void Start()
    {
        Invoke("destroyMyself", 15f);
    }

    private void destroyMyself()
    {
        Destroy(gameObject);
    }
}
