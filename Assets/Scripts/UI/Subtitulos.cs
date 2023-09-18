using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Subtitulos : MonoBehaviour
{

    [Header("Texto")][Tooltip("Fuente de texto del objeto subtitulo")]
    [SerializeField]private TextMeshProUGUI _textMeshProUGUI;
    [Space(1)]
    [Header("Frases")]
    [SerializeField][Tooltip("Arreglo de frases, puedes poner una frase aqui para que se muestre en la section de descripcion")]
    [Multiline]private string[] _arregloDeFrases;
    [Tooltip("Limite del arreglo de descripciones")][SerializeField]private float _limitArray;
    [Space(1)]
    [Header("Contador de frase(No Tocar)")][Tooltip("Este siguiente significa en que espacio del arreglo de frases esta (No tocar)")]
    [SerializeField]private int _siguiente;

    [Header("TiempoLimite")][Tooltip("Tiempo de limite de cambiar el texto")]
    [SerializeField]private float _timerLimit;
    [Space(1)]
    [Header("Contador(No tocar)")][Tooltip("Contador")]
    [SerializeField] private float _timer;

    void Start()
    {
        _textMeshProUGUI.text = _arregloDeFrases[0];
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
