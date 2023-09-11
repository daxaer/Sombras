using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class TransitionGameOver : MonoBehaviour
{

    [SerializeField][Tooltip("")]
    [TextArea] private string _nombreDeLaEscenaInicio;

    [SerializeField]
    [Tooltip("")]
    [TextArea] private string _nombreDeLaEsceneJuego;

    [SerializeField]
    [Tooltip("")]
    [TextArea] private string _nombreDeLaEsceneSelectChamp;

    [SerializeField] EventSystem eventSystem;
    [SerializeField] GameObject _buttonRetryInitialize;

    [SerializeField] private GameObject _GameOver;
    private TransitionGameOver _transitionGameOver;

    [SerializeField] private GameObject _Settigns;

    public TransitionGameOver GameOverTransition { get { return _transitionGameOver; } }

    public void CargarGameOver()
    {
        _GameOver.SetActive(true);
        Time.timeScale = 0;
        eventSystem.SetSelectedGameObject(_buttonRetryInitialize);
    }

    public void OpenIndex()
    {
        StartCoroutine(CourutineOpenIndex());
    }

    public void ReloadEscene()
    {
        StartCoroutine(CourutineReloadEscene());
    }

    public void OpenSelectChamp()
    {
        StartCoroutine(CourutineOpenSelectChamp());
    }

    public void CloseSettings()
    {
        StartCoroutine(CourutineCloseSettings());
    }

    private IEnumerator CourutineOpenIndex()
    {
        yield return new WaitForSeconds(0.1f);
        _GameOver.SetActive(false);
        SceneManager.LoadSceneAsync(_nombreDeLaEscenaInicio);
    }

    private IEnumerator CourutineOpenSelectChamp()
    {
        yield return new WaitForSeconds(0.1f);
        SceneManager.LoadSceneAsync(_nombreDeLaEsceneSelectChamp);
    }

    private IEnumerator CourutineReloadEscene()
    {
        _GameOver.SetActive(false);
        yield return new WaitForSeconds(0.1f);
        SceneManager.LoadSceneAsync(_nombreDeLaEsceneJuego);
    }

    private IEnumerator CourutineCloseSettings()
    {
        yield return new WaitForSeconds(0.1f);
        _Settigns.SetActive(true);
    }
}
