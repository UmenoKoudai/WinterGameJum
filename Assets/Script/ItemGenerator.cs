using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerator : MonoBehaviour
{
    [SerializeField] GameObject[] _stagePrefab;
    [SerializeField] float _generateTime;
    float _timer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _timer += Time.deltaTime;
        if(_timer >= _generateTime)
        {
            _timer = 0;
            Instantiate(_stagePrefab[Random.Range(0, _stagePrefab.Length)]);
            
        }
    }
}
