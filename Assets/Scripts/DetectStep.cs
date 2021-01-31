using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DetectStep : MonoBehaviour
{
    PlayerActions playerActions;

    StepsSystem stepsSystem;

    public List<GameObject> stepsObjects = new List<GameObject>();

    [SerializeField]
    private float distObj = 5f;

    public bool canEscape;

    private void Start()
    {
        playerActions = GetComponent<PlayerActions>();
        stepsSystem = GetComponent<StepsSystem>();

        canEscape = true;
    }

    private void Update()
    {
        canEscape = CheckDistance();
        Debug.Log(canEscape);
    }

    public bool CheckDistance()
    {
        if(playerActions.beaconsList.Count != 0)
        {
            for (int i = playerActions.beaconsList.Count; i < stepsSystem.nbSteps; i++)
            {
                if (playerActions.beaconsList.Count == i)
                {
                    if (Vector2.Distance(stepsObjects[i - 1].transform.position, playerActions.beaconsList[i - 1].transform.position) > distObj)
                    {
                        canEscape = false;

                        if (canEscape == false)
                        {
                            GameObject.Find("GreenDot_" + i).GetComponent<Image>().enabled = false;
                        }
                    }
                }
            }
        }
        

        return canEscape;
    }

    void OnDrawGizmos()
    {
        // Draw a yellow sphere at the transform's position
        Gizmos.color = Color.yellow;

        for (int i = 0; i < stepsSystem.nbSteps - 1; i++)
        {
            Gizmos.DrawSphere(stepsObjects[i].transform.position, distObj);
        }
    }
}
