using UnityEngine;

public class Scaler : MonoBehaviour
{
   [SerializeField] private float _growthSpeed = 0.5f;

    private void Update()
    {
        transform.localScale += Vector3.one * _growthSpeed * Time.deltaTime;
    } 
}
