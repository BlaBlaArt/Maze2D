using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnerCellsScript : MonoBehaviour
{
    [SerializeField] int CellCount = 400;
    public GameObject CellPref;
    GameObject GameController;
    public GameObject Player;

    void Start()
    {
        GameController = GameObject.FindGameObjectWithTag("GameController");
        Debug.Log(GameController.name);

        if(this.gameObject.name != "ZoneBackground")
        {
            SpawnCells();
        }
        else
        {
            StartCoroutine("SpawnPlayerOnZone");
        }
       
    }

    IEnumerator SpawnPlayerOnZone()
    {
        yield return new WaitForSeconds(0.5f);

        GameObject SpawnPlayerCell = GameObject.FindGameObjectWithTag("PlyerSpawn");
        GameObject tmpPlayer = Instantiate<GameObject>(Player);
        tmpPlayer.transform.position = new Vector3(SpawnPlayerCell.transform.position.x, SpawnPlayerCell.transform.position.y, tmpPlayer.transform.position.z);
        Camera.main.GetComponent<CameraControllerScript>().PlayerSpawn();
        GameController.GetComponent<GameController>().Player = tmpPlayer;
    }

    private void SpawnCells()
    {
        int count = 1;

        int cellRowCount = CellCount / 20 - 1;
        int cellColumnCount = CellCount / 20 - 1;


        for (int row = 0; row <= cellRowCount; row++)
        {
            for (int collumn = 0; collumn <= cellColumnCount; collumn++)
            {
                GameObject tmpcell = Instantiate<GameObject>(CellPref);
                tmpcell.GetComponent<CellScript>().MyRow = row;
                tmpcell.GetComponent<CellScript>().MyCollumn = collumn;

           //     GameController.GetComponent<GameController>().Cells_zone[row, collumn] = tmpcell;

                tmpcell.transform.SetParent(this.transform, false);


                if (row == 0 || row == 19 || collumn == 0 || collumn == 19)
                {
                    tmpcell.GetComponent<CellScript>().SetCollor(CellScript.Collors.wall);
                }
                if (row == 2 && collumn == 2)
                {
                    StartCoroutine("SpawnPlayer", tmpcell);

                }

                tmpcell.name = ("" + row + collumn);


                count++;
            }
        }
    }

    private void SpawnEnemyZone()
    {
        int randomRow = Random.Range(1, 18);
        int randomColumn = Random.Range(1, 18);

        GameController.GetComponent<GameController>().Cells_zone[randomRow, randomColumn].
            GetComponent<CellScript>().SetCollor(CellScript.Collors.enemy);
    }

    IEnumerator SpawnPlayer(GameObject tmpcell)
    {
        yield return new WaitForSeconds(0.5f);

        GameObject tmpPlayer = Instantiate<GameObject>(Player);
        tmpPlayer.transform.position = new Vector3(tmpcell.transform.position.x, tmpcell.transform.position.y, tmpPlayer.transform.position.z);
        Camera.main.GetComponent<CameraControllerScript>().PlayerSpawn();
        GameController.GetComponent<GameController>().Player = tmpPlayer;
    }

}
