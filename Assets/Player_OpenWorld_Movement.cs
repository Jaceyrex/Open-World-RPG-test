using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_OpenWorld_Movement : MonoBehaviour
{
    float baseMoveSpeed = 10.0f;
    float sprintMod = 1.5f;
    float walkMod = 0.5f;
    public float finalMoveSpeed;
    bool walkedThisFrame;

    private enum Direction { Left, Right, Up, Down }
    private Direction dir;

    // Start is called before the first frame update
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        walkedThisFrame = false;
        InputChecks();
    }

    private void InputChecks() //Checks user input for movement keys
    {
        finalMoveSpeed = 0;
        if (Input.GetKey(KeyCode.LeftControl))
        {
            //Debug.Log("walk key down");
            finalMoveSpeed = (baseMoveSpeed * walkMod);

            if (Input.GetKey(KeyCode.A))
            {
                dir = Direction.Left;
                //Debug.Log("A AND walk");
                MovePlayer(dir, finalMoveSpeed);
            }
            if (Input.GetKey(KeyCode.D))
            {
                dir = Direction.Right;
                //Debug.Log("D AND walk");
                MovePlayer(dir, finalMoveSpeed);
            }
            if (Input.GetKey(KeyCode.S))
            {
                dir = Direction.Down;
               // Debug.Log("S AND walk");
                MovePlayer(dir, finalMoveSpeed);
            }
            if (Input.GetKey(KeyCode.W))
            {
                dir = Direction.Up;
                //Debug.Log("W AND walk");
                MovePlayer(dir, finalMoveSpeed);
            }
        }
        //if (!walkedThisFrame)
        //{
        else if (Input.GetKey(KeyCode.LeftShift))
        {
            //Debug.Log("SPRINT key down");
            finalMoveSpeed = (baseMoveSpeed * sprintMod);

            if (Input.GetKey(KeyCode.A))
            {
                dir = Direction.Left;
                //Debug.Log("A AND SPRINT");
                MovePlayer(dir, finalMoveSpeed);
            }
            if (Input.GetKey(KeyCode.D))
            {
                dir = Direction.Right;
                //Debug.Log("D AND SPRINT");
                MovePlayer(dir, finalMoveSpeed);
            }
            if (Input.GetKey(KeyCode.S))
            {
                dir = Direction.Down;
                //Debug.Log("S AND SPRINT");
                MovePlayer(dir, finalMoveSpeed);
            }
            if (Input.GetKey(KeyCode.W))
            {
                dir = Direction.Up;
                //Debug.Log("W AND SPRINT");
                MovePlayer(dir, finalMoveSpeed);
            }
        }
        else
        {
            finalMoveSpeed = baseMoveSpeed;
            if (Input.GetKey(KeyCode.A))
            {
                dir = Direction.Left;
                //Debug.Log("A");
                MovePlayer(dir, finalMoveSpeed);
            }
            if (Input.GetKey(KeyCode.D))
            {
                dir = Direction.Right;
                //Debug.Log("D");
                MovePlayer(dir, finalMoveSpeed);
            }
            if (Input.GetKey(KeyCode.S))
            {
                dir = Direction.Down;
                //Debug.Log("S");
                MovePlayer(dir, finalMoveSpeed);
            }
            if (Input.GetKey(KeyCode.W))
            {
                dir = Direction.Up;
                //Debug.Log("W");
                MovePlayer(dir, finalMoveSpeed);
            }
        }
        //}
        
    }
    private void MovePlayer(Direction dir, float finalMoveSpeed)
    {
        //walkedThisFrame = true;
        switch (dir)
        {
            case Direction.Up:
                {
                    this.gameObject.transform.Translate(new Vector3(0.0f,0.0f, finalMoveSpeed * Time.deltaTime));
                    //Debug.Log($"Moving {dir} this fast: {finalMoveSpeed}");
                    break;
                }
            case Direction.Down:
                {
                    this.gameObject.transform.Translate(new Vector3(0.0f, 0.0f, -finalMoveSpeed * Time.deltaTime));
                    //Debug.Log($"Moving {dir} this fast: {finalMoveSpeed}");
                    break;
                }
            case Direction.Left:
                {
                    this.gameObject.transform.Translate(new Vector3(-finalMoveSpeed * Time.deltaTime,0.0f,  0.0f));
                    //Debug.Log($"Moving {dir} this fast: {finalMoveSpeed}");
                    break;
                }
            case Direction.Right:
                {
                    this.gameObject.transform.Translate(new Vector3(finalMoveSpeed * Time.deltaTime,0.0f,  0.0f));
                    //Debug.Log($"Moving {dir} this fast: {finalMoveSpeed}");
                    break;
                }
        }
    }
}
