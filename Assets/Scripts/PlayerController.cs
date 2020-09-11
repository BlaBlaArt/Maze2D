using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    public float Speed = 1;

    private GameObject GameController;

    public float speed;

    public GameObject VarJoystick;

    public VariableJoystick variableJoystick;


    private void Start()
    {
        VarJoystick = GameObject.FindGameObjectWithTag("VariableJoystick");

        variableJoystick = VarJoystick.GetComponent<VariableJoystick>();

        rb = GetComponent<Rigidbody2D>();
        GameController = GameObject.FindGameObjectWithTag("GameController");
    }

    public void FixedUpdate()
    {
        Vector2 direction = Vector2.up * variableJoystick.Vertical + Vector2.right * variableJoystick.Horizontal;
        rb.AddForce(direction * speed * Time.fixedDeltaTime, ForceMode2D.Force);
    }

    private void Update()
    {
        if (Input.GetButtonDown("Horizontal"))
        {
            MoveHorizontal();
        }

        if (Input.GetButtonDown("Vertical"))
        {
            MoveVertical();
        }                           
    }

    private void MoveHorizontal()
    {
        rb.velocity = new Vector2(Input.GetAxis("Horizontal") * Speed, 0);
    }

    private void MoveVertical()
    {
        rb.velocity = new Vector2(0, Input.GetAxis("Vertical") * Speed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Debug.Log("hello" + collision.name);

  /*      transform.position = collision.transform.position;
        rb.velocity = Vector2.zero;
        collision.GetComponent<CellScript>().ChangeMyObject(this.gameObject);*/

        if(collision.GetComponent<CellScript>().myStat == 3)
        {
            GameController.GetComponent<GameController>().EndZone();
        }
    }


}
