using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class CharacterMovement : MonoBehaviour
{
    public event Action OnJump;

    [Header("Speed Settings")] 
    [SerializeField] [Min(0.25f)] private float _moveSpeed;

    [Header("Jump Settings")] 
    [SerializeField] [Min(0.25f)] private float _jumpForce = 1f;
    [SerializeField] private LayerMask _groundMask;
    [SerializeField] [Min(0.1f)] private float _groundDistance = 0.1f;
    [SerializeField] private Transform _groundCheck;

    [Header("Rotate Settings")] 
    [SerializeField] private Transform _body;

    private Rigidbody _rb;

    private void Awake() => 
        _rb = GetComponent<Rigidbody>();

    public void RunForward() => 
        Move(Vector3.forward);

    public void Move(Vector3 direction) => 
        transform.Translate(_moveSpeed * direction * Time.fixedDeltaTime);

    public void Jump()
    {
        if (!IsGrounded())
            return;
        
        _rb.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
        OnJump?.Invoke();
    }

    private bool IsGrounded() => 
        Physics.CheckSphere(_groundCheck.position, _groundDistance, _groundMask);
}