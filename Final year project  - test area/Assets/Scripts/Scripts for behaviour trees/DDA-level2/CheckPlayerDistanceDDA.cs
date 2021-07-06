using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPlayerDistanceDDA : BTNode
{
    AIBehaviourDDA AI;
    public Transform AICurrentPosition;
    public Transform targetPosition;
    public float _distance; 

    public CheckPlayerDistanceDDA(AIBehaviourDDA _AI)
    {
        AI = _AI; 
    }

    






   
    public override BTnodeStates Evaluate()
    {
        Vector3 AIPosition = AI.GetAIPosition().position;
        Vector3 TargetPosition = AI.GetAITargetPosition().position;
        
        _distance = Vector3.Distance(AIPosition, TargetPosition);


        if (_distance > 15f)
        {
            return BTnodeStates.SUCCESS;
        }
        else
        {
            return BTnodeStates.FAILURE;
        }


        
    }
}
