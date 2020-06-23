using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public void HideStartMenu()
    {
        Debug.Log("hi");

        SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
    }
}
