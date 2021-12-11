using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue_Script : MonoBehaviour
{
    bool isDialogue = false;
    private List<Dialogue_Character> leftSpeakers;
    private List<Dialogue_Character> rightSpeakers;

    List<Image> leftPortraits = new List<Image>();
    List<Image> rightPortraits = new List<Image>();

    NPC_Dialogue_Trigger startDialogueScript;

    public Canvas canvas;
    public GameObject canvasObj;
    Player_OpenWorld_Movement playerMovement;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isDialogue)
        {

        }
    }

    public void NewConversation(List<Dialogue_Character> left, List<Dialogue_Character> right)
    {
        Debug.Log("New dialogue started");

        //testing bit, remove parts
        isDialogue = false;

        //Getting the canvas object and enabling it
        canvasObj = GameObject.FindWithTag("UI_Canvas");
        canvas = canvasObj.GetComponent<Canvas>();
        canvas.enabled = true;

        playerMovement = GameObject.FindWithTag("Player").GetComponent<Player_OpenWorld_Movement>();
        Debug.Log("Got playerMovement Script");
        Debug.Log($"Called: {playerMovement.name.ToString()}");

        //leftPortraits.Add(gameObject.transform.GetChild(0).transform.GetChild(2).gameObject.GetComponent<Image>());
        //leftPortraits.Add(gameObject.transform.GetChild(0).transform.GetChild(3).gameObject.GetComponent<Image>());

       // rightPortraits.Add(gameObject.transform.GetChild(0).transform.GetChild(4).gameObject.GetComponent<Image>());
        //rightPortraits.Add(gameObject.transform.GetChild(0).transform.GetChild(5).gameObject.GetComponent<Image>());

        startDialogueScript = GameObject.FindGameObjectWithTag("Player").GetComponent<NPC_Dialogue_Trigger>();

        foreach (Image portrait in leftPortraits)
        {
            portrait.enabled = false;
        }
        foreach (Image portrait in rightPortraits)
        {
            portrait.enabled = false;
        }

        //Setting the internal lists for conversation participants to be the values passed into the method
        leftSpeakers = left;
        rightSpeakers = right;

        foreach (Dialogue_Character character in leftSpeakers)
        {
            Debug.LogWarning($"Left Character: {character.GetName()}");
        }
        foreach (Dialogue_Character character in rightSpeakers)
        {
            Debug.LogWarning($"Right Character: {character.GetName()}");
        }


        List<string> allDialogue = new List<string>();
        playerMovement.enabled = false;
        //Debug.Log("Player movement should be disabled");
        //canvas.SetActive(true);
        //SetPortraits(); //Sets to the portaits to be used in current dialogue


        //startDialogueScript.setDialogueState(false);
        Debug.LogWarning("Finished dialog");
    }

    void SetPortraits() //Sets portraits depending on number of speakers
    {
        Debug.Log("Setting portraits");
        int index = 0;
        foreach (Dialogue_Character speaker in leftSpeakers)
        {
            //Sets source image of each left speaker to the provided image
            leftPortraits[index] = speaker.GetPortrait();
            leftPortraits[index].enabled = true;
            index++;
        }

        index = 0; //Resets index to 0 to restart loop at correct point for right speakers

        foreach (Dialogue_Character speaker in rightSpeakers)
        {
            //Sets source image of each right speaker to the provided image
            rightPortraits[index] = speaker.GetPortrait();
            leftPortraits[index].enabled = true;
            index++;
        }
    }
}
