using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Transform target;

    [SerializeField] 
    private float translateSpeed;

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        transform.position = new Vector3(target.transform.position.x ,target.transform.position.y, transform.position.z);
    }

    private void FixedUpdate()
    {
        HandleTranslation();
    }

    private void HandleTranslation()
    {
        transform.position = Vector3.Lerp(transform.position,  new Vector3(target.position.x, target.position.y, transform.position.z), translateSpeed * Time.deltaTime);
    }
}