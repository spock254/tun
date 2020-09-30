using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 4;
    private Vector2 playerDir;
    public static int x_player;
    public static int y_player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        if (Input.GetAxis("Vertical") != 0) 
        {
            if (Input.GetAxis("Vertical") > 0)
            {
                y_player = 1;
            }
            else 
            {
                y_player = -1;
            }
            
            x_player = 0;

            playerDir = new Vector2(0, Input.GetAxisRaw("Vertical"));
        }
        else if (Input.GetAxis("Horizontal") != 0) 
        {
            if (Input.GetAxis("Horizontal") > 0)
            {
                x_player = 1;
            }
            else
            {
                x_player = -1;
            }

            y_player = 0;

            playerDir = new Vector2(Input.GetAxisRaw("Horizontal"), 0);
        
        }
        transform.Translate(playerDir * moveSpeed * Time.deltaTime);
    }
}
