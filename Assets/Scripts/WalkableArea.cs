using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkableArea : MonoBehaviour
{
    public Player currentPlayer;

    public event System.Action MouseUpFromWalkableArea;
    public void OnMouseUpAsButton()
    {
        MouseUpFromWalkableArea();
    }
}
