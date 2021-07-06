using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

// THIS IS FOR THE DEFENSIVE NODE \\
public class RunFromPlayerDDA : BTNode
{

    AIBehaviourDDA AI;
    public Transform AICurrentPosition;
    public Transform targetPosition;
    public int _aiHealth; 
    public float _distance;
    public bool _lowHealth;
    // nav mesh \\
    public NavMeshAgent cubeNav;
    private Controller playerScript; 

    public RunFromPlayerDDA(AIBehaviourDDA _AI, NavMeshAgent _cubenav)
    {
        AI = _AI;
        cubeNav = _cubenav;


    }









    public override BTnodeStates Evaluate()
    {
        GameObject player = AI.PlayerGO().gameObject;
        playerScript = player.GetComponent<Controller>(); 

        Vector3 AIPosition = AI.GetAIPosition().position;
        Vector3 TargetPosition = new Vector3(-AI.GetAITargetPosition().position.x, 0, -AI.GetAITargetPosition().position.x);
        _distance = Vector3.Distance(AIPosition, TargetPosition);

        _aiHealth = AI.AICurrentHealth(); 

        if (_aiHealth <= 1)
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

            int defencesiveRisk = Random.Range(0, 100);
            if (defencesiveRisk <= 49) //////50%chance to avoid the risk of the player, if player at full health
            {
                if (playerScript.pHealth == 3) // slightly increased stats for ai to run away better
                {
                    //steering\\
                    cubeNav.speed = 8f;
                    cubeNav.angularSpeed = 140f;
                    cubeNav.acceleration = 14f;
                    cubeNav.stoppingDistance = 0f;
                    // obstacle avoidance \\
                    cubeNav.radius = 0.8f;
                    cubeNav.height = 1f;
                    //Targeting\\
                    cubeNav.destination = TargetPosition;
                }
                else ///basic movement stats
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
          else if( defencesiveRisk >= 50 && defencesiveRisk <= 85) //////35%chance to avoid the risk of the player, if player at half health
            {
                if (playerScript.pHealth <= 2) // slightly increased stats for ai to run away better
                {
                    //steering\\
                    cubeNav.speed = 8f;
                    cubeNav.angularSpeed = 140f;
                    cubeNav.acceleration = 14f;
                    cubeNav.stoppingDistance = 0f;
                    // obstacle avoidance \\
                    cubeNav.radius = 0.8f;
                    cubeNav.height = 1f;
                    //Targeting\\
                    cubeNav.destination = TargetPosition;
                }
                else ///basic movement stats
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
            else if (defencesiveRisk >= 86 && defencesiveRisk <= 100)//////15%chance to avoid the risk of the player, if player at low health
            {
                if (playerScript.pHealth <= 1)// slightly increased stats for ai to run away better
                {
                    //steering\\
                    cubeNav.speed = 8f;
                    cubeNav.angularSpeed = 140f;
                    cubeNav.acceleration = 14f;
                    cubeNav.stoppingDistance = 0f;
                    // obstacle avoidance \\
                    cubeNav.radius = 0.8f;
                    cubeNav.height = 1f;
                    //Targeting\\
                    cubeNav.destination = TargetPosition;
                }
                else ///basic movement stats
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
       


    }
}


