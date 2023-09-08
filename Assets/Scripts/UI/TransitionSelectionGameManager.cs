using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionSelectionGameManager : MonoBehaviour
{
    [Header("Escena del juego")][Tooltip("Nombre de la escena del juego")]
    [SerializeField]
    [TextArea] private string _nombreDeLaEscenaDelJuego;
    [Space(1)]

    [Header("Escena del inicio")][Tooltip("Nombre de la escena del inicio")]
    [SerializeField]
    [TextArea] private string _nombreDeInicioDelJuego;
    private string _champSelected;

    public void SelectKnightChamp()
    {
        _champSelected = "Knight";
        LoadSceneGame();
    }

    public void SelectPistolChamp()
    {
        _champSelected = "Gunner";
        LoadSceneGame();
    }

    public void SelectSoulEaterChamp()
    {
        _champSelected = "SoulEater";
        LoadSceneGame();
    }

    public void ReturnIndex()
    {
        LoadSceneIndex();
    }

    public string AccesNameChamp(string _nameChamp) //Utilizar este metodo para acceder a que campeon a escogido
    {
        _champSelected = _nameChamp;
        return _nameChamp;
    }

    private void LoadSceneGame()
    {
        SceneManager.LoadSceneAsync(_nombreDeLaEscenaDelJuego);
    }

    private void LoadSceneIndex()
    {
        SceneManager.LoadSceneAsync(_nombreDeInicioDelJuego);
    }
}
