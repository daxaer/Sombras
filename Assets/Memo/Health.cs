using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField]
    private int _maxHealth = 3;
    [SerializeField]
    private int _currentHealth;
    // Start is called before the first frame update
    void Start()
    {
        _currentHealth = _maxHealth;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            _maxHealth = 4;
        }
    }
    public void TakeDamage(int _amount)
    {
        _currentHealth -= _amount;
        if(_currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
