using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MenuManager : MonoBehaviour
{

    
    public void StartLevel()
    {
        SceneManager.LoadScene("Ocean");
    }
    public void eXIT()
    {
        Application.Quit();
    }
}
