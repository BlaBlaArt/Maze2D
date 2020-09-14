using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapPanelScript : MonoBehaviour
{

    Camera cam;


    private Vector2 MousePos;

    public bool MapActive;

    public float MaxSpeed;
    float cntrlspd;
    private float controllerSpeed
    {
        set
        {

            cntrlspd = value;
            if (Mathf.Abs(cntrlspd) >= MaxSpeed)
            {
                if (cntrlspd > 0)
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

        cam = Camera.main;
    }

    private void OnMouseDown()
    {
        MousePos = Input.mousePosition;
    }

    private void OnMouseDrag()
    {

        controllerSpeed = (MousePos.y - Input.mousePosition.y) * Speed * Time.deltaTime;

        rbControl.velocity = new Vector2(0, controllerSpeed);
    }

    private void OnMouseUp()
    {
        MousePos = new Vector2(0, 0);
        rbControl.velocity = new Vector2(0, 0);
    }
}
