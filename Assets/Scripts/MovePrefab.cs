using UnityEngine;

public class MovePrefab : MonoBehaviour
{
    public float moveSpeed;
    private void FixedUpdate()
    {
        transform.Translate(Vector3.right * moveSpeed);
    }
}
