using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5;
    private bool reached;
    public bool inTransit;
    IEnumerator Moving(Vector3 target)
    {
        reached = false;
        while (reached == false)
        {
            transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
            inTransit = true;
            yield return null;
        }
    }

    public IEnumerator MoveTo(Vector2 target)
    {
        StartCoroutine(Moving(target));
        yield return new WaitUntil(() => transform.position == new Vector3(target.x,target.y));
        reached = true;
        inTransit = false;
        StopAllCoroutines();
        yield return null;
    }

}
