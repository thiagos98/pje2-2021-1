using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Win : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        other.TryGetComponent(out BolinhaFisica  ball);
        ball.rb.velocity = Vector3.zero;
        ball.rb.angularVelocity = Vector3.zero;
        ball.CanMove = false;
            
            
        Debug.Log("victory");
    }
}
