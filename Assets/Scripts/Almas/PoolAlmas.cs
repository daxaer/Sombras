using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Pool;

public class PoolAlmas : MonoBehaviour
{
    [SerializeField] private Transform spawnPosition;
    [SerializeField] private SpawnAlmas prefabAlmas;

    private ObjectPool<SpawnAlmas> almasPool;
    void Start()
    {
        almasPool = new ObjectPool<SpawnAlmas>(() => 
        {
            SpawnAlmas alma = Instantiate(prefabAlmas, spawnPosition.position, spawnPosition.rotation);
            alma.DesactivarAlma(DesactivarAlmaPool);
            return alma;
        }, alma =>
        {
            alma.transform.position = spawnPosition.position;
            alma.gameObject.SetActive(true);
        }, alma => 
        {
            alma.gameObject.SetActive(false);
        }, alma =>
        {
            Destroy(alma.gameObject);
        }, true,25,100);
    }

    public void ActivarAlma()
    {
        almasPool.Get();
    }

    private void DesactivarAlmaPool(SpawnAlmas alma)
    {
        almasPool.Release(alma);
    }
}
