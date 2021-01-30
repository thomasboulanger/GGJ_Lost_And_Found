using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class StepsSystem : MonoBehaviour
{
    public int nbSteps = 10;

    private static string hiddenText = "???";

    public int AddStep(int index)
    {
        if (index > nbSteps)
            return nbSteps;

        if (index != nbSteps)
        {
            GameObject.Find("GreenDot_" + index).GetComponent<Image>().enabled = true;
            GameObject.Find("TextGoal_" + ++index).GetComponent<TMP_Text>().text = "lala";
        }
        else
        {
            EmergencyPod();
        }
        return index;
    }

    private void EmergencyPod()
    {
        if (Vector2.Distance(transform.position, EndLevel.singleton.EmergencyPod.transform.position) <= 2f)
        {
            GameObject.Find("GreenDot_" + nbSteps).GetComponent<Image>().enabled = true;
            EndLevel.singleton._win = true;
        }
    }

    public int RemoveStep(int index)
    {
        if (GameObject.Find("GreenDot_" + nbSteps).GetComponent<Image>().enabled == true)
        {
            GameObject.Find("GreenDot_" + nbSteps).GetComponent<Image>().enabled = false;
        }
        else
        {
            GameObject.Find("TextGoal_" + index).GetComponent<TMP_Text>().text = hiddenText;

            if (index != 0)
                GameObject.Find("GreenDot_" + --index).GetComponent<Image>().enabled = false;
        }
        
        return index;
    }
}
