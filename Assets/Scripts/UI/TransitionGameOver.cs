using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionGameOver : MonoBehaviour
{

    [SerializeField][Tooltip("")]
    [TextArea] private string _nombreDeLaEscenaInicio;

    [SerializeField]
    [Tooltip("")]
    [TextArea] private string _nombreDeLaEsceneJuego;

    private bool _JugadorMuerto;
    private GameObject _GameOver;


    public void Update()
    {
        if (_JugadorMuerto)
        {
            _JugadorMuerto = false;
            _GameOver.SetActive(true);
        }
    }

    public void OpenIndex()
    {
        StartCoroutine(CourutineOpenIndex());
    }

    public void ReloadEscene()
    {
        _GameOver.SetActive(false);
        SceneManager.LoadSceneAsync(_nombreDeLaEsceneJuego);
    }

    public IEnumerator CourutineOpenIndex()
    {
        yield return new WaitForSeconds(0.1f);
        SceneManager.LoadSceneAsync(_nombreDeLaEscenaInicio);
    }
}
