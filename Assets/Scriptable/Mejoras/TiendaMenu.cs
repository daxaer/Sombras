using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TiendaMenu : MonoBehaviour
{
    public Image imagenTiendaPr;
    public TextMeshProUGUI textoPrecio;
    public Button botonComprar;
    public int nivelmejora;
    public int precio;
    public MejorasPermanentes mejora;
    public GestionNivel efecto;
    [SerializeField] SingletonDescription singletonDescription;

    void Start()
    {
        efecto = GetComponentInChildren<GestionNivel>();
        singletonDescription = GetComponent<SingletonDescription>();
    }

    public void SubiendoMejora()
    {
        Debug.Log("El indice es" + efecto.indiceActual);;
        GestionTienda gestionTienda = FindObjectOfType<GestionTienda>();
        gestionTienda.SeleccionarMejora(efecto, nivelmejora,mejora);
    }

    public void SelectedDescription()
    {
        int idiom = GameManager.Instance.ChangeLenguageTarget();
        SingletonDescription.Instance.TextMeshDescription(mejora.DescriptionMejora[idiom]);
    }
}

