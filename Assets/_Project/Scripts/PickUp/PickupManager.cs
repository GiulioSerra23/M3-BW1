using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupManager : MonoBehaviour
{
    [SerializeField] private Pickup[] _pickupArr;
    [SerializeField] private Transform[] _trans;
    [SerializeField] private float _spawnTimer;
    [SerializeField] private int _maxPickup;

    private float _timer;

    public void SpawnPickup()
    {
        Transform transPoint = _trans[Random.Range(0, _trans.Length)];
        Pickup pickupSpawned = _pickupArr[Random.Range(0, _pickupArr.Length)];

        Instantiate(pickupSpawned, transPoint);
    }

    private void Update()
    {
        if (_pickupArr.Length < _maxPickup)
        {
            _timer += Time.deltaTime;

            if (_timer > _spawnTimer)
            {
                SpawnPickup();
                _timer = 0;
            }
        }
    }
}
