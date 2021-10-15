using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BolinhaFisica : MonoBehaviour
{
    [HideInInspector] public Rigidbody rb;
    private float _vertical = 0f;
    private float _horizontal = 0f;
    private bool _isJumping;
    public bool CanMove { get; set; } = false;
    public float speed = 2f;
    public float jumpForce = 2f;
    public Vector3 startPointBall;

    private void Awake()
    {
        TryGetComponent(out rb);
    }

    private void Start()
    {
        startPointBall = transform.position;
    }

    private void Update()
    {
        _horizontal = Input.GetAxis("Horizontal");
        _vertical = Input.GetAxis("Vertical");
    }

    private void FixedUpdate()
    {
        if (!CanMove) return;
        
        rb.AddForce(0, 0,  speed * _vertical, ForceMode.Force);
        rb.AddForce(speed * _horizontal, 0,  0, ForceMode.Force);

        if (Input.GetKey(KeyCode.Space) && !_isJumping)
        {
            rb.AddForce(0, jumpForce, 0, ForceMode.Impulse);
        }
    }

    private void OnCollisionStay(Collision other)
    {
        if(other.gameObject.layer == 6)
            _isJumping = false;
    }

    private void OnCollisionExit(Collision other)
    {
        if(other.gameObject.layer == 6)
            _isJumping = true;
    }
}
