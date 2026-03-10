using UnityEngine;

public class Transition : Singleton<Transition>
{
    Animator animator;

   public void StartTransition() // doesn't work - Alexander
    {
        animator = GameObject.FindWithTag("Transition").GetComponent<Animator>();
        animator.SetTrigger("Trigger");
    }
}
