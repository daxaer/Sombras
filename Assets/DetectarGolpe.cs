using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectarGolpe : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Projectile"))
        {
            GetComponentInParent<Enemies>().Cargando();
            gameObject.GetComponent<CapsuleCollider2D>().enabled = false;
        }
    }
}
