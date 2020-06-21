using System;
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
    
    
    
    [Header("Unity Stuff")] public Image HealthBar;
    public float StartHealth = 100;
    private float health;
    private bool isDead = false;

    [SerializeField] private GameObject _impactEffect;
    
    
    
    void Start()
    {
        health = StartHealth;
    }
    
    
    public void TakeDamage(float amount)
    {
        health -= amount;
        HealthBar.fillAmount = health / StartHealth;
        
        if (health <= 0 && !isDead)
        {
            Die();
        }
    }

    public void Die()
    {
        
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
                Instantiate(_impactEffect);
                _collider.gameObject.SetActive(false);
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
                Instantiate(_impactEffect);
                _collider.gameObject.SetActive(false);
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
                Instantiate(_impactEffect);
                _collider.gameObject.SetActive(false);
                insideRock = false;
            }
            else if (insidePaper || insideRock || insideScissors)
            {
                TakeDamage(10);
                _inputValue = KeyCode.Alpha0;
            }
        }
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
        
    

