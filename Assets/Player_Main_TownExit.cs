using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_Main_TownExit : MonoBehaviour
{
    new Town_Data_Storage CurrentTownData;
    new GameObject TownDataStorage;
    new GameObject Camera;

    private bool enterTownKeyPressed;

    //remove me
    // I am removed wtff
    // :)

    // Start is called before the first frame update
    void Start()
    {
        CurrentTownData = GameObject.Find("Town Data Storage").gameObject.GetComponent<Town_Data_Storage>();
        Camera = GameObject.FindWithTag("MainCamera");
    }

    // Update is called once per frame
    void Update()
    {
        GetBubble().transform.parent.transform.LookAt(Camera.transform);
    }
    void OnCollisionEnter(Collision collision)
    {
        Debug.LogWarning("Collided");

    }

    void OnTriggerEnter(Collider colission)
    {
        if (colission.gameObject.tag == "Area Exit")
        {
            Debug.LogWarning("Began colliding with area exit");
            UpdateTextBubbleText();
            GetBubble().SetActive(true);
        }
    }
    private void OnTriggerStay(Collider colission)
    {
        if (colission.gameObject.tag == "Area Exit")
        {
            if (Input.GetKey(KeyCode.E) && enterTownKeyPressed == false)
            {
                Debug.LogWarning($"Pressed E to leave town");

                SceneManager.LoadSceneAsync("SampleScene");
                SceneManager.UnloadSceneAsync("Town_TestTown");
            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        SceneManager.UnloadSceneAsync("SampleScene");
        enterTownKeyPressed = false;
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.tag == "Area Exit")
        {
            GetBubble().SetActive(false);
        }
    }
    private void UpdateTextBubbleText()
    {
        GetBubble().transform.GetChild(0).GetComponent<TextMesh>().text = $"Press 'E' to leave {Environment.NewLine} {CurrentTownData.GetTownName()} ";
    }

    private GameObject GetBubble()
    {
        return gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject;
    }
}
