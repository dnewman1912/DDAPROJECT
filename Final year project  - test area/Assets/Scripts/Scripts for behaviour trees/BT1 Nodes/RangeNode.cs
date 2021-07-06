using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeNode : BTNode
{
    private float playerRange;
    private float aiRange;
    private Transform playerTarget;
    private Transform aiTarget;
    private Transform origin;


    public RangeNode( float aiRange, float playerRange, Transform playerTarget, Transform aiTarget, Transform origin)   ///////may need to split origin to allow for sepereate detection if origin is not for the ai self detection 
    {
        this.playerRange = playerRange;
        this.aiRange = aiRange;
        this.playerTarget = playerTarget;
        this.aiTarget = aiTarget;
        this.origin = origin; 

    }




    public override BTnodeStates Evaluate()
    {
        return BTnodeStates.SUCCESS; 
    }
}
