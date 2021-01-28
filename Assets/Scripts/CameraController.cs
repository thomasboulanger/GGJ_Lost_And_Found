using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] 
    private Vector2 offset;
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
        Vector2 targetPosition = target.TransformPoint(offset);
        transform.position = Vector2.Lerp(transform.position, targetPosition, translateSpeed * Time.deltaTime);
    }
}