using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5;
    private PlayerAnimator animator;
    private bool reached;
    public bool inTransit;
    IEnumerator Moving(Vector3 target)
    {
        animator = GetComponent<PlayerAnimator>();
        animator.WalkCycle(transform.position, target);
        reached = false;
        while (reached == false)
        {
            transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
            inTransit = true;


            if (transform.position.x > 7.5f&&DialogueController.instance.firstTry==false)
            {
                StopAllCoroutines();
                animator.StopWalk();
                DialogueController.instance.StartCoroutine(DialogueController.instance.PlayDialogue(DialogueController.instance.guardDialogue.introDialogue));
                DialogueController.instance.firstTry = true;
            }

            yield return null;
        }
    }

    public IEnumerator MoveTo(Vector2 target)
    {
        StartCoroutine(Moving(target));
        yield return new WaitUntil(() => transform.position == new Vector3(target.x,target.y));
        reached = true;
        inTransit = false;
        animator.StopWalk();
        StopAllCoroutines();

        yield return null;
    }

}
