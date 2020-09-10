using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public bool ConstrucktorMode;

    public GameObject Player;

    public Canvas WinCanvas;

    Camera cam;

    public GameObject[,] Cells_zone = new GameObject[20, 20];

    public GameObject TMPZone;

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

    public void StartZone(GameObject zone)
    {
        TMPZone = Instantiate<GameObject>(zone);

        TMPZone.transform.position = new Vector3(1000, 1000, 0);
        cam.transform.position = new Vector3(1000, 1000, cam.transform.position.z);
    }

    public void DestroyPlayer()
    {
        Destroy(Player.gameObject);
    }

    public void EndZone()
    {
        WinCanvas.enabled = true;
    }

    public void DestroyZone_Player()
    {
        DestroyPlayer();

        Destroy(TMPZone.gameObject);
    }

    public void RestartZoneAboutPlayer()
    {
        GameObject SpawnPlayerCell = GameObject.FindGameObjectWithTag("PlyerSpawn");
        Player.transform.position = new Vector3(SpawnPlayerCell.transform.position.x, SpawnPlayerCell.transform.position.y, Player.transform.position.z);
    }
}