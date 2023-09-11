using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SistemaDrop : MonoBehaviour
{
    public ProbTarjetas probabilidadTarjetas;
    [SerializeField] private TarjetaMostrada slot1;
    [SerializeField] private TarjetaMostrada slot2;
    [SerializeField] private TarjetaMostrada slot3;
    [SerializeField] private Almas almas;
    public static SistemaDrop Instance { get; private set; }

    [SerializeField] private int probabilidad1;
    [SerializeField] private int probabilidad2;
    [SerializeField] private int probabilidad3;
    [SerializeField] private int porcentajeTotal;

    private ProbTarjetas.Probabilidades[] prob;

    public Button botonCompraSlot1;

    public Button botonCompraSlot2;

    public Button botonCompraSlot3;

    [SerializeField] private EventSystem eventSystem;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        prob = probabilidadTarjetas.prob;
        System.Array.Sort(prob, new CompararRareza());
        System.Array.Reverse(prob);
        
        foreach (var cantidad in probabilidadTarjetas.prob)
        {
            porcentajeTotal += cantidad.probabilidadAparicion;
        }

        AparicionTarjetaEnSlot(1); 
        AparicionTarjetaEnSlot(2); 
        AparicionTarjetaEnSlot(3);

        eventSystem.SetSelectedGameObject(botonCompraSlot1.gameObject);
    }

    public void AparicionTarjetaEnSlot(int slot)
    {
        if (slot != 1 && slot != 2 && slot != 3)
        {
            
            return;
        }

        int probabilidad = Random.Range(1, porcentajeTotal + 1);
        int miProbabilidad = probabilidad;

        if (miProbabilidad >= porcentajeTotal)
        {
            miProbabilidad = porcentajeTotal;
        }

        for (int i = 0; i < probabilidadTarjetas.prob.Length; i++)
        {
            if (miProbabilidad <= probabilidadTarjetas.prob[i].probabilidadAparicion)
            {
                if (slot == 1)
                {
                    slot1.TarjetaEquipada = (TarjetaEquipada)probabilidadTarjetas.prob[i].TarjetaEquip;
                    botonCompraSlot1.gameObject.SetActive(true);
                    slot1.Actualizar();
                       if (slot == 1 && almas.CantidadAlmas < slot1.TarjetaEquipada.costoTarjeta )
                    {
                        botonCompraSlot1.gameObject.SetActive(false);
                    }
                }
                else if (slot == 2)
                {
                    slot2.TarjetaEquipada = (TarjetaEquipada)probabilidadTarjetas.prob[i].TarjetaEquip;
                    botonCompraSlot2.gameObject.SetActive(true);
                    slot2.Actualizar();
                    if (slot == 2 && almas.CantidadAlmas < slot2.TarjetaEquipada.costoTarjeta)
                    {
                        botonCompraSlot2.gameObject.SetActive(false);
                    }
                }
                else if (slot == 3)
                {

                    slot3.TarjetaEquipada = (TarjetaEquipada)probabilidadTarjetas.prob[i].TarjetaEquip;
                    botonCompraSlot3.gameObject.SetActive(true);
                    slot3.Actualizar();
                    if (slot == 3 && almas.CantidadAlmas < slot3.TarjetaEquipada.costoTarjeta)
                    {
                        botonCompraSlot3.gameObject.SetActive(false);
                    }

                }

                return;
            }
            else
            {
                miProbabilidad -= probabilidadTarjetas.prob[i].probabilidadAparicion;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public class CompararRareza : IComparer
    {
        public int Compare(object x, object y)
        {
            int obj1 = ((ProbTarjetas.Probabilidades)x).probabilidadAparicion;
            int obj2 = ((ProbTarjetas.Probabilidades)y).probabilidadAparicion;

            if (obj1 > obj2)
            {
                return 1;
            }
            else if (obj1 == obj2)
            {
                return 0;
            }
            else
            {
                return -1;
            }
        }
    }
}
