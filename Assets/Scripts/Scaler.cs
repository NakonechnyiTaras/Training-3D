using UnityEngine;

public class Scaler : MonoBehaviour
{
   [SerializeField] private float _growthSpeed = 0.5f;

    void Update()
    {
        transform.localScale += Vector3.one * _growthSpeed * Time.deltaTime;
    } 
}
