using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_SceneChangePositionSolver : MonoBehaviour
{
    Vector3 NewPlayerPos = new Vector3();
    // Start is called before the first frame update
    void Start()
    {
        VillageStateSaveLoader PlayerPosSolver = new VillageStateSaveLoader();
        
        if (PlayerPosSolver.Exists())
        {
            NewPlayerPos = PlayerPosSolver.LoadData();
            gameObject.transform.position = NewPlayerPos;
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
