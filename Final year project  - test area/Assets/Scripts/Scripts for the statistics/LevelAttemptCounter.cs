using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelAttemptCounter : MonoBehaviour
{

    public int levelAttempts;
    public static LevelAttemptCounter instance = null;

    // Start is called before the first frame update
    void Awake()
    {

        if (instance != null)
        {
            Destroy(gameObject);
        }

        else
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
        }

       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LevelAttemptsIncrease()
    {
        levelAttempts++;
    }

    public void LevelAttemptsReset()
    {
        levelAttempts = 0 ;
    }
}
