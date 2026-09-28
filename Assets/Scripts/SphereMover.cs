using UnityEngine;

public class SphereMover : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;

    void Update()
    {
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
    }
}
