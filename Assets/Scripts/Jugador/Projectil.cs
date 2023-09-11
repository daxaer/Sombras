using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
public class Projectil : MonoBehaviour
{
    private int _damage = 1;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            Debug.Log("choque");
            other.GetComponent<Enemy>().TakeDamage(_damage);
        }
    }
    public void Destruir()
    {
        Destroy(gameObject);    
    }
}
