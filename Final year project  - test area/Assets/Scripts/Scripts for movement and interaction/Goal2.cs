using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal2 : MonoBehaviour
{
    //goal\\
    public MeshRenderer goalMesh;
    public bool goalHit = false;
    public bool goalCollected = false;
    //level finish\\
    public GameObject finishPoint;
    public bool levelFinishPoint = false;
    public bool levelFinish = false;
    //stats\\
    public float goalHitTimer2 = 0f;// for start to goal

    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {


        if (!goalHit)
        {
            goalHitTimer2 += Time.deltaTime;
        }


        if (goalHit)
        {
            finishPoint.SetActive(true);
            goalMesh.enabled = false;


        }



    }

    private void OnTriggerEnter(Collider other)
    {
        goalHit = true;
        goalCollected = true;
    }

}
