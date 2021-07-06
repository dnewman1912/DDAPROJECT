using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PatrolAreaDDA : BTNode
{
    AIBehaviourDDA AI;
    public Vector3 radius;
    public Vector3 patrolPoint;
    public NavMeshAgent cubeNav;
    public float _targetX;
    public float _targetZ;

    public PatrolAreaDDA(AIBehaviourDDA _aI, NavMeshAgent _cubeNav)
    {
        AI = _aI;
        cubeNav = _cubeNav;
    }




    public override BTnodeStates Evaluate()
    {

        Vector3 AIPosition = AI.GetAIPosition().position;
        Vector3 TargetPosition = AI.GetAITargetPosition().position;
        radius = Random.insideUnitSphere * 500; //// change to insideunitcircle


        _targetX = radius.x; 
        _targetZ = radius.z;

        patrolPoint = AIPosition + new Vector3(_targetX, 0, _targetZ);  ///// pass the y variable into the z axis
       // patrolPoint = new Vector3(_targetX, 0, _targetZ);  

        cubeNav.destination = patrolPoint;
        ////// add radius result to the current position to get a individual area. 
        return BTnodeStates.SUCCESS;



    }
}
