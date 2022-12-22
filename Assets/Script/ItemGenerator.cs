using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerator : MonoBehaviour
{
    [SerializeField] GameObject[] _itemPrefab;
    int _playerJudge;
    // Start is called before the first frame update
    void Start()
    {
        _playerJudge = GameObject.FindObjectOfType<PlayerController>()._playerId;
        if(_playerJudge == 2)
        {
            Instantiate(_itemPrefab[Random.Range(0,_itemPrefab.Length-1)]);
        }
        else
        {
            Instantiate(_itemPrefab[4]);
        }
    }
}
