using UnityEngine;
using UnityEngine.InputSystem;

public class CubeSpawner : MonoBehaviour
{
    [SerializeField] private InputReader _inputReader;
    [SerializeField] private ExplosionWave _explosionWave;
    [SerializeField] private SplittedCube _cubePrefab;

    private Camera _mainCamera;

    private void Start()
    {
        _mainCamera = Camera.main;

        if (_inputReader == null) _inputReader = GetComponent<InputReader>();
        if (_explosionWave == null) _explosionWave = GetComponent<ExplosionWave>();
        
        if (_cubePrefab == null)
        {
            Debug.LogError("Критическая ошибка: Префаб куба не назначен в CubeSpawner!");
        }
    }

    private void OnEnable()
    {
        if (_inputReader != null)
        {
            _inputReader.LeftMouseClicked += OnLeftMouseClicked;
        }
    }

    private void OnDisable()
    {
        if (_inputReader != null)
        {
            _inputReader.LeftMouseClicked -= OnLeftMouseClicked;
        }
    }

    private void OnLeftMouseClicked()
    {
        if (Mouse.current == null || _mainCamera == null) return;

        Vector2 mousePosition = Mouse.current.position.ReadValue();
        Ray ray = _mainCamera.ScreenPointToRay(mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity))
        {
            if (hit.collider != null)
            {
                SplittedCube clickedCube = hit.collider.GetComponent<SplittedCube>();

                if (clickedCube != null && hit.collider.enabled)
                {
                    hit.collider.enabled = false;
                    ProcessCubeDestruction(clickedCube);
                }
            }
        }
    }

    private void ProcessCubeDestruction(SplittedCube targetCube)
    {
        if (targetCube == null) return;

        if (_cubePrefab == null)
        {
            Debug.LogError("Ошибка: Префаб куба не назначен в CubeSpawner!");
            Destroy(targetCube.gameObject);
            return;
        }

        Vector3 spawnCenterPosition = targetCube.transform.position;
        Vector3 parentScale = targetCube.transform.localScale;
        float currentProbability = targetCube.SplitProbability;

        if (Random.value <= currentProbability)
        {
            int cubesToSpawn = Random.Range(2, 7);
            
            float nextProbability = currentProbability / 2f;
            Vector3 nextScale = parentScale / 2f;

            for (int i = 0; i < cubesToSpawn; i++)
            {
                Vector3 randomOffset = new Vector3(
                    Random.Range(-0.2f, 0.2f) * parentScale.x,
                    Random.Range(0.0f, 0.2f) * parentScale.y,
                    Random.Range(-0.2f, 0.2f) * parentScale.z
                );

                Vector3 spawnPosition = spawnCenterPosition + randomOffset;

                SplittedCube newCube = Instantiate(_cubePrefab, spawnPosition, Quaternion.identity);
                
                if (newCube != null)
                {
                    newCube.Initialize(nextProbability, nextScale);
                }
            }

            if (_explosionWave != null)
            {
                _explosionWave.Detonate(spawnCenterPosition, parentScale.x);
            }
        }

        Destroy(targetCube.gameObject);
    }
}