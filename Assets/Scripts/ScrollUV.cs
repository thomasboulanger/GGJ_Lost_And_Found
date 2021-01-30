using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollUV : MonoBehaviour
{
    private PlayerActions playerActions;
    [HideInInspector]
    public Vector3 lastPlayerPos;

    public static ScrollUV singleton = null;
    [SerializeField]
    private float bgSpeed = 0.0001f;

    

    private void Start()
    {
        singleton = this;
        playerActions = FindObjectOfType<PlayerActions>();
        lastPlayerPos = playerActions.transform.position;
    }

    private void Update()
    {
        MeshRenderer mr = GetComponent<MeshRenderer>();

        Material mat = mr.material;

        Vector2 offset = mat.mainTextureOffset;

        if (playerActions.transform.position != lastPlayerPos)
        {
            if (playerActions.horizontal > 0.1f)
                offset.x += bgSpeed;
            else if (playerActions.horizontal < -0.1f)
                offset.x -= bgSpeed;

            if (playerActions.vertical > 0.1f)
                offset.y += bgSpeed;
            else if (playerActions.vertical < -0.1f)
                offset.y -= bgSpeed;

          lastPlayerPos = playerActions.transform.position;
        }
        

        mat.mainTextureOffset = offset;
    }
}
