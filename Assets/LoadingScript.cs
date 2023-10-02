using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Localization.Metadata;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingScript : MonoBehaviour
{
    [SerializeField] private string scene;
    [SerializeField] private Image gameBar;

    private void OnEnable()
    {
        StartCoroutine(LoadGameBar());
    }

    IEnumerator LoadGameBar()
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(scene);
        while(!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress/0.9f);
            gameBar.fillAmount = progress;

            yield return null;
        }
    }
}
