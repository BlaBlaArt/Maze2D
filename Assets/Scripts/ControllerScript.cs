using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerScript : MonoBehaviour
{
    public float Speed;

    private Rigidbody2D rb;

    float vel_x,vel_y;

    float velociti_x
    {
        set
        {
            vel_x = value;

            if(vel_x < -10)
            {
                vel_x = -10;
            }
            else if(vel_x > 10)
            {
                vel_x = 10;
            }
        }

        get
        {
            return vel_x;
        }
    }

    float velociti_y
    {
        set
        {
            vel_y = value;

            if(vel_y < -10)
            {
                vel_y = -10;
            }
            else if(vel_y > 10)
            {
                vel_y = 10;
            }
        }

        get
        {
            return vel_y;
        }
    }

    Vector2 MousePosStart;
    Vector2 MousePosDrag;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnMouseDown()
    {
        MousePosStart = Input.mousePosition;
    }

    private void OnMouseDrag()
    {
        MousePosDrag = Input.mousePosition;

        velociti_x = (MousePosDrag.x - MousePosStart.x) * Speed * Time.deltaTime;
        velociti_y = (MousePosDrag.y - MousePosStart.y) * Speed * Time.deltaTime;
        rb.velocity = new Vector2(velociti_x,velociti_y);
    }

    private void OnMouseUp()
    {
        rb.velocity = new Vector2(0, 0);
    }

}
