using UnityEngine;

public class ExplosionWave : MonoBehaviour
{
    [SerializeField] private float _baseForce = 300f;
    [SerializeField] private float _baseRadius = 5f;

    public void Detonate(Vector3 center, float scaleMultiplier)
    {
        float radius = _baseRadius * scaleMultiplier;
        float force = _baseForce * scaleMultiplier;

        Collider[] colliders = Physics.OverlapSphere(center, radius);

        foreach (Collider hit in colliders)
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();

            if (rb != null)
            {
                rb.AddExplosionForce(force, center, radius, 0f, ForceMode.Impulse);
            }
        }
    }
}
