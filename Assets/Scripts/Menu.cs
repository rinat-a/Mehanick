using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    [SerializeField] GameObject MenuPanel;
    bool isTimeScale = false;
    public void OpenMenu()
    {
        MenuPanel.SetActive(true);
    }
    public void CloseMenu()
    {
        MenuPanel.SetActive(false);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
    public void Pause()
    {
        if (Time.timeScale == 0)
            Time.timeScale = 1;
        else
            Time.timeScale = 0;
    }
}
