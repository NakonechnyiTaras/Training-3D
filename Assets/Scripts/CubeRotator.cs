using UnityEngine;

public class CubeRotator : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 90f;

    void Update()
    {
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
    }
}
