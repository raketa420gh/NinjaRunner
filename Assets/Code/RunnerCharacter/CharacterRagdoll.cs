using UnityEngine;

public class CharacterRagdoll : MonoBehaviour
{
    [SerializeField] private Rigidbody[] rigidBodies;
    [SerializeField] private Animator animator;

    public void ToggleRagdoll(bool isActive)
    {
        animator.enabled = !isActive;
        ActivateBonesDynamic(isActive);
    }

    private void ActivateBonesDynamic(bool isActive)
    {
        foreach (var rigidbody in rigidBodies)
            rigidbody.isKinematic = !isActive;
    }
}