using System;
using System.Collections;
using UnityEngine;

namespace General
{
    public class Arc : MonoBehaviour, IResettable
    {
        public BolinhaFisica ball;
        private void OnCollisionEnter(Collision other)
        {
            if (!other.gameObject.CompareTag("Player")) return;
            other.gameObject.TryGetComponent(out Rigidbody rb);
            if (rb) StartCoroutine(ResetBall(rb));
        }

        public IEnumerator ResetBall(Rigidbody rb)
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        
            yield return new WaitForFixedUpdate();

            rb.transform.position = ball.startPointBall;
            rb.transform.rotation = Quaternion.identity;
        }
    }
}