using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BasicAI : MonoBehaviour

{
    public Controller controllerScript; 
    // player \\
    public GameObject sword; 
    // enemy stats \\
    public int health = 3;
    public int lowHealth = 1; /// may cause issues with rage mode down the line !!!!!!!!!!!!!!!!!!!!!
    public int damage;
    // nav mesh \\
    public GameObject player;
    public NavMeshAgent cubeNav;
    // Start is called before the first frame update
    void Start()
    {

        controllerScript = FindObjectOfType(typeof(Controller)) as Controller;
        cubeNav = GetComponent<NavMeshAgent>();
        health = 1; /// will be turned off after testing or adjusted 
        player = GameObject.FindGameObjectWithTag("Player");
        sword = GameObject.FindGameObjectWithTag("playerMelee");
    }

    // Update is called once per frame
    void Update()
    {

        /// need to add if conditions here to control the change in behaviour 
        /// 
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

    public float GetCurrentHealth()
    {
        return health;
    }
    //private void OnTriggerEnter(Collider other)
    //{
    //   //if (other.gameObject == sword)
    //   // {
    //   //     if(controllerScript.attacking == true)
    //   //     {
    //   //         health--;
    //   //         Debug.Log("damaged em");
    //   //     }
           
    //   // }

    //    if (other.GetComponent<SphereCollider>())
    //    {
    //        if (controllerScript.attacking == true)
    //        {
    //            health--;
    //            Debug.Log("damaged em");

    //            if (health <= 0)
    //            {
    //                controllerScript.enemiesDefeated++;
    //                Destroy(this.gameObject);

    //            }
    //        }

    //    }
    //}

}
