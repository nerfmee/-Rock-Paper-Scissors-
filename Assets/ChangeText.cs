using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeText : MonoBehaviour
{
    private Text _text;

    private void Start()
    {
        _text = gameObject.GetComponent<Text>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            _text.text = "↑";
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            _text.text = "←";
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            _text.text = "→";
        }
    }
}
