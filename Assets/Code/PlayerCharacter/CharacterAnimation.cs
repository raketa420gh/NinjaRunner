using UnityEngine;

public class CharacterAnimation : MonoBehaviour
{
    [SerializeField] private Animator animator;

    public void ActivateAnimationTrigger(string triggerName)
    {
        animator.SetTrigger(triggerName);
    }
}
