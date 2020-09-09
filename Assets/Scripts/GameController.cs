using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public bool ConstrucktorMode;

    public GameObject Player;

    Camera cam;

    public GameObject[,] Cells_zone = new GameObject[20, 20];

    private void Start()
    {
        cam = Camera.main;

    }

    private void Update()
    {
        if (ConstrucktorMode)
        {

            Destroy(Player.gameObject);
            cam.transform.position = new Vector3(0, 0, cam.transform.position.z);
            cam.orthographicSize = 50;
        }
    }


}