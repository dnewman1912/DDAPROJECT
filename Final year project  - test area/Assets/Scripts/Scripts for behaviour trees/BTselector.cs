using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BTselector : BTNode 
{
    private List<BTNode> myNodes = new List<BTNode>();

    public BTselector(List<BTNode> nodes)
    {
        myNodes = nodes;
    }
    public override BTnodeStates Evaluate()
    {
       

        foreach(BTNode node in myNodes)
        {
            switch (node.Evaluate()) 
            
            {
                case BTnodeStates.SUCCESS:
                    currentNodeState = BTnodeStates.SUCCESS;
                    return currentNodeState; 

                case BTnodeStates.FAILURE:
                    continue;
                   

                case BTnodeStates.RUNNING:
                    currentNodeState = BTnodeStates.RUNNING; 
                    continue;


                default:
                    continue; 
            
            }

        }
        currentNodeState = BTnodeStates.FAILURE;
        return currentNodeState;
    }
}
