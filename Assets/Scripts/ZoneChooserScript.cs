using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneChooserScript : MonoBehaviour
{

    public GameObject MyZone;
    GameObject GameController;

    public Canvas Menu;

    private void Start()
    {
        GameController = GameObject.FindGameObjectWithTag("GameController");
    }


    private void OnMouseDown()
    {
        GameController.GetComponent<GameController>().DestroyPlayer();
        Debug.Log("Helo");
        Menu.enabled = false;
        GameController.GetComponent<GameController>().StartZone(MyZone);
    }
}
