using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fllowPlayerCamera : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera camara;
    private void Start()
    {
        camara = GetComponent<CinemachineVirtualCamera>();
        camara.Follow = Player.Instance.transform;
    }
}
