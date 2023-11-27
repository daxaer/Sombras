using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SistemaDrop : MonoBehaviour
{
    public ProbTarjetas probabilidadTarjetas;
    [SerializeField] private TarjetaMostrada slot1;
    [SerializeField] private TarjetaMostrada slot2;
    [SerializeField] private TarjetaMostrada slot3;
    public static SistemaDrop Instance { get; private set; }

    [SerializeField] private int probabilidad1;
    [SerializeField] private int probabilidad2;
    [SerializeField] private int probabilidad3;
    [SerializeField] private int porcentajeTotal;

    private ProbTarjetas.Probabilidades[] prob;

    public Button botonCompraSlot1;
    public Text textocompraSlot1;
    public Button botonCompraSlot2;
    public Text textocompraSlot2;
    public Button botonCompraSlot3;
    public Text textocompraSlot3;
    //[SerializeField] private EventSystem eventSystem;

    public bool actualizar;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
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

        ActualizarTarjetaEnSlot(1);
        ActualizarTarjetaEnSlot(2);
        ActualizarTarjetaEnSlot(3);

        //eventSystem.SetSelectedGameObject(botonCompraSlot1.gameObject);
    }
    private void OnEnable()
    {
        ActualizarTarjetaEnSlot(1);
        ActualizarTarjetaEnSlot(2);
        ActualizarTarjetaEnSlot(3);
    }

    public void ActualizarTarjetaEnSlot(int slot)
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
                    slot1.Actualizar();
                    ActualizarColorTextoSlots();
                }
                else if (slot == 2)
                {
                    slot2.TarjetaEquipada = (TarjetaEquipada)probabilidadTarjetas.prob[i].TarjetaEquip;
                    slot2.Actualizar();
                    ActualizarColorTextoSlots();
                }
                else if (slot == 3)
                {
                    slot3.TarjetaEquipada = (TarjetaEquipada)probabilidadTarjetas.prob[i].TarjetaEquip;
                    slot3.Actualizar();
                    ActualizarColorTextoSlots();
                }
                return;
            }
            else
            {
                miProbabilidad -= probabilidadTarjetas.prob[i].probabilidadAparicion;
            }
        }
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

                if (slot == 1 && UIManager.Instance.GetAlmas() >= slot1.TarjetaEquipada.costoTarjeta)
                {
                    slot1.TarjetaEquipada = (TarjetaEquipada)probabilidadTarjetas.prob[i].TarjetaEquip;
                    slot1.Actualizar();
                    ActualizarColorTextoSlots();
                }
                else if (slot == 2 && UIManager.Instance.GetAlmas() >= slot2.TarjetaEquipada.costoTarjeta)
                {
                    slot2.TarjetaEquipada = (TarjetaEquipada)probabilidadTarjetas.prob[i].TarjetaEquip;
                    slot2.Actualizar();
                    ActualizarColorTextoSlots();
                }
                else if (slot == 3 && UIManager.Instance.GetAlmas() >= slot3.TarjetaEquipada.costoTarjeta)
                {
                    slot3.TarjetaEquipada = (TarjetaEquipada)probabilidadTarjetas.prob[i].TarjetaEquip;
                    slot3.Actualizar();
                    ActualizarColorTextoSlots();
                }
                else
                {
                    if(slot == 1 && actualizar)
                    {
                        actualizar = false;
                        slot1.TarjetaEquipada = (TarjetaEquipada)probabilidadTarjetas.prob[i].TarjetaEquip;
                        slot1.Actualizar();
                        ActualizarColorTextoSlots();
                    }
                    if (slot == 2 && actualizar)
                    {
                        actualizar = false;
                        slot2.TarjetaEquipada = (TarjetaEquipada)probabilidadTarjetas.prob[i].TarjetaEquip;
                        slot2.Actualizar();
                        ActualizarColorTextoSlots();
                    }
                    if (slot == 3 && actualizar)
                    {
                        actualizar = false;
                        slot3.TarjetaEquipada = (TarjetaEquipada)probabilidadTarjetas.prob[i].TarjetaEquip;
                        slot3.Actualizar();
                        ActualizarColorTextoSlots();
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

    public void ActualizarColorTextoSlots()
    {
        if (UIManager.Instance.GetAlmas() < slot1.TarjetaEquipada.costoTarjeta)
        {
            textocompraSlot1.color = Color.red;
        }
        else
        {
            textocompraSlot1.color = Color.white;
        }
        if (UIManager.Instance.GetAlmas() < slot2.TarjetaEquipada.costoTarjeta)
        {
            textocompraSlot2.color = Color.red;
        }
        else
        {
            textocompraSlot2.color = Color.white;
        }
        if (UIManager.Instance.GetAlmas() < slot3.TarjetaEquipada.costoTarjeta)
        {
            textocompraSlot3.color = Color.red;

        }
        else
        {
            textocompraSlot3.color = Color.white;
        }
    }

    // Update is called once per frame

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
