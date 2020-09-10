using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CellScript : MonoBehaviour
{
    // 1 = nothing, 2 = wall, 3 = enemy, 4 = spawnZone
    public int myStat = 0;

    int countmouseDown = 0;

    public int MyRow;
    public int MyCollumn;

    public GameObject WhoOnMe;

    BoxCollider2D myCol;

    public Color Wall;
    public Color None;
    public Color Enemy;
    public Color SpawnPlayer;
    public enum Collors
    {
        wall = 1,
        none,
        enemy,
        spawnPlayer
    }

    private void Start()
    {
        myCol = GetComponent<BoxCollider2D>();
        IsTriggerCheck(myStat);

    }

    public void SetCollor(Collors col)
    {
        switch (col)
        {
            case Collors.wall:
                {
                    GetComponent<Image>().color = Wall;
                    myStat = (int)col;
                    break;
                }

            case Collors.none:
                {
                    GetComponent<Image>().color = None;
                    myStat = (int)col;
                    IsTriggerCheck(myStat);

                    break;
                }

            case Collors.enemy:
                {
                    GetComponent<Image>().color = Enemy;
                    myStat = (int)col;
                    IsTriggerCheck(myStat);

                    break;
                }
            case Collors.spawnPlayer:
                {
                    GetComponent<Image>().color = SpawnPlayer;
                    myStat = (int)col;
                    IsTriggerCheck(myStat);

                    break;
                }
        }
    }

    public void IsTriggerCheck(int stat)
    {
        switch (stat)
        {
            case 1:
                {
                    myCol.isTrigger = false;

                    break;
                }

            case 2:
                {
                    myCol.isTrigger = true;

                    break;
                }

            case 3:
                {
                    if(myCol != null)
                        myCol.isTrigger = true;

                    break;
                }
            case 4:
                {
                    if(myCol != null)
                        myCol.isTrigger = true;

                    break;
                }
        }
    }

    public void ChangeMyObject(GameObject myObj)
    {
        if(myObj == null)
        {
            WhoOnMe = null;
        }
        else
        {
            WhoOnMe = myObj;
        }
    }

    private void OnMouseDown()
    {
        switch (countmouseDown)
        {
            case 0:
                {
                    SetCollor(Collors.none);
                    countmouseDown++;
                    break;
                }
            case 1:
                {
                    SetCollor(Collors.wall);
                    countmouseDown++;
                    break;
                }
            case 2:
                {
                    SetCollor(Collors.enemy);
                    countmouseDown++;
                    break;
                }
            case 3:
                {
                    SetCollor(Collors.spawnPlayer);
                    this.gameObject.tag = "PlyerSpawn";
                    countmouseDown = 0;
                    break;
                }
        }
    }
}
