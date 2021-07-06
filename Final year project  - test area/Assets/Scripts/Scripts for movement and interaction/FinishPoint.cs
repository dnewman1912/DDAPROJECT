using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishPoint : MonoBehaviour
{

    //level finish\\
    public MeshRenderer levelFinishMesh; 
    public bool levelFinishPoint = false;
    public bool levelFinish = false;
    public float finalHitTimer = 0f;// for goal to finish
    public Canvas levelCompletedCan;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!levelFinish)
        {
            FinalPointTimer();
        }
        if (levelFinish)
        {
            levelFinishMesh.enabled = false;
            LevelFinished(); 
        }



        
    }

    private void OnTriggerEnter(Collider other)
    {
       
        levelFinish = true;
        
    }

    public void FinalPointTimer()
    {
        finalHitTimer += Time.deltaTime;
    }


    private void LevelFinished()
    {
        if (levelFinish == true)
        {
            Time.timeScale = 0f;
            levelCompletedCan.gameObject.SetActive(true);
        }

    }

}

