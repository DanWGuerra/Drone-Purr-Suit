using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    float Tiempo;
    [SerializeField]
    TextMeshProUGUI TextoTiempo;
    [SerializeField]
    GameObject GameOverUI;
    [SerializeField]
    DronController DronControl;
    [SerializeField]
    GameObject WinUI;

    [SerializeField]
    DronController DronControl2;

    [SerializeField]
    TextMeshProUGUI TextoJugadorWin;
    [SerializeField]
    TextMeshProUGUI TextoJugadorLose;

    bool WinBool;

    [SerializeField]
    GameObject PauseMenu;

    bool pausado = false;

    // Update is called once per frame
    void Update()
    {
       
        if(Tiempo > 0 && !WinBool)
        {
            ActualizarTimer();
        }
        else if(Tiempo <= 0 && !WinBool)
        {
            GameOver();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pausar();
        }
    }

    void ActualizarTimer()
    {
        Tiempo -= Time.deltaTime;
        TextoTiempo.text = Tiempo.ToString("F2");
    }

    void GameOver()
    {
        Tiempo = 0.00f;
        TextoTiempo.text = Tiempo.ToString("F2");
        DronControl.enabled = false;
        GameOverUI.SetActive(true);
    }

    public void Win(string PLayerWin, string PlayerLose)
    {
        WinBool = true;
        WinUI.SetActive(true);
        DronControl.enabled = false;
        DronControl2.enabled = false;
        TextoJugadorWin.text = PLayerWin;
        TextoJugadorLose.text = PlayerLose;
    }

    public void Reintentar()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Game");
    }


    public void Salir()
    {
        Application.Quit();
    }

    public void Pausar()
    {
        if (pausado)
        {
            pausado = false;
            PauseMenu.SetActive(false);
            Time.timeScale = 1;
        }
        else
        {
            pausado = true;
            PauseMenu.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
