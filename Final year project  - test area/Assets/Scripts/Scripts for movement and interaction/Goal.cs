using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    //goal\\
    public MeshRenderer goalMesh;
    public bool goalHit = false;
    public bool goalCollected = false;
    //level finish\\
    public GameObject goal2;
    public bool levelFinishPoint = false;
    public bool levelFinish = false;
    //stats\\
    public float goalHitTimer = 0f;// for start to goal

    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {


        if (!goalHit)
        {
            goalHitTimer += Time.deltaTime;
        }


        if (goalHit)
        {
            goal2.SetActive(true);
            goalMesh.enabled = false;


        }



    }

    private void OnTriggerEnter(Collider other)
    {
        goalHit = true;
        goalCollected = true;
    }

}

   
