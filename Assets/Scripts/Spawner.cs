using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject _enemy;
    [SerializeField] private Transform[] _points;
    [SerializeField] private float _startTime;

    private float _time;
    private float _lifetime;
    private int _index;

    void Start()
    {
        _time = _startTime;
        _lifetime = 8f;
        _index = 0;
    }

    void Update()
    {        
        if (_time <= 0)
        {
            GameObject enemy = Instantiate(_enemy, _points[_index].transform.position, Quaternion.identity);
            Destroy(enemy, _lifetime);
            _time = _startTime;
            _index++;

            if (_index == _points.Length)
            {
                _index = 0;
            }
        }
        else
        {
            _time -= Time.deltaTime;
        }
    }
}
