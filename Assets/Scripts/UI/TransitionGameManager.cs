using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;

public class TransitionGameManager : MonoBehaviour
{
    public string _nombreDeLaEscenaDelJuego;
    public TextMeshProUGUI _textMeshProUGUI;
    public string[] _descriptionPrimero;
    public float _limitArray;
    //[SerializeField]
    //private Animator _animator;

    [SerializeField]
    private float _timerLimit;
    [SerializeField]
    private float _timer;
    [SerializeField]
    private int _siguiente;
    [SerializeField]
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
