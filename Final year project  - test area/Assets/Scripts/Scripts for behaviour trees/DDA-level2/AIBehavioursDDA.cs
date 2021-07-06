using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface  AIBehaviourDDA
{
    //base stats\\
    int AICurrentHealth( int AIHealth);
    int AICurrentDamage( int AIDamage);
    int AICurrentHealth();
    int AICurrentDamage();

    GameObject PlayerGO(GameObject Playergo);
    GameObject PlayerGO();

    GameObject StatCollector(GameObject StatCol);
    GameObject PlayeStatCollectorrGO();

    //Movement based \\
    Transform GetTargetPosition(Transform targetPosition);
    Transform GetCurrentPosition(Transform currentPosition);
    Transform GetAIPosition();

    Transform GetAITargetPosition(); 
    
    Transform GetPatrolPosition(Transform patrolPosition);

    Transform GetPatrolPosition(); 


}