using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogScript : MonoBehaviour
{
    private Animator anim;

    private bool animation_Started;
    private bool animation_Finished;

    private int jumpedTimes;
    private bool jumpLeft = true;

    private string coroutine_Name = "FrogJump";
    // Start is called before the first frame update

    void Awake()
    {
        anim = GetComponent<Animator>();
    }
    void Start()
    {
        StartCoroutine(coroutine_Name);
    }

    void LateUpdate()
    {
        if (animation_Finished && animation_Started) 
        {
            animation_Started = false;

            //transform.parent.position = transform.position;
            //transform.localPosition = Vector3.zero;
        }
    }

    IEnumerator FrogJump()
    {
        yield return new WaitForSeconds(Random.Range(1f, 4f));

        animation_Started = true;
        animation_Finished = false;

        if (jumpLeft)
        {
            anim.Play("FrogJumpLeft");
        }
        else
        {

        }
        StartCoroutine(coroutine_Name);
    }

    void AnimationFinished()
    {
        animation_Finished = true;
        anim.Play("FrogIdleLeft");
    }
}
