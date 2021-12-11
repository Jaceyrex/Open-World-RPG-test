using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Dialogue_Trigger : MonoBehaviour
{
    private bool inDialogue = false;

    Dialogue_Data_Storage storage;

    List<Dialogue_Character> leftSpeakers = new List<Dialogue_Character>();
    List<Dialogue_Character> rightSpeakers = new List<Dialogue_Character>();

    private void Start()
    {
        storage = gameObject.GetComponent<Dialogue_Data_Storage>();
        leftSpeakers = storage.leftSpeakers;
        rightSpeakers = storage.rightSpeakers;
    }

    void OnTriggerEnter(Collider colission)
    {
        if (colission.gameObject.tag == "Player")
        {
            Debug.Log("Entered NPC box collider");
            GetBubble(colission.gameObject).SetActive(true);
        }
    }


    private void OnTriggerStay(Collider colission)
    {
        if (colission.gameObject.tag == "Player")
        {
            if (Input.GetKey(KeyCode.E) && inDialogue == false)
            {
                Debug.Log("Attempting to begin dialogue");
                inDialogue = true;
                Dialogue_Script NewDialogue = new Dialogue_Script();
                NewDialogue.NewConversation(leftSpeakers,rightSpeakers);
                //NewDialogue.NewConversation();
            }
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //NewDialogue = null;
        }
    }

    public void setDialogueState (bool currentState)
    {
        inDialogue = currentState;
    }

    private GameObject GetBubble(GameObject player)
    {
        return player.transform.GetChild(3).gameObject;
    }
}
