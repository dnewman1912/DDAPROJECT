using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class BehaviourTree1 : MonoBehaviour

{
    // scripts \\
    public Controller controllerScript; 
    // player \\
    public GameObject sword; 
    // enemy stats \\
    public int health = 3;
    public int damage;
    // nav mesh \\
    public GameObject player;
    public NavMeshAgent cubeNav;
    // switch enums \\
    public enum behaviourType{ Patrol, Attacking, Defending}
    public behaviourType BehaviourType; 
    void Start()
    {

        controllerScript = FindObjectOfType(typeof(Controller)) as Controller;
        cubeNav = GetComponent<NavMeshAgent>();
        health = 1;
        player = GameObject.FindGameObjectWithTag("Player");
        sword = GameObject.FindGameObjectWithTag("playerMelee");
        BehaviourType = behaviourType.Patrol;
    }

    // Update is called once per frame

    private void FixedUpdate()
    {
        switch (BehaviourType)
        {
            case behaviourType.Patrol:
                // some code 
                break;
            case behaviourType.Attacking:
                //some code 
                break;
            case behaviourType.Defending:
            //some code 
            default:
                //some code 
                break;


        }

    }
    void Update()
    {
   
        NavMeshAttack();
    
    }

    public void NavMeshPatrol()
    {
        //steering\\
        cubeNav.speed = 3.5f;
        cubeNav.angularSpeed = 120f;
        cubeNav.acceleration = 8f;
        cubeNav.stoppingDistance = 0f;
        // obstacle avoidance \\
        cubeNav.radius = 0.5f;
        cubeNav.height = 1f;
        //Targeting\\
        cubeNav.destination = -player.transform.position;
    }
    public void NavMeshDefend()
    {
        //steering\\
        cubeNav.speed = 3.5f;
        cubeNav.angularSpeed = 30f;
        cubeNav.acceleration = 5f;
        cubeNav.stoppingDistance = 1f; //Stop within this distance from the target position.
        // obstacle avoidance \\
        cubeNav.radius = 1.5f;
        cubeNav.height = 1f;
        //Targeting\\
        cubeNav.destination = -player.transform.position;

    }
    public void NavMeshAttack()
    {
        //steering\\
        cubeNav.speed = 5f;
        cubeNav.angularSpeed = 160f;
        cubeNav.acceleration = 10f;
        cubeNav.stoppingDistance = 0f; //Stop within this distance from the target position.
        // obstacle avoidance \\
        cubeNav.radius = 1.5f;
        cubeNav.height = 1f;
        //Targeting\\
        cubeNav.destination = player.transform.position;


    }
    private void OnTriggerEnter(Collider other)
    {
       //if (other.gameObject == sword)
       // {
       //     if(controllerScript.attacking == true)
       //     {
       //         health--;
       //         Debug.Log("damaged em");
       //     }
           
       // }

        if (other.GetComponent<SphereCollider>())
        {
            if (controllerScript.attacking == true)
            {
                health--;
                Debug.Log("damaged em");

                if (health <= 0)
                {
                    controllerScript.enemiesDefeated++;
                    Destroy(this.gameObject);

                }
            }

        }
    }

}
