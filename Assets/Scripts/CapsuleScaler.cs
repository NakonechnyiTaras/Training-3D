using UnityEngine;

public class CapsuleScaler : MonoBehaviour
{
   [SerializeField] private float growthSpeed = 0.5f;

    void Update()
    {
        transform.localScale += Vector3.one * growthSpeed * Time.deltaTime;
    } 
}
