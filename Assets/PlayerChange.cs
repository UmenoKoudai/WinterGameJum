using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerChange : MonoBehaviour
{
    [SerializeField] GameObject[] _players;

    void PlayerSelect(int id)
    {
        PlayerController _player = GameObject.FindObjectOfType<PlayerController>();
        for (int i = 0; i < _players.Length; i++)
        {
            _players[i].SetActive(false);
        }
        _player._playerId = id;
        _players[id].SetActive(true);
    }
}
