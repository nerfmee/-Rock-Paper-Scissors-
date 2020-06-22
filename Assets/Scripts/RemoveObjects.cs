using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveObjects : MonoBehaviour
{
    private DetectObjects _detectObjects;

    private void Start()
    {
        _detectObjects = FindObjectOfType<DetectObjects>();
    }

    private void OnTriggerEnter(Collider other)
    {
        CameraShake.Shake(0.35f,1f);
        _detectObjects.TakeDamage(10);
       Destroy(other.gameObject); 
    }
}
