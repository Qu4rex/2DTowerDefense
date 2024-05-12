using Zenject;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _enemyPrefab;

    [SerializeField] private Transform _spawnPoint;

    [SerializeField] private Path _path;

    private void Update() {
        if(Input.GetKeyDown(KeyCode.Space)) {
            GameObject enemy = Instantiate(_enemyPrefab, _spawnPoint.position, Quaternion.identity);
            enemy.GetComponent<EnemyMovement>().SetPath(_path);
        }
    }
}
