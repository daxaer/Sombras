using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fllowPlayerCamera : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera camera;

    private void Start()
    {
        camera.Follow = Player.Instance.transform;
    }
}
