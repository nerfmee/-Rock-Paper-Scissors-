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
        _detectObjects.TakeDamage(10);
       Destroy(other.gameObject); 
    }
}
