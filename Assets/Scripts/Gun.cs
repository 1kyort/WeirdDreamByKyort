
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private GameObject Tip;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private GameObject InteractCollider;

    public GameObject InstTip;

    private bool isTipCreated = false;
    public bool isChecking = false;

    private void LateUpdate()
    {
        if (!isChecking) return;
        if (rb.velocity.magnitude <= 0.01f)
        {

            rb.bodyType = RigidbodyType2D.Kinematic;
            if (!isTipCreated)
            {
                isTipCreated = true;



                InstTip = Instantiate(Tip);

                Vector3 pos = transform.position;
                pos.y += 3;
                InstTip.transform.position = pos;
            }
            
        }
    }
}
