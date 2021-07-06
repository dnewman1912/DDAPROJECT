using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneSwitchTS : MonoBehaviour
{
    public float timer;
    public bool timerSwitch = false;
   

    void Update()
    {
        if (timerSwitch == true)
        {
            timer += Time.deltaTime;

        }
        if (timer >= 2)
        {
            SceneManager.LoadScene(1);

        }

        
    }
    public void delay()
    {
         switcher();
       
    }
    
    public void sceneSwitch(int sceneIndex)
    {
       

       SceneManager.LoadScene(sceneIndex);
           
        
       
        
    }   
   
    
    private void switcher()
    {
        timerSwitch = true; 
    }


    public void Quit()
    {
        Application.Quit();
    }

}
