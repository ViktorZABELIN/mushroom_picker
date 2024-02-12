using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBeholder : MonoBehaviour
{

    [SerializeField] PlayerMove playerMove;

    [SerializeField] FinshAutoRun FinshAutoRun;

    [SerializeField] Animator animator;

    void Start()
    {
        playerMove.enabled = false;
        FinshAutoRun.enabled = false;
    }

    public void Play()
    {
        playerMove.enabled = true;
    }


    public void PreFinish()
    {
        playerMove.enabled = false;
        FinshAutoRun.enabled = true;
    }

    public void Finish()
    {
        FinshAutoRun.enabled = false;
        Debug.Log("Откл");
        animator.SetTrigger("Dance");
    }

}
