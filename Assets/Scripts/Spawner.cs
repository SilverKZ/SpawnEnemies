using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;
    [SerializeField] private Transform[] _points;
    [SerializeField] private float _delay;

    private int _index;

    private void Start()
    {
        _index = 0;
        StartCoroutine(Timer());
    }

    private IEnumerator Timer()
    {
        while (_delay >= 0)
        {
            yield return new WaitForSeconds(_delay);
            CreateEnemy();
        }
    }

    private void CreateEnemy()
    {
        Enemy enemy = Instantiate(_enemy, _points[_index].transform.position, Quaternion.identity);
        float _lifetime = 8f;
        Destroy(enemy.gameObject, _lifetime);
        _index++;

        if (_index == _points.Length)
        {
            _index = 0;
        }
    }
}
