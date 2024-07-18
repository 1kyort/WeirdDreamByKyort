using UnityEngine;

public class PineAppleObject : MonoBehaviour
{
    public Transform FollowPos;


    private void LateUpdate()
    {
        Vector3 dir = Vector3.MoveTowards(transform.position, FollowPos.position, 9 * Time.deltaTime);

        transform.position = dir;
    }
}
