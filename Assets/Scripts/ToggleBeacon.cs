using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleBeacon : MonoBehaviour
{
    [SerializeField]
    private GameObject beaconOn;

    private float timer;
    private bool on;

    private void Start()
    {
        timer = 1f;
        on = false;
    }
    void Update()
    {
        if (on)
        {
            timer += Time.deltaTime;
        }
        else
        {
            timer -= Time.deltaTime;
        }

        if (timer <= 0)
        {
            on = true;
        }
        if (timer >=1f)
        {
            on = false;
        }
        beaconOn.SetActive(on);
    }
}
