using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ManageEventSystem : MonoBehaviour
{
    [SerializeField] EventSystem _eventSystem;
    public static ManageEventSystem Instance;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(Instance);
        }
    }

    public EventSystem GetEventSystem()
    {
        return _eventSystem;
    }
}
