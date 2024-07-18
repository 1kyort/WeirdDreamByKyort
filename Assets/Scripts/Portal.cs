using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    [SerializeField] private Transform SendToPos;
    public enum TypeOfPortal
    {
        Reciver,
        Sender
    }
    public TypeOfPortal typeOfPortal;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag("Player")) return;
        switch (typeOfPortal)
        {
            case TypeOfPortal.Reciver:
                break;
            case TypeOfPortal.Sender:
                collision.gameObject.transform.position = SendToPos.position;
                break;
            default:
                break;
        }
    }
    
    
}
