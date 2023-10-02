using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.Collections;
using UnityEngine.UI;

public class TransitionSelectionGameManager : MonoBehaviour
{
    [Header("Escena del juego")][Tooltip("Nombre de la escena del juego")]
    [SerializeField]
    [TextArea] private string _nombreDeLaEscenaDelJuego;
    [Space(1)]

    [Header("Escena del inicio")][Tooltip("Nombre de la escena del inicio")]
    [SerializeField]
    [TextArea] private string _nombreDeInicioDelJuego;

    [Header("Variable Tiempo de Carga")][Tooltip("Variable para el tiempo de carga")]
    [SerializeField]
    private float timeToWaitBar;
    [SerializeField]
    private float timeToWait;

    private string _champSelected;

    [Header("Imagen de la barra 'Front' ")][Tooltip("Imagen de la barra de carga")]
    [SerializeField]
    private Image gameBar;
    [SerializeField]
    private GameObject _panelLoadTransition;

    [SerializeField]
    private Image _imagen;

    public void SelectKnightChamp()
    {
        _champSelected = "Knight";
        GameBarLoading();
    }

    public void SelectPistolChamp()
    {
        _champSelected = "Gunner";
        GameBarLoading();
    }

    public void SelectSoulEaterChamp()
    {
        _champSelected = "SoulEater";
        GameBarLoading();
    }

    public void ReturnIndex()
    {
        LoadSceneIndex();
    }

    public void GameBarLoading()
    {
        StartCoroutine(LoadGameBar());
    }

    public string AccesNameChamp(string _nameChamp) //Utilizar este metodo para acceder a que campeon a escogido
    {
        _champSelected = _nameChamp;
        return _nameChamp;
    }

    private void LoadSceneIndex()
    {
        SceneManager.LoadSceneAsync(_nombreDeInicioDelJuego);
    }

    private IEnumerator LoadGameBar()
    {
        gameBar.fillAmount = 0;
        _panelLoadTransition.SetActive(true);
        for (int contador = 0; contador < timeToWait; contador++)
        {
            yield return new WaitForSeconds(timeToWaitBar);
            gameBar.fillAmount += 0.1f;

            if (gameBar.fillAmount == 1f)
            {
                SceneManager.LoadSceneAsync(_nombreDeLaEscenaDelJuego, LoadSceneMode.Single);
            }
        }
    }

    public void CambiarImagen(Sprite image)
    {
        _imagen.sprite = image;
    }

}
