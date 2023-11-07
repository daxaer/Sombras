using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangScene : MonoBehaviour
{
    [SerializeField] private Scene currentScene;
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject objectAnim;
    private string sceneToCall;
    [SerializeField] Canvas canvas;

    private void Awake()
    {
        DontDestroyOnLoad(transform.parent.parent.parent.gameObject);
    }

    public void SceneToCall(string _s)
    {
        sceneToCall = _s;
        Debug.Log(sceneToCall);
    }

    public void TransitionOnSelection()
    {

        Debug.Log("TransitionOnSelect");
        currentScene = SceneManager.GetActiveScene();
        SceneManager.sceneLoaded += OnSceneLoaded;
        SceneManager.sceneUnloaded += OnSceneUnLoaded;
        Debug.Log(sceneToCall);
        SceneManager.LoadSceneAsync(sceneToCall);

    }

    private void OnSceneLoaded(Scene _s, LoadSceneMode _loadSceneMode)
    {
        Debug.Log("OnSceneLoaded");
        SceneManager.UnloadScene(currentScene);
    }

    private void OnSceneUnLoaded(Scene _s)
    {
        animator.SetTrigger("TransitionOut");
        //canvas.worldCamera = Camera.main;
        SceneManager.sceneLoaded -= OnSceneLoaded;
        SceneManager.sceneUnloaded -= OnSceneUnLoaded;
        Debug.Log("OnSceneUnLoaded");

    }

    private void OnAnimationFinish()
    {
        Destroy(transform.parent.parent.parent.gameObject);
        Debug.Log("OnAnimationFinish");

    }
}
