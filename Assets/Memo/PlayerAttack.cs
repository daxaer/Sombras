using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField]
    private GameObject _attackArea;
    private bool _attacking = false;
    private float _timeToAttack = 0.25f;
    private float _timer = 0f;

    // Start is called before the first frame update
    void Start()
    {
        _attackArea = transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Attack();
        }

        if(_attacking)
        {
            _timer = Time.time;
            if(_timer >= _timeToAttack)
            {
                _timer = 0;
                _attacking = false;
                _attackArea.SetActive(_attacking);
            }
        }
    }

    private void Attack()
    {
        _attacking = true;
        _attackArea.SetActive(_attacking);
    }
}
