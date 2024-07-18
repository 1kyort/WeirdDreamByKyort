using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SaveFile")]
public class CompletedEndings : ScriptableObject
{
    public List<Endings> endings;

    
    
}
[System.Serializable]
public class Endings
{
    public string Name;
    public Sprite Sprite;
    public bool isCompleted;
}
