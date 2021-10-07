using System;
using UnityEngine;

namespace Camera
{
    public class CameraFollow : MonoBehaviour
    {
        [SerializeField] private Transform target;
        [SerializeField] private float speed = 3f;
        [SerializeField] private float distance = 0.5f;

        private void Start()
        {
            transform.rotation = Quaternion.Euler(45, 0, 0);
        }

        private void FixedUpdate()
        {
            var time = speed * Time.fixedDeltaTime;
            var position = transform.position;

            position.x = Mathf.Lerp(transform.position.x, target.position.x, time);
            position.y = Mathf.Lerp(transform.position.y + distance, target.position.y, time);
            position.z = Mathf.Lerp(transform.position.z - distance, target.position.z, time);
            
            transform.position = position;
        }
    }
}
