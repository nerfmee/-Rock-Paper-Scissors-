﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DetectObjects : MonoBehaviour
{
    private bool insideScissors = false;
    private bool insideRock = false;
    private bool insidePaper = false;
    
    private bool isCanDestroy;

    private Collider _collider;

    private KeyCode _inputValue;

   [SerializeField] private GameObject _gameOverPanel;
    
    
    [Header("Unity Stuff")] public Image HealthBar;
    public float StartHealth = 100;
    private float health;
    private bool isDead = false;

    [SerializeField] private GameObject _impactEffect;
    [SerializeField] private GameObject _impactNewEffect;
    
    
    
    void Start()
    {
        health = StartHealth;
    }
    
    
    public void TakeDamage(float amount)
    {
        health -= amount;
        HealthBar.fillAmount = health / StartHealth;
        
        if (health <= 0 )
        {
            Die();
        }
    }

    public void Die()
    {
        _gameOverPanel.SetActive(true);
    }
    private void OnTriggerEnter(Collider other)
    {
        PrefabDetection(other.tag, other);
     
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Scissors")
        {
            insideScissors = false;
        }
        if (other.tag == "Rock")
        {
            insideRock = false;
        }
        if (other.tag == "Paper")
        {
            insidePaper = false;
        }
       
    }

    private void PrefabDetection(string otherTag, Collider collider)
    {
        _collider = collider;
        if (otherTag == "Scissors")
        {
            insideScissors = true;
        }
        if (otherTag == "Rock")
        {
            insideRock = true;
        }
        if (otherTag == "Paper")
        {
            insidePaper = true;
        }
    }
    

    private void Update()
    {
        ChangeInputValue();
        if (_inputValue == KeyCode.W)
        {
            if (insideScissors)
            {
                DoEffects();
                insideScissors = false;
            }
            else if (insidePaper || insideRock || insideScissors)
            {
              
                TakeDamage(10);
                _inputValue = KeyCode.Alpha0;
            }
        }
        if (_inputValue == KeyCode.A )
        {
            if (insidePaper)
            {
                DoEffects();
                insidePaper = false;
            }
            else if (insidePaper || insideRock || insideScissors)
            {
                TakeDamage(10);
                _inputValue = KeyCode.Alpha0;
            }
        }
        if (_inputValue == KeyCode.D)
        {
            if (insideRock)
            {
                DoEffects();
                insideRock = false;
            }
            else if (insidePaper || insideRock || insideScissors)
            {
                TakeDamage(10);
                _inputValue = KeyCode.Alpha0;
            }
        }
    }

    private void DoEffects()
    {
        CameraShake.Shake(0.2f,0.5f);
        Instantiate(_impactEffect);
        Instantiate(_impactNewEffect);
        _collider.gameObject.SetActive(false);
    }
    private void ChangeInputValue()
    {
        
        if (Input.GetKeyDown(KeyCode.W) )
        {
            _inputValue = KeyCode.W;
        }
        if (Input.GetKeyDown(KeyCode.A) )
        {
            _inputValue = KeyCode.A;
        }
        if (Input.GetKeyDown(KeyCode.D) )
        {
            _inputValue = KeyCode.D;
        }
    }
}
        
    

