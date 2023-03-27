using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu_Control : MonoBehaviour
{
    public void onStartClick()
    {
        SceneManager.LoadScene("Scene1");
    }

    public void onEndClick()
    {
        Application.Quit();
    }
}
