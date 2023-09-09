using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionGameOver : MonoBehaviour
{

    [SerializeField][Tooltip("")]
    [TextArea] private string _nombreDeLaEscenaInicio;

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

    public void ExitGame()
    {
        Application.Quit();
    }

    public IEnumerator CourutineOpenIndex()
    {
        yield return new WaitForSeconds(0.1f);
        SceneManager.LoadSceneAsync(_nombreDeLaEscenaInicio);
    }
}
