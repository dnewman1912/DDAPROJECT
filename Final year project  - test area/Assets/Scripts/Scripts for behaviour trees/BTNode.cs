using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class BTNode
{
   public enum BTnodeStates { SUCCESS, FAILURE, RUNNING }
  

    protected BTnodeStates currentNodeState; 
  
    public BTNode ()
    {
        
    }


    public BTnodeStates nodeState
    {
        get { return currentNodeState; }
    }

    public abstract BTnodeStates Evaluate(); 


}
