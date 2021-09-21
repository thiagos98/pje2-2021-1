using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BolinhaFisica : MonoBehaviour
{
    private Rigidbody _rb;
    private float _vertical = 0f;
    private float _horizontal = 0f;
    private bool isJumping;
    public float speed = 2f;
    public float jumpForce = 2f;

    private void Awake()
    {
        TryGetComponent(out _rb);
    }

    private void Update()
    {
        _horizontal = Input.GetAxis("Horizontal");
        _vertical = Input.GetAxis("Vertical");
    }

    private void FixedUpdate()
    {
        _rb.AddForce(0, 0,  speed * _vertical, ForceMode.Force);
        _rb.AddForce(speed * _horizontal, 0,  0, ForceMode.Force);

        if (Input.GetKey(KeyCode.Space) && !isJumping)
        {
            _rb.AddForce(0, jumpForce, 0, ForceMode.Impulse);
        }
    }

    private void OnCollisionStay(Collision other)
    {
        isJumping = false;
    }

    private void OnCollisionExit(Collision other)
    {
        isJumping = true;
    }
}
