using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimCtrls : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Animator animator;

    private void Update()
    {
        float value = Input.GetAxis("Horizontal");

        switch (value)
        {
            case > 0:
                animator.gameObject.transform.localScale = Vector3.one;
                break;
            case < 0:
                animator.gameObject.transform.localScale = new Vector3(-1, 1, 1);
                break;
            default:
                break;
        }

        if (rb.velocity.magnitude > 0)
        {
            animator.SetBool("isMoving", true);
        }
        else
        {
            animator.SetBool("isMoving", false);
        }
    }
}
