using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;
using Unity.VisualScripting;

public class TransitionGameManager : MonoBehaviour
{
    [Header("Escena del juego")][SerializeField][Tooltip("Aki pones el nombre de la escena que quieres cambiar")]
    [TextArea] private string _nombreDeLaEscenaDelJuego;
    [Space(1)]
    [Header("Texto")][Tooltip("Fuente de texto del objeto subtitulo")]
    [SerializeField]private TextMeshProUGUI _textMeshProUGUI;
    [Space(1)]
    [Header("Descripciones Y Limite de Arreglo")]
    [SerializeField][Tooltip("Arreglo de frases, puedes poner una frase aki para que se muestre en la section de descripcion")]
    [Multiline]private string[] _descriptionPrimero;
    [Tooltip("Limite del arreglo de descripciones")][SerializeField]private float _limitArray;
    [Space(1)]
    [Header("Contador de frase")][Tooltip("Este siguiente significa en que espacio del arreglo de frases esta (No tocar)")]
    [SerializeField]private int _siguiente;
    [Space(1)]
    [Header("Objeto Creditos")][Tooltip("Aplicar el objeto de creditos")]
    [SerializeField]private GameObject _SettingsObject;
    [Tooltip("Tiempo en abrir los creditos")][SerializeField]private float timeToOpenCredits;
    [Space(1)]
    //[SerializeField]
    //private Animator _animator;

    [Header("TiempoLimite")][Tooltip("Tiempo de limite de cambiar el texto")]
    [SerializeField]private float _timerLimit;
    [Space(1)]
    [Header("Contador(No tocar)")][Tooltip("Contador")]
    [SerializeField] private float _timer;

    /*[Header("Right click this variable name!")]
    [SerializeField]
    private string[] frases;
    [ContextMenuItem("Generate a random name", "RandomName")]
    [SerializeField]
    private string hola;

    public void RandomName()
    {
        int randomNumber = Random.Range(0, frases.Length);
        hola = frases[randomNumber];
    }*/

    public void PlayButton()
    {
        SceneManager.LoadScene(_nombreDeLaEscenaDelJuego);
    }

    void Start()
    {
        _textMeshProUGUI.text = _descriptionPrimero[0];
        //_animator.SetBool("Aparecer", true);
    }

    void Update()
    {
        _timer += Time.deltaTime;
        if (_timer > _timerLimit)
        {
            _timer = 0f;
            _siguiente++;
            StartCoroutine(SwitcherDescription());
        }

        if (_siguiente == _limitArray)
        {
            _siguiente = 0;
            _textMeshProUGUI.text = _descriptionPrimero[_siguiente];
        }
    }

    public void OpenSettings()
    {
        StartCoroutine(CourutineSettingsOpen());
    }

    public void CloseSettings()
    {
        StartCoroutine(CourutineSettingsClose());
    }

    private IEnumerator CourutineSettingsOpen()
    {
        yield return new WaitForSeconds(timeToOpenCredits);
        _SettingsObject.SetActive(true);
    }

    private IEnumerator CourutineSettingsClose()
    {
        yield return new WaitForSeconds(timeToOpenCredits);
        _SettingsObject.SetActive(false);
    }

    private IEnumerator SwitcherDescription()
    {
        AnimationDesaparecer();
        yield return new WaitForSeconds(1);
        AnimationAparecer();
        _textMeshProUGUI.text = _descriptionPrimero[_siguiente];
    }

    private void AnimationAparecer()
    {
        //_animator.SetBool("Aparecer", true);
    }

    private void AnimationDesaparecer()
    {
        //_animator.SetBool("Aparecer", false);
    }
}
