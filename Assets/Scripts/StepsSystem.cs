using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class StepsSystem : MonoBehaviour
{
    DetectStep detectStep;

    public int nbSteps = 10;

    private static string hiddenText = "???";

    [SerializeField]
    private List<string> textStr = new List<string>();

    [SerializeField]
    private GameObject emergencyPod;

    private void Start()
    {
        detectStep = GetComponent<DetectStep>();

        emergencyPod.SetActive(false);
    }

    public int AddStep(int index)
    {
        if (index > nbSteps)
            return nbSteps;

        if (GameObject.Find("GreenDot_" + (nbSteps - 2)).GetComponent<Image>().enabled == true
            && detectStep.CheckDistance() == true)
           emergencyPod.SetActive(true);

        if (index != nbSteps)
        {
            GameObject.Find("GreenDot_" + index).GetComponent<Image>().enabled = true;
            GameObject.Find("TextGoal_" + ++index).GetComponent<TMP_Text>().text = textStr[index - 2];
        }
        else
        {
            EmergencyPodDetection();
        }

        return index;
    }
  
    private void EmergencyPodDetection()
    {
        if (Vector2.Distance(transform.position, emergencyPod.transform.position) <= 2f)
        {
            GameObject.Find("GreenDot_" + nbSteps).GetComponent<Image>().enabled = true;
            EndLevel.singleton._win = true;
        }
    }

    public int RemoveStep(int index)
    {
        detectStep.canEscape = true;

        if (GameObject.Find("GreenDot_" + (nbSteps)).GetComponent<Image>().enabled == false)
            emergencyPod.SetActive(false);

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
