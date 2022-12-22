using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    [SerializeField, Tooltip("与えるダメージの数値")] int _damage;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            //int hp = other.GetComponent<PlayerContropller>()._hp;
            //hp -= _damage;
        }
    }
}
