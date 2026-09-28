using UnityEngine;

public class CombinedCubController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 3f;
    
    [SerializeField] private float rotationSpeed = 45f;
    
    [SerializeField] private float growthSpeed = 0.2f;

    void Update()
    {
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);

        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);

        transform.localScale += Vector3.one * growthSpeed * Time.deltaTime;
    }
}
