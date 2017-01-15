using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour

{
    Animator playerAnimator;
	// Use this for initialization
	void Start ()
    {
        playerAnimator = GetComponent<Animator>();
	}
	

    public void WalkCycle(Vector3 currPos, Vector3 nextPos)
    {
        if (currPos.x < nextPos.x)
        {
            playerAnimator.SetBool("isWalking", true);
            playerAnimator.SetBool("isFacingRight", true);
        }
        else if (currPos.x > nextPos.x)
        {
            playerAnimator.SetBool("isWalking", true);
            playerAnimator.SetBool("isFacingRight", false);
        }
    }
    public void StopWalk()
    {
        playerAnimator.SetBool("isWalking", false);
    }

}
