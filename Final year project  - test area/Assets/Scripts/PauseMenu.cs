using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public Canvas can1;
    public bool timeStopped;

    private void Start()
    {
        can1.gameObject.SetActive(false);
       

    }


    private void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {

            can1.gameObject.SetActive(true);
            TimeStop(); 
        }

        





    }






    public void sceneSwitch(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }
    public void TimeStop()
    {
        Time.timeScale = 0;
        timeStopped = true; 
    }
    public void Continue()
    {
        Time.timeScale = 1;
        timeStopped = false;
    }

}