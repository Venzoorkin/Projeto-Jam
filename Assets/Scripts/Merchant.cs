using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Merchant : MonoBehaviour
{
    public bool talkedToGuard;

    public event System.Action clickedOnMerchant;
    public void OnMouseUpAsButton()
    {
        clickedOnMerchant();
    }
}
