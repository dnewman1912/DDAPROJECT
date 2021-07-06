using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

// THIS IS FOR THE DEFENSIVE NODE \\
public class RunFromPlayer : BTNode
{

    AIBehaviour AI;
    public Transform AICurrentPosition;
    public Transform targetPosition;
    public int _aiHealth; 
    public float _distance;
    public bool _lowHealth;
    // nav mesh \\
    public GameObject player;
    public NavMeshAgent cubeNav;

    public RunFromPlayer(AIBehaviour _AI, NavMeshAgent _cubenav)
    {
        AI = _AI;
        cubeNav = _cubenav;


    }









    public override BTnodeStates Evaluate()
    {


        Vector3 AIPosition = AI.GetAIPosition().position;
        Vector3 TargetPosition = new Vector3(AI.GetAITargetPosition().position.x, 0, AI.GetAITargetPosition().position.x);
        _distance = Vector3.Distance(AIPosition, TargetPosition);

        _aiHealth = AI.AICurrentHealth(); 

        if (_aiHealth == 1)
        {
            _lowHealth = true; 
        }
        else
        {
            _lowHealth = false; 
        }

        

        if (_lowHealth)
        {

            
            Retreating();

            return BTnodeStates.SUCCESS;
        }
        else
        {

            
            return BTnodeStates.FAILURE;
        }





        void Retreating()
        {
            
                //steering\\
                cubeNav.speed = 6f;
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
}


