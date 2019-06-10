using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftMenuAnimationControl : MonoBehaviour
{
    public Animator animator;

    int tickCount;

    public void ControlLeftMenu()
    {
        animator.SetBool("TickLeft", true);
        tickCount++;

        if (tickCount == 1)
        {
            animator.SetFloat("Aspect", 1f);       
        }
        else if (tickCount == 2)
        {
            animator.SetFloat("Aspect", -1f);
            tickCount = 0;
        }
    }
}
