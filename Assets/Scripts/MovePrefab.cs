using System.Collections;
using UnityEngine;

public class MovePrefab : MonoBehaviour
{
    public float moveSpeed;
    float time = 4f;
    private void FixedUpdate()
    {
        transform.Translate(Vector3.right * moveSpeed);
    }
    
}
