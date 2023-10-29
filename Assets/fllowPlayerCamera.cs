using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fllowPlayerCamera : MonoBehaviour, IDataPersiistence
{
    [SerializeField] private CinemachineVirtualCamera camara;

    public void LoadData(GameData _data)
    {
        camara = GetComponent<CinemachineVirtualCamera>();
        camara.Follow = Player.Instance.transform;
    }

    public void SaveData(ref GameData _data)
    {

    }

}
