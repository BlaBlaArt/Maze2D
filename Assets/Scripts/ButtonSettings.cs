using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSettings : MonoBehaviour
{
    private GameObject GameController;

    public Canvas Menu, ChouseLevel, WinCanvas, ControllerCanvas;

    private void Start()
    {
        GameController = GameObject.FindGameObjectWithTag("GameController");
    }

    public void ChoseLevelEnabled()
    {
        Menu.enabled = false;
        ChouseLevel.enabled = true;
        ControllerCanvas.enabled = false;
    }

    public void ChoseLevelDisabled()
    {
        Menu.enabled = true;
        ChouseLevel.enabled = false;
        ControllerCanvas.enabled = false;

    }

    public void BackToMenu()
    {
        Menu.enabled = true;
        ChouseLevel.enabled = false;
        WinCanvas.enabled = false;
        ControllerCanvas.enabled = false;

        GameController.GetComponent<GameController>().DestroyZone_Player();
    }

    public void RestartZone()
    {
        WinCanvas.enabled = false;
        ControllerCanvas.enabled = true;


        GameController.GetComponent<GameController>().RestartZoneAboutPlayer();
    }
}
