using UnityEngine;

public class SpawnPos : MonoBehaviour
{
    [SerializeField] private Transform _spawner;

    public Transform GetSpawnPos() => 
        _spawner;
}
