using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ControlBotones : MonoBehaviour {

    public Text textopausa;

    public void Jugar()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
	public void salir()
    {
        Debug.Log("Salir");
        Application.Quit();
    }

    public void pausa()
    {
        if (Time.timeScale == 1)
        {    //si la velocidad es 1
            Time.timeScale = 0;     //que la velocidad del juego sea 0
            textopausa.text = "Play";
        }
        else if (Time.timeScale == 0)
        {   // si la velocidad es 0
            Time.timeScale = 1;     // que la velocidad del juego regrese a 1
            textopausa.text = "Pausa";
        }
    }
}
