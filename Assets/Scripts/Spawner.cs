using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Transform[] _points;
    [SerializeField] private float _delay;

    private GameObject _enemyTemplate;
    private int _index;

    private void Start()
    {
        _index = 0;
        _enemyTemplate = GameObject.Find("Enemy");
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
        GameObject enemy = Instantiate(_enemyTemplate, _points[_index].transform.position, Quaternion.identity);
        float _lifetime = 8f;
        Destroy(enemy, _lifetime);
        _index++;

        if (_index == _points.Length)
        {
            _index = 0;
        }
    }
}
