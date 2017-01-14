using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerController))]
public class Player : MonoBehaviour
{
    public Vector2 mousePos; //Posição do mouse
    private PlayerController controller; //Controller do gameObject do jogador
	// Use this for initialization
	void Start ()
    {
        controller = GetComponent<PlayerController>(); //controller da variavel é o controller do GameObject
	}

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0) && controller.inTransit == false)
        {
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            StartCoroutine(controller.MoveTo(mousePos));
        }
        else if (Input.GetMouseButtonUp(0) && controller.inTransit == true)
        {
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            controller.StopAllCoroutines();
            controller.StartCoroutine(controller.MoveTo(mousePos));
        }
    }
}
