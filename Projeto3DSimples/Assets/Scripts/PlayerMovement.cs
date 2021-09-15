using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    private Vector3 position = Vector3.zero;

    private void Update()
    {
        position.x = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        position.z = Input.GetAxis("Vertical") * Time.deltaTime * speed;

        transform.Translate(position);
    }
}
