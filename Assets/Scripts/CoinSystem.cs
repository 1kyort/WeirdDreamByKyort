using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinSystem : MonoBehaviour
{
    public int AmountCollected = 0;
    [SerializeField] private TMP_Text uitext;

    private void Start()
    {
        CoinSystemStatic.System = this;
    }
    private void LateUpdate()
    {
        uitext.text = AmountCollected.ToString() + " / 15";
    }
}
public static class CoinSystemStatic
{
    public static CoinSystem System;
}
