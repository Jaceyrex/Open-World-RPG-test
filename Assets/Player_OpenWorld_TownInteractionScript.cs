using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_OpenWorld_TownInteractionScript : MonoBehaviour
{
    new Openworld_TownScript targetTown;
    private bool enterTownKeyPressed;

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

    }

    void OnTriggerEnter(Collider colission)
    {
        if (colission.gameObject.tag == "Town")
        {  
            targetTown = colission.gameObject.GetComponent<Openworld_TownScript>();
            Debug.LogWarning($"STARTED COLIDING with town: {targetTown.GetTownName()}");
            Debug.LogWarning($"Town destination is: {targetTown.GetSceneName()}");
        }
    }
    private void OnTriggerStay(Collider colission)
    {
        if (colission.gameObject.tag == "Town")
        {
            if (Input.GetKey(KeyCode.E) && enterTownKeyPressed == false)
            {
                enterTownKeyPressed = true;
                Debug.LogWarning($"Pressed E inside town");

                //TODO: Send data across to new scene or serialise and save as currentTownInfo, use to place player at Exit Point empty
                SceneManager.LoadSceneAsync(targetTown.GetSceneName());
                SceneManager.UnloadSceneAsync("SampleScene");
            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        SceneManager.UnloadSceneAsync(targetTown.GetSceneName());
        enterTownKeyPressed = false;
        targetTown = null;
    }  
}
