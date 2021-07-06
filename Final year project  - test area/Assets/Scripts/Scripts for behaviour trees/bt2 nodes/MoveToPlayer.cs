using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

// THIS IS FOR THE PATROL NODE \\
public class MoveToPlayer : BTNode
{

    AIBehaviour AI;
    public Transform AICurrentPosition;
    public Transform targetPosition;
    public float _distance;
    public bool _chasing;
    public int _aiHealth;
    // nav mesh \\
    public GameObject player; 
    public NavMeshAgent cubeNav;

    public MoveToPlayer(AIBehaviour _AI, NavMeshAgent _cubenav)
    {
        AI = _AI;
        cubeNav = _cubenav; 


    }

    public override BTnodeStates Evaluate()
    {

        
        Vector3 AIPosition = AI.GetAIPosition().position;
        Vector3 TargetPosition = AI.GetAITargetPosition().position;

        _distance = Vector3.Distance(AIPosition, TargetPosition);
        
        _aiHealth = AI.AICurrentHealth();

        if (_distance <= 8f && _aiHealth >=2)
        {

            _chasing = true;
            PatrolChase();

            return BTnodeStates.SUCCESS;
        }
        if(_distance >= 9f && _distance <=14f)
        {
            _chasing = true;
            GivingUpChase();

            return BTnodeStates.SUCCESS;

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

   
