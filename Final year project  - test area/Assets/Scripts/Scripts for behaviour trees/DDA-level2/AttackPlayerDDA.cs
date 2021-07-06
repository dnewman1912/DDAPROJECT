using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI; 

public class AttackPlayerDDA : BTNode
{


    AIBehaviourDDA AI;
    public Transform AICurrentPosition;
    public Transform targetPosition;
    public int _aiHealth;
    public float _distance;
    // nav mesh \\
    public GameObject player;
    public NavMeshAgent cubeNav;

    public AttackPlayerDDA(AIBehaviourDDA _AI, NavMeshAgent _cubenav)
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
       // bool _attack = false; 
        int ragechance = Random.Range(0, 100);



        // actions\\
        if (_aiHealth == 3)
        {
            if(ragechance <= 5)
            {
                RageAttackSet();
                return BTnodeStates.SUCCESS;
            }
            else
            {
                BasicAttackSet();
                return BTnodeStates.SUCCESS;
            }
  
        }
        else if (_aiHealth == 2)
        {
            if (ragechance <= 10)
            {
                RageAttackSet();
                return BTnodeStates.SUCCESS;
            }
            else
            {
                BasicAttackSet();
                return BTnodeStates.SUCCESS;
            }

        }
        else if (_aiHealth <= 1)
        {
            if (ragechance <= 25)
            {
                RageAttackSet();
                return BTnodeStates.SUCCESS;
            }
            else
            {
                BasicAttackSet(); ////THIS MAY NEED TO BE REMOVED ????
                return BTnodeStates.FAILURE;
            }

        }
        return BTnodeStates.RUNNING;


        #region custom methods

        void BasicAttackSet()
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

        void RageAttackSet()
        {
            //steering\\
            cubeNav.speed = 10f;
            cubeNav.angularSpeed = 160f;
            cubeNav.acceleration = 16f;
            cubeNav.stoppingDistance = 0f;
            // obstacle avoidance \\
            cubeNav.radius = 0.3f;
            cubeNav.height = 1f;
            //Targeting\\
            cubeNav.destination = TargetPosition;
        }
        #endregion

    }
}

