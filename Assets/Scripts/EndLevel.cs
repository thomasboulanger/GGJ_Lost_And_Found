using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndLevel : MonoBehaviour
{
    [SerializeField]
    private GameObject fadeScreen;
    
    public GameObject EmergencyPod;


    public static EndLevel singleton = null;


    public bool _win;
    private Color _tempColor;
    private Image _image;

    private void Awake()
    {
        singleton = this;
    }

    void Start()
    {
        _win = false;
        _image = fadeScreen.GetComponent<Image>();
    }

    void Update()
    {
        if (_win == true)
        {
            fadeScreen.SetActive(true);
            if (_tempColor.a < 1)
            {
                _tempColor = _image.color;
                _tempColor.a += Time.deltaTime;
                _image.color = _tempColor;
            }
            else
            {
                return;
            }
        }
        else
        {
            fadeScreen.SetActive(false);
            if (_tempColor.a > 0)
            {
                _tempColor = _image.color;
                _tempColor.a -= Time.deltaTime;
                _image.color = _tempColor;
            }
            else
            {
                return;
            }
        }
    }
}
