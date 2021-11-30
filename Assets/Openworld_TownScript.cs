using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Openworld_TownScript : MonoBehaviour
{
    public string townName;
    public string levelName;

    public string GetTownName()
    {
        return townName;
    }
    public string GetSceneName()
    {
        return levelName;
    }
}
