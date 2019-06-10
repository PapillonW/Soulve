using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightMenuAnimationContol : MonoBehaviour
{
    public Animator animator;

    int tickCount;

    public void ControlRightMenu()
    {
        animator.SetBool("TickRight", true);
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
