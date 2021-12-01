using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_Main_TownExit : MonoBehaviour
{
    new Openworld_TownScript targetTown;
    private bool enterTownKeyPressed;

    //remove me
    // I am removed wtff
    // :)

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

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
        targetTown = null;
    }
}
