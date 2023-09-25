using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathCount : MonoBehaviour, IDetaPersiistence
{

    [SerializeField] private int _deathCount = 0;
    
    public void OnPlayerDeath()
    {
        _deathCount++;
    }

    public void LoadData(GameData _data)
    {
        this._deathCount = _data._deathCount; //death count de GameData
    }

    public void SaveData(ref GameData _data)
    {
        _data._deathCount = this._deathCount; //deathcount en esta clase
    }

}

