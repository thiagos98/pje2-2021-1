using System.Collections;
using UnityEngine;

namespace General
{
    public class Ground : MonoBehaviour, IResettable
    {
        [SerializeField] private BolinhaFisica ball;
        private void FixedUpdate()
        {
            var position = ball.transform.position;
            position.y = transform.position.y;
            transform.position = position;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag("Player")) return;
            other.TryGetComponent(out Rigidbody rb);
            if (rb) StartCoroutine(ResetBall(rb));
        }

        public IEnumerator ResetBall (Rigidbody rb)
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        
            yield return new WaitForFixedUpdate();

            rb.transform.position = ball.startPointBall;
            rb.transform.rotation = Quaternion.identity;
        }
    
    }
}
