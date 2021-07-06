using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BTsequence : BTNode 
{
    private List<BTNode> myNodes = new List<BTNode>();

    public BTsequence(List<BTNode> nodes)
    {
        myNodes = nodes;
    }
    public override BTnodeStates Evaluate()
    {
        bool childRunning = false; 

        foreach(BTNode node in myNodes)
        {
            switch (node.Evaluate()) 
            
            {
                case BTnodeStates.SUCCESS:
                    continue;

                case BTnodeStates.FAILURE:
                    currentNodeState = BTnodeStates.FAILURE;
                    return currentNodeState;

                case BTnodeStates.RUNNING:
                    childRunning = true;
                    continue;


                default:
                    currentNodeState = BTnodeStates.SUCCESS; 
                    return currentNodeState; 
            
            }

        }
        currentNodeState = childRunning ? BTnodeStates.SUCCESS : BTnodeStates.SUCCESS; 
        return currentNodeState;
    }
}
