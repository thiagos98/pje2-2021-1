using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bolinha : MonoBehaviour
{
    public float speed;
    private Vector3 _position = Vector3.zero;
    private Rigidbody _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        _position.x = Input.GetAxis("Horizontal") * speed;
        _position.z = Input.GetAxis("Vertical") * speed;
    }

    private void FixedUpdate()
    {
        _rb.MovePosition(_rb.position + _position * (Time.deltaTime * speed));
    }
}
