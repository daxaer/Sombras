using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pool
{
    List<GameObject> pool; //nuestra lista interna
    GameObject prefab; //Referencia al prefab, para poder instanciar si se llega a llenar el pool

    public void Inicializar(GameObject _prefab, int _tamInicial) // solo se necita llamar 1 vez
    {
        pool = new List<GameObject>(); //iniciamos nuestra lista
        prefab = _prefab; //Guardamos referencia al prefab que vamos a manejar
        for (int i = 0; i < _tamInicial; i++)
        {
            GameObject go = Instanciar(prefab.transform.position, _prefab.transform.rotation);
            go.SetActive(false); //lo apagamos luego luego
        }

    }
    GameObject Instanciar(Vector3 _pos, Quaternion _rot)
    {
        GameObject go = GameObject.Instantiate(prefab, _pos, _rot); //Creamos nuevo
        go.name = go.name + "_" + pool.Count;
        pool.Add(go); // lo agregamos a nuestra lista interna
        return go; //lo regresamos
    }

    public GameObject Spawn(Vector3 _pos, Quaternion _rot) //el que va sustituir los instantiate
    {
        for (int i = 0; i < pool.Count; i++)
        {
            if (pool[i].activeSelf == false)
            {
                pool[i].transform.position = _pos;
                pool[i].transform.rotation = _rot;
                pool[i].SetActive(true);
                return pool[i]; // nos salimos de la funcion y devolvemos un gameObject
            }

        }
        //si se sale del for, significa que no hay un gameObject disponible, entonces lo crecemos
        return Instanciar(_pos, _rot);
    }

    public void DeactivateEnemy(GameObject go)
    {
        go.SetActive(false);
    }

}