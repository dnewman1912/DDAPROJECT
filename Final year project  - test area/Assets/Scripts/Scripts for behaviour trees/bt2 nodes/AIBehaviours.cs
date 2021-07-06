using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface  AIBehaviour
{
    //base stats\\
    int AICurrentHealth( int AIHealth);
    int AICurrentDamage( int AIDamage);
    int AICurrentHealth();
    int AICurrentDamage();

    //Movement based \\
    Transform GetTargetPosition(Transform targetPosition);
    Transform GetCurrentPosition(Transform currentPosition);
    Transform GetAIPosition();

    Transform GetAITargetPosition(); 
    
    Transform GetPatrolPosition(Transform patrolPosition);

    Transform GetPatrolPosition(); 


}