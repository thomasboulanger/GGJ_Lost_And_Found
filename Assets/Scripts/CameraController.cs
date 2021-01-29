using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] 
    private Vector3 offset;
    [SerializeField] 
    private Transform target;
    [SerializeField] 
    private float translateSpeed;

    private void Update()
    {
        HandleTranslation();
    }

    private void HandleTranslation()
    {
        //Vector2 targetPosition = target.TransformPoint(offset);
        transform.position = Vector2.Lerp(transform.position, /*targetPosition*/ new Vector3(target.position.x, target.position.y, transform.position.z
            ), translateSpeed * Time.deltaTime);
    }
}