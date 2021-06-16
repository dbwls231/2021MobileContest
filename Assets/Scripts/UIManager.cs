using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject[] GameUI;

    public void PauseGame()
    {
        foreach (GameObject UI in GameUI)
        {
            if (UI.activeSelf == true)
                UI.SetActive(false);
            else
                UI.SetActive(true);
        }

        Time.timeScale = 0.1f;

        GameUI[3].LeanMoveLocalY(-350, .02f);
        GameUI[4].LeanMoveLocalY(-550, .02f).setOnComplete(TimeStop);
    }

    public void ContinueGame()
    {
        Time.timeScale = 1;

        GameUI[3].LeanMoveLocalY(-150, .001f);
        GameUI[4].LeanMoveLocalY(-150, .001f);

        foreach (GameObject UI in GameUI)
        {
            if (UI.activeSelf == true)
                UI.SetActive(false);
            else
                UI.SetActive(true);
        }

    }

    public void RestartGame()
    {

    }

    public void SettingGame()
    {

    }

    void TimeStop()
    {
        Time.timeScale = 0;
    }
}
