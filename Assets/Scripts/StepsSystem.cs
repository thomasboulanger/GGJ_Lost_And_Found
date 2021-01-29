using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StepsSystem : MonoBehaviour
{
    public int nbSteps = 10;

    private static string hiddenText = "???";

    public int AddStep(int index)
    {
        if (index > nbSteps)
            return nbSteps;

        GameObject.Find("GreenDot_" + index).GetComponent<Image>().enabled = true;

        if (index != nbSteps)
            GameObject.Find("TextGoal_" + ++index).GetComponent<TMP_Text>().text = "lala";

        return index;
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
