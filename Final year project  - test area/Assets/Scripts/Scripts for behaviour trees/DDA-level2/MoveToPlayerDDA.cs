using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

// THIS IS FOR THE PATROL NODE \\
public class MoveToPlayerDDA : BTNode
{

    AIBehaviourDDA AI;
    public Transform AICurrentPosition;
    public Transform targetPosition;
    public float _distance;
    public bool _chasing;
    public int _aiHealth;
    private statCollector colScript; 

    private Controller playerScript;
    // nav mesh \\
    public GameObject player; 
    public NavMeshAgent cubeNav;

    public MoveToPlayerDDA(AIBehaviourDDA _AI, NavMeshAgent _cubenav)
    {
        AI = _AI;
        cubeNav = _cubenav; 


    }

    public override BTnodeStates Evaluate()
    {
        playerScript = player.GetComponent<Controller>();
        int disNumber = playerScript.pHealth; 

        GameObject statsCol = AI.PlayeStatCollectorrGO().gameObject;
        colScript = statsCol.GetComponent<statCollector>();
        
        Vector3 AIPosition = AI.GetAIPosition().position;
        Vector3 TargetPosition = AI.GetAITargetPosition().position;

        _distance = Vector3.Distance(AIPosition, TargetPosition);
        
        _aiHealth = AI.AICurrentHealth();

        if (colScript.time2Goal <= 10) // this number could be adjusted after some personal tests
        {
            if (_distance <= disNumber + 5 && _aiHealth >= 2) // add 5 as base number is 8 on no dda levels.
            {

                _chasing = true;
                PatrolChase();

                return BTnodeStates.SUCCESS;
            }
            else
            {
                return BTnodeStates.RUNNING;
            }

        }
        else if(colScript.time2Goal >= 10.1)  // this number could be adjusted after some personal tests
        {

            if (_distance >= disNumber + 6 && _distance <= 14f) // add 6 as base number is 9 on no dda levels.
            {
                _chasing = true;
                GivingUpChase();

                return BTnodeStates.SUCCESS;

            }
            else
            {
                return BTnodeStates.RUNNING;
            }
        }
        else
        {
           _chasing = false;
           return BTnodeStates.FAILURE;
        }


        

       

         void PatrolChase()
         {
            if (_chasing)
            {
                //steering\\
                cubeNav.speed = 4.5f;
                cubeNav.angularSpeed = 120f;
                cubeNav.acceleration = 12f;
                cubeNav.stoppingDistance = 0f;
                // obstacle avoidance \\
                cubeNav.radius = 0.5f;
                cubeNav.height = 1f;
                //Targeting\\
                cubeNav.destination = TargetPosition;
            }
           
         }
        void GivingUpChase()
        {
            if (_chasing)
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
                cubeNav.destination = TargetPosition;
            }

        }


    }
}

   
