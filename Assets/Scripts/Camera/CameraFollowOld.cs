using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowOld : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private Vector3 offset;

    private void Start()
    {
        transform.position = target.position + offset;
    }

}
