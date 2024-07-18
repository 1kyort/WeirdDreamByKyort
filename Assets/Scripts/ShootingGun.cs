using UnityEngine;

public class ShootingGun : MonoBehaviour
{
    public Transform Aim;
    public GameObject Projectile;
    [SerializeField] private GameObject GunObj;

    private void LateUpdate()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            GameObject obj = Instantiate(Projectile);
            obj.transform.position = Aim.transform.position;

            Vector3 scale = transform.parent.localScale;
            scale.y = 1;
            scale.z = 1;


            obj.transform.localScale = scale;
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            GameObject obj = Instantiate(GunObj);

            Vector3 pos = transform.position;
            pos.y += 2f;
            obj.transform.position = pos;

            obj.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            obj.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 8f, ForceMode2D.Impulse);
            obj.GetComponent<Gun>().isChecking = true;
            gameObject.SetActive(false);
        }
    }
}
