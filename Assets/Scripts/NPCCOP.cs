using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCCOP : MonoBehaviour
{
    public void PlaySecondPart()
    {
        DialogueController.instance.StartCoroutine(DialogueController.instance.PlayDialogue(DialogueController.instance.guardDialogue.scanFailDialgoue));
    }
    public void PlayAnimation()
    {
        GetComponent<Animator>().SetBool("Scanning", true);
    }
    public void StopCoroutine()
    {
        GetComponent<Animator>().SetBool("Scanning", false);
    }
}
