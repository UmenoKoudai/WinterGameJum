using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    [SerializeField, Tooltip("与えるダメージの数値")] float _damage;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            float fuel = other.GetComponent<PlayerController>()._fuel;
            fuel -= _damage;
            Destroy(gameObject);
        }
    }
}
