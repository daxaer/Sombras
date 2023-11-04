using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtaquesEnemigos : MonoBehaviour
{
    public int damage;
    private void OnEnable()
    {
        Invoke("Destruir", 0.1f);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Player.Instance.TakeDamage(damage);
        }
    }

    public void Destruir()
    {
        gameObject.SetActive(false);
    }
}
