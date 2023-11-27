using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.U2D;

public class VictoriaYDerrota : MonoBehaviour
{
    private Vector3 escala;
    private Vector3 escalaFinal;
    [SerializeField] private float duracion;
    [SerializeField] private bool ganaste;
    [SerializeField] private SpriteRenderer sprite;
    private Light2D luz;
    private void Start()
    {
        luz = gameObject.GetComponent<Light2D>();
        escala = transform.localScale;
        escalaFinal = new Vector3(50,50,1);
    }
    public void scalaraura()
    {
        StartCoroutine("Scalar");
    }
    public IEnumerator Scalar() 
    {
        if(Player.Instance.dead)
        {
            sprite.color = Color.black;
            MusicManager.Instance.PlayAudioPool(SOUNDTYPE.DERROTA, transform);
            Debug.Log("perdi");
        }
        else
        {
            luz.intensity = 1;
            LuzDeVictoria.Instance.StartCoroutine("Luz");
            Debug.Log("gane");
            sprite.color = Color.white;
            MusicManager.Instance.PlayAudioPool(SOUNDTYPE.VICTORIA, transform);
        }
        float aumentar = 0f;
        while (aumentar <= duracion)
        {
            transform.localScale = Vector3.Lerp(escala, escalaFinal, aumentar / duracion);
            aumentar += Time.deltaTime;
            yield return null;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("lampara") && !Player.Instance.dead)
        {
            collision.gameObject.GetComponent<Animator>().SetTrigger("gane");
        }
        else if(collision.CompareTag("lampara") && Player.Instance.dead)
        {
            collision.gameObject.GetComponent<Animator>().SetTrigger("perdi");
        }
    }
}
