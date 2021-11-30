using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_TownCameraScript : MonoBehaviour
{
    public float xRotation;
    public float yRotation;
    public float zRotation;

    public string name;
    // Start is called before the first frame update
    void Start()
    {
        name = gameObject.GetComponent<Transform>().name;
    }

    // Update is called once per frame
    void Update()
    {
        xRotation = gameObject.GetComponent<Transform>().eulerAngles.x;
        yRotation = gameObject.GetComponent<Transform>().eulerAngles.y;
        zRotation = gameObject.GetComponent<Transform>().eulerAngles.z;

        if(Input.GetKey(KeyCode.LeftArrow))
        {
            Debug.Log($"y rotation is {gameObject.GetComponent<Transform>().rotation.y}");
            gameObject.GetComponent<Transform>().Rotate(0, 0.5f, 0);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            Debug.Log($"y rotation is {gameObject.GetComponent<Transform>().rotation.y}");
            gameObject.GetComponent<Transform>().Rotate(0, -0.5f, 0);
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            if (gameObject.GetComponent<Transform>().rotation.x < 30.5f)
            {
                Debug.Log($"X rotation is less than 30.5f: {xRotation}");
                gameObject.GetComponent<Transform>().Rotate(0.5f, 0, 0);
            }
            if (gameObject.GetComponent <Transform>().rotation.x > 30.0f)
            {
                Debug.Log($"X rotation is more than 30.0f: {xRotation}");
                gameObject.GetComponent<Transform>().rotation.Set(30.0f, yRotation, zRotation, 0);
            }
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            
            if (gameObject.GetComponent<Transform>().rotation.x > -340.5f)
            {
                Debug.Log($"X rotation is more than -20: {xRotation}");
                gameObject.GetComponent<Transform>().Rotate(-0.5f, 0, 0);
            }
            if (gameObject.GetComponent<Transform>().rotation.x < -340.5f)
            {
                Debug.Log($"X rotation is Less than -20: {xRotation}");
                //gameObject.GetComponent<Transform>().rotation.Set(-20.0f, yRotation, zRotation,0);
                gameObject.GetComponent<Transform>().eulerAngles = new Vector3(-340.5f, yRotation, zRotation);
            }
        }
    }
}
