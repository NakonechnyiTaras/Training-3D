using UnityEngine;

public class SplittedCube : MonoBehaviour
{
    private MeshRenderer _meshRenderer;
    private Rigidbody _rigidbody;
    private float _splitProbability = 1.0f;

    public float SplitProbability => _splitProbability;

    private void Awake()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void Initialize(float nextProbability, Vector3 nextScale)
    {
        _splitProbability = nextProbability;
        transform.localScale = nextScale;

        if (_meshRenderer == null)
        {
            _meshRenderer = GetComponent<MeshRenderer>();
        }

        if (_meshRenderer != null)
        {
            _meshRenderer.material.color = new Color(Random.value, Random.value, Random.value);
        }
    }
}