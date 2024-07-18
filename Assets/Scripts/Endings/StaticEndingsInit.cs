using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticEndingsInit : MonoBehaviour
{
    [SerializeField] private CompletedEndings Save;

    private void Start()
    {
        
        //for (int i = 0; i < Save.endings.Count; i++)
        //{
        //    Save.endings[i].isCompleted = false;
        //}
        StaticEndings.Save = Save;
    }
}
