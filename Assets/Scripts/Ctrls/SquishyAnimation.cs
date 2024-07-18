using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class SquishyAnimation : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioSource audioSource1;
    [SerializeField] private AudioSource audioSource2;
    [SerializeField] private Rigidbody2D rb;
    private bool _isGrounded;
    public bool IsGrounded
    {
        get
        {
            return _isGrounded;
        }
        set
        {
            if (value != _isGrounded)
            {
                switch (value)
                {
                    case true:
                        _isGrounded = true;
                        animator.SetBool("isSquished", true);
                        Invoke("ResetValueSQ", 0.1f);
                        audioSource2.Play();
                        break;
                    default:
                        _isGrounded = false;
                        animator.SetBool("isUnsquished", true);
                        Invoke("ResetValueUNSQ", 0.1f);
                        
                        break;
                }
            }
        }
    }
    private void ResetValueSQ() => animator.SetBool("isSquished", false);
    private void ResetValueUNSQ() => animator.SetBool("isUnsquished", false);

    private void LateUpdate()
    {
        RaycastHit2D hit = Groundcheck();

        if (hit.collider != null && hit.distance <= 1.5f)
        {
            IsGrounded = true;
        }
        else
        {
            IsGrounded=false;
        }
        if (IsGrounded && rb.velocity.magnitude > 0)
        {
            if (!audioSource.isPlaying)
            {
                audioSource.volume = Random.Range(0.01f, 0.015f);
                audioSource.Play();
            } 
        }
        else
        {
            audioSource.Stop();
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            audioSource1.Play();
        }

    }
    private RaycastHit2D Groundcheck()
    {
        RaycastHit2D Hit = Physics2D.Raycast(transform.position,transform.up * -1, 3f, ~LayerMask.GetMask("Player"));
        Debug.DrawRay(transform.position, (transform.up * -1) * 1.5f, Color.red);
        return Hit;
    }
    
}
