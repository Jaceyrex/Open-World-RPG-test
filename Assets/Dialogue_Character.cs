using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue_Character : MonoBehaviour
{
    public string speakerName;
    public Image speakerPortrait;

    public Image GetPortrait()
    {
        return speakerPortrait;
    }

    public string GetName()
    {
        return speakerName;
    }
}
