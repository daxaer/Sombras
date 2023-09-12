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
    [SerializeField] GameObject _bottonWin;

    [SerializeField] private GameObject _GameOver;
    [SerializeField] private GameObject _Winner;

    private TransitionGameOver _transitionGameOver;

    [SerializeField] private GameObject _Settigns;

    public TransitionGameOver GameOverTransition { get { return _transitionGameOver; } }

    public void CargarGameOver()
    {
        _GameOver.SetActive(true);
        eventSystem.SetSelectedGameObject(_buttonRetryInitialize);
        //Time.timeScale = 0;
    }
    public void Win()
    {
        _Winner.SetActive(true);
        eventSystem.SetSelectedGameObject(_bottonWin);
        //Time.timeScale = 0;
    }

    public void OpenIndex()
    {
        Debug.Log("llamando index 1");
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
        Debug.Log("llamando index 2");
        Time.timeScale = 1;
        yield return new WaitForSeconds(0.1f);
        _GameOver.SetActive(false);
        SceneManager.LoadSceneAsync(_nombreDeLaEscenaInicio);
    }

    private IEnumerator CourutineOpenSelectChamp()
    {
        Time.timeScale = 1;
        yield return new WaitForSeconds(0.1f);
        SceneManager.LoadSceneAsync(_nombreDeLaEsceneSelectChamp);
    }

    private IEnumerator CourutineReloadEscene()
    {
        _GameOver.SetActive(false);
        _Winner.SetActive(false);
        Time.timeScale = 1;
        yield return new WaitForSeconds(0.1f);
        SceneManager.LoadSceneAsync(_nombreDeLaEsceneJuego);
    }

    private IEnumerator CourutineCloseSettings()
    {
        yield return new WaitForSeconds(0.1f);
        _Settigns.SetActive(true);
    }
}
