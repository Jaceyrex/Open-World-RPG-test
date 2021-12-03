using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_OpenWorld_TownInteractionScript : MonoBehaviour
{
    new Openworld_TownScript targetTown;
    //new GameObject TextBubble;
   // new GameObject TextBubbleText;

    private bool enterTownKeyPressed;

    //remove me
    // I am removed wtff
    // :)

    // Start is called before the first frame update
    void Start()
    {
        //TextBubble = gameObject.transform.GetChild(0).gameObject;
        //TextBubbleText = TextBubble.transform.GetChild(0).gameObject;
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
            targetTown = colission.gameObject.transform.parent.GetComponent<Openworld_TownScript>();
            Debug.LogWarning($"STARTED COLIDING with town: {targetTown.GetTownName()}");
            Debug.LogWarning($"Town destination is: {targetTown.GetSceneName()}");

            //Sets the text of the Bubble_Town Entry child Text_Enter Town Text to say press <key used to enter> to enter <Town name>
            UpdateTextBubbleText();
            GetBubble().SetActive(true);
        }
    }

    private void UpdateTextBubbleText()
    {
        GetBubble().transform.GetChild(0).GetComponent<TextMesh>().text = $"Press 'E' to enter {Environment.NewLine} {targetTown.GetTownName()} ";
    }

    private void OnTriggerStay(Collider colission)
    {
        if (colission.gameObject.tag == "Town")
        {
            if (Input.GetKey(KeyCode.E) && enterTownKeyPressed == false)
            {
                VillageStateSaveLoader positionSaver = new VillageStateSaveLoader();
                positionSaver.SaveData(colission.gameObject.transform.parent.gameObject);
                enterTownKeyPressed = true;
                Debug.LogWarning($"Pressed E inside town");

                //TODO: Send data across to new scene or serialise and save as currentTownInfo, use to place player at Exit Point empty
                SceneManager.LoadSceneAsync(targetTown.GetSceneName());
                SceneManager.UnloadSceneAsync("SampleScene");
            }
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        Debug.LogWarning($"Exited {collision.gameObject.name} collider");
        //SceneManager.UnloadSceneAsync(targetTown.GetSceneName());
        enterTownKeyPressed = false;
        targetTown = null;
        GetBubble().SetActive(false);
    }

    private GameObject GetBubble()
    {
        return gameObject.transform.GetChild(0).gameObject;
    }
}
