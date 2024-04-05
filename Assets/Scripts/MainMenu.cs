using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
   public void Jugar()
    {
       StartCoroutine(CargarJugar());
    }

    public void Salir()
    {
        StartCoroutine(SalirDelay());
    }

    IEnumerator CargarJugar() 
    {
        yield return new WaitForSeconds(0.75f);
        SceneManager.LoadScene("Game");
    }

    IEnumerator SalirDelay()
    {
        yield return new WaitForSeconds(0.75f);
        Application.Quit();
    }


}
