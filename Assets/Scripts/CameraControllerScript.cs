using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControllerScript : MonoBehaviour
{
    public GameObject Player;

    public static bool checkPlayer = true;

    private Vector2 MousePos;

    public bool MapActive;

    public float MaxSpeed;
    float cntrlspd;
    private float controllerSpeed
    {
        set
        {

            cntrlspd = value;
            if(Mathf.Abs(cntrlspd) >= MaxSpeed)
            {
                if(cntrlspd > 0)
                {
                    cntrlspd = MaxSpeed;
                }
                else
                {
                    cntrlspd = -MaxSpeed;
                }
            }
        }
        get
        {
            return cntrlspd;
        }
    }

    public GameObject CameraControl;
    Rigidbody2D rbControl;

    public float Speed;

    private void Start()
    {
        MapActive = false;
        rbControl = CameraControl.GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (MapActive)
        {

            if (Input.GetMouseButtonDown(0))
            {
                Debug.Log("down");
                MousePos = Input.mousePosition;
            }

            if (Input.GetMouseButton(0))
            {

                Debug.Log("slide");

                controllerSpeed = (MousePos.y - Input.mousePosition.y) * Speed * Time.deltaTime;

                rbControl.velocity = new Vector2(0, controllerSpeed);

            }

            if (Input.GetMouseButtonUp(0))
            {
                MousePos = new Vector2(0, 0);
                rbControl.velocity = new Vector2(0, 0);
            }
        }

    }

    private void Update()
    {
        if (checkPlayer)
        {
            if (Player != null)
                transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y, transform.position.z);
        }
    }

    public void PlayerSpawn()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }
}
