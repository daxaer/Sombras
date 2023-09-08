using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionIndexGameManager : MonoBehaviour
{
    [Header("Escena del juego")][SerializeField][Tooltip("Aki pones el nombre de la escena que quieres cambiar")]
    [TextArea] private string _nombreDeLaEscenaDeSeleccion;
    [Space(1)]
    [Header("Texto")][Tooltip("Fuente de texto del objeto subtitulo")]
    [SerializeField]private TextMeshProUGUI _textMeshProUGUI;
    [Space(1)]
    [Header("Frases")]
    [SerializeField][Tooltip("Arreglo de frases, puedes poner una frase aki para que se muestre en la section de descripcion")]
    [Multiline]private string[] _arregloDeFrases;
    [Tooltip("Limite del arreglo de descripciones")][SerializeField]private float _limitArray;
    [Space(1)]
    [Header("Contador de frase(No Tocar)")][Tooltip("Este siguiente significa en que espacio del arreglo de frases esta (No tocar)")]
    [SerializeField]private int _siguiente;
    [Space(1)]
    [Header("Objeto Settings")][Tooltip("Aplicar el objeto de settings")]
    [SerializeField]private GameObject _SettingsObject;
    [Tooltip("Tiempo en abrir los creditos")][SerializeField]private float timeToOpenSettings;
    [Space(1)]
    [Header("Objeto Credits")]
    [Tooltip("Aplicar el objeto de credits")]
    [SerializeField] private GameObject _CreditsObject;
    [Tooltip("Tiempo en abrir los creditos")][SerializeField] private float timeToOpenCredits;
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


    void Start()
    {
        _textMeshProUGUI.text = _arregloDeFrases[0];
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
            _textMeshProUGUI.text = _arregloDeFrases[_siguiente];
        }
    }

    public void PlayButton()
    {
        SceneManager.LoadScene(_nombreDeLaEscenaDeSeleccion);
    }

    public void OpenSettings()
    {
        StartCoroutine(CourutineSettingsOpen());
    }

    public void CloseSettings()
    {
        StartCoroutine(CourutineSettingsClose());
    }

    public void OpenCredits()
    {
        StartCoroutine(CourutineCreditsOpen());
    }

    public void CloseCredits()
    {
        StartCoroutine(CourutineCreditsClose());
    }

    public void Exit()
    {
        Application.Quit();
    }

    private IEnumerator CourutineSettingsOpen()
    {
        yield return new WaitForSeconds(timeToOpenSettings);
        _SettingsObject.SetActive(true);
    }

    private IEnumerator CourutineSettingsClose()
    {
        yield return new WaitForSeconds(timeToOpenSettings);
        _SettingsObject.SetActive(false);
    }

    private IEnumerator CourutineCreditsOpen()
    {
        yield return new WaitForSeconds(timeToOpenCredits);
        _CreditsObject.SetActive(true);
    }

    private IEnumerator CourutineCreditsClose()
    {
        yield return new WaitForSeconds(timeToOpenCredits);
        _CreditsObject.SetActive(false);
    }

    private IEnumerator SwitcherDescription()
    {
        AnimationDesaparecer();
        yield return new WaitForSeconds(1);
        AnimationAparecer();
        _textMeshProUGUI.text = _arregloDeFrases[_siguiente];
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
