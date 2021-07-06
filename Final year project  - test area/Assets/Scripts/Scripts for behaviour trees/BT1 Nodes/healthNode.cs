using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthNode : BTNode
{
    private BasicAI ai;
    private float health;
    private float damageDealt;
    private bool rageMode; 

    public healthNode(BasicAI ai, float health)
    {
        this.ai = ai;
        this.health = health; 
    }


    public override BTnodeStates Evaluate()
    {
        return ai.GetCurrentHealth() <= health ? BTnodeStates.SUCCESS : BTnodeStates.FAILURE;
    }
}
