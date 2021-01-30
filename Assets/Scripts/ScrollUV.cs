﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollUV : MonoBehaviour
{
    private PlayerActions playerActions;

    [SerializeField]
    private float bgSpeed = 0.0001f;

    private void Start()
    {
        playerActions = FindObjectOfType<PlayerActions>();
    }

    private void Update()
    {
        MeshRenderer mr = GetComponent<MeshRenderer>();

        Material mat = mr.material;

        Vector2 offset = mat.mainTextureOffset;

        if(playerActions.horizontal > 0.1f)
            offset.x += bgSpeed; 
        else if (playerActions.horizontal < - 0.1f)
            offset.x -= bgSpeed;

        if (playerActions.vertical > 0.1f)
            offset.y += bgSpeed;
        else if (playerActions.vertical < - 0.1f)
            offset.y -= bgSpeed;

        mat.mainTextureOffset = offset;
    }
}