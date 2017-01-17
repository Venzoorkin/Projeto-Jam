using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerController))]
public class Player : MonoBehaviour
{
    bool firstClick;
    public Vector2 mousePos; //Posição do mouse
    private PlayerController controller; //Controller do gameObject do jogador
	// Use this for initialization
	void Start ()
    {
        firstClick = false;
        FindObjectOfType<WalkableArea>().MouseUpFromWalkableArea += StartMove;
        ItemController.instance.currentInventory.AddItem(ItemController.instance.allItemsType[3]);
        ItemController.instance.currentInventory.AddItem(ItemController.instance.allItemsType[6]);
        ItemController.instance.currentInventory.AddItem(ItemController.instance.allItemsType[4]);
        ItemController.instance.currentInventory.AddItem(ItemController.instance.allItemsType[5]);

        controller = GetComponent<PlayerController>(); //controller da variavel é o controller do GameObject
	}

    // Update is called once per frame
   public void StartMove()
    {
        if (controller.inTransit == false)
        {
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            StartCoroutine(controller.MoveTo(mousePos));
            if (firstClick == false)
            {
                DialogueController.instance.StartCoroutine(DialogueController.instance.PlayDialogue(DialogueController.instance.playerDialogue.introDialogue));
                firstClick = true;
                controller.StopAllCoroutines();
                GetComponent<Animator>().SetBool("isWalking", false);
            }
        }
        else if (controller.inTransit == true)
        {
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            controller.StopAllCoroutines();
            controller.StartCoroutine(controller.MoveTo(mousePos));
        }
    }


}
