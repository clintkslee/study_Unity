using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationPlayerController : MonoBehaviour
{
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            animator.SetTrigger("IsDie");
            
    }

    public void OnDieEvent()
    {
        Debug.Log("End of Die Animation");
    }
}

