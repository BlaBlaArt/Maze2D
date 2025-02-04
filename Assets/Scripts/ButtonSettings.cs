﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSettings : MonoBehaviour
{
    private GameObject GameController;

    public Canvas Menu, ChouseLevel, WinCanvas, ControllerCanvas, OnPauseCanvas, OnPlay, MapCanvas;

    private void Start()
    {
        GameController = GameObject.FindGameObjectWithTag("GameController");
    }

    public void ChoseLevelEnabled()
    {
        MapCanvas.enabled = true;
   
        Menu.enabled = false;
        ChouseLevel.enabled = true;
        ControllerCanvas.enabled = false;
    }

    public void ChoseLevelDisabled()
    {
        MapCanvas.enabled = false;

        Menu.enabled = true;
        ChouseLevel.enabled = false;
        ControllerCanvas.enabled = false;

    }

    public void BackToMenu()
    {
        Debug.Log("Backtomenu");

        Menu.enabled = true;
        ChouseLevel.enabled = false;
        WinCanvas.enabled = false;
        ControllerCanvas.enabled = false;
        OnPlay.enabled = false;
        GameController.GetComponent<GameController>().DestroyZone_Player();

        StartCoroutine("ReturnCamera");
    }

    public void RestartZone()
    {
        WinCanvas.enabled = false;
        ControllerCanvas.enabled = true;
        OnPlay.enabled = true;


        GameController.GetComponent<GameController>().RestartZoneAboutPlayer();
    }

    public void OnPlay_OpenPause()
    {
        OnPlay.enabled = false;

        ControllerCanvas.enabled = false;
        OnPauseCanvas.enabled = true;
    }

    public void OnPlay_ClosePause()
    {
        OnPlay.enabled = true;

        ControllerCanvas.enabled = true;
        OnPauseCanvas.enabled = false;
    }

    IEnumerator ReturnCamera()
    {
        yield return new WaitForSeconds(0.5f);
        Camera.main.transform.position = new Vector3(0, 0, Camera.main.transform.position.z);


    }
}
