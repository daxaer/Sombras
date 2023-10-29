using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GuardarJuego : MonoBehaviour,IDataPersiistence
{
    public GameObject buttonContinue;
    public GameObject buttonPlay;
    public GameObject buttonExit;

    public void Guardar()
    {
        DataPersistenceManager.Instance.SaveGame();
    }

    public void LoadData(GameData _data)
    {
        Scene activescene = SceneManager.GetActiveScene();
        if (_data.rondaActual > 0 && activescene.name == "Index")
        {
            buttonContinue.SetActive(true);
            Navigation navPlay = buttonPlay.GetComponent<Button>().navigation;
            navPlay.selectOnUp = buttonContinue.GetComponent<Button>();
            buttonPlay.GetComponent<Button>().navigation = navPlay;


            Navigation navExit = buttonExit.GetComponent<Button>().navigation;
            navExit.selectOnDown = buttonContinue.GetComponent<Button>();
            buttonExit.GetComponent<Button>().navigation = navExit;
        }
        else if(activescene.name == "Index")
        {
            buttonContinue.SetActive(false);
        }
    }

    public void SaveData(ref GameData _data)
    {
        
    }
}
