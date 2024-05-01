using Zenject;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _enemyPrefab;

    [SerializeField] private Transform _spawnPoint;

    private Path _path;

    [Inject]
    public void Construct(Path path) {
        _path = path;
    }

    private void Update() {
        if(Input.GetKeyDown(KeyCode.Space)) {
            GameObject enemy = Instantiate(_enemyPrefab, _spawnPoint.position, Quaternion.identity);
            enemy.GetComponent<EnemyMovement>().SetPath(_path);
        }
    }
}
