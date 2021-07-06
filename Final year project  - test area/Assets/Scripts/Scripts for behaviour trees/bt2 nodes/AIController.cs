using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI; 
// THIS IS WHERE THE BEHAVIOUR TREE IS FORMED \\
public class AIController : MonoBehaviour, AIBehaviour 
{
    public Controller PlayerScript;
    // for use in AI behaviours script\\
    // for base stats\\
    public int _aICurrentHealth;
    public int _aICurrentDamage;
    public GameObject sword;
    public CapsuleCollider _playerSwordCollider; 
    // for movement\\
    public Transform _aICurrentPosition;
    public Transform _aITargetPosition;
    public Transform _patrolPosition; 



        // add all behaviours here, selectors and sequences 
    public BTselector RootAI;
    //Patrol\\
    public BTsequence FindPatrolArea;
    public BTselector PatrolType;
    //Defensive\\
    public BTsequence Retreat;
    //attacking\\
    public BTselector AttackPlayer; 
    //general use \\
    public NavMeshAgent cubeNav;
    public GameObject Player;
    private Controller enemyDefeatedCounter;

    void Start()
    {
        // general \\
        enemyDefeatedCounter = FindObjectOfType(typeof(Controller)) as Controller;


        //base stats\\
        _aICurrentHealth = 3; 
        _aICurrentDamage = 1; 
        sword = GameObject.FindGameObjectWithTag("playerMelee");
        _playerSwordCollider = sword.GetComponentInChildren<CapsuleCollider>(); 


        // movement\\
        Player = GameObject.FindGameObjectWithTag("Player");
        cubeNav = GetComponent<NavMeshAgent>();

        _aICurrentPosition = this.transform;
        _aITargetPosition = Player.transform;

        #region BT NODES LISTS

        #region PATROL NODES
        FindPatrolArea = new BTsequence(new List<BTNode>
        {
            new CheckPlayerDistance(this),
            new PatrolArea(this,cubeNav),
           

        });


        PatrolType = new BTselector(new List<BTNode>
        {

            new MoveToPlayer(this, cubeNav),
            new PatrolArea(this,cubeNav),


        });

        #endregion

        #region DEFENSIVE NODES
        Retreat =new BTsequence(new List<BTNode>
        {
            new RunFromPlayer(this, cubeNav)
        }); 
        #endregion

        #region ATTCKING NODES
        AttackPlayer = new BTselector(new List<BTNode>
        {

            new AttackPlayer(this,cubeNav),

        });

        #endregion

        RootAI = new BTselector(new List<BTNode>
        {
        //PATROL BRANCH\\
         FindPatrolArea,
         PatrolType,
        
        //ATTACKING BRANCH\\
        AttackPlayer,





        });

        #endregion
    }




    // Update is called once per frame
    void Update()
    {
        RootAI.Evaluate();
    }

    private void OnTriggerEnter(Collider other) /// placeholder needs to be added into BT correctly 
    {

        if (other == _playerSwordCollider)
        {
           
                _aICurrentHealth--;
                Debug.Log("damaged em");

                if (_aICurrentHealth <= 0)
                {
                    //controllerScript.enemiesDefeated++;

                    Destroy(this.gameObject);
                }
                if (_aICurrentHealth == 0)
                {


                    enemyDefeatedCounter.enemiesDefeated++;

                }

           

        }
    }
    #region BASE STATS AIBEHAVIOURS
    //base stats \\
    public int AICurrentHealth(int AIHealth)
    {
        _aICurrentHealth = AIHealth;
        return _aICurrentHealth; 
    }

    public int AICurrentHealth()
    {
        return _aICurrentHealth;
    }
    public int AICurrentDamage(int AIDamage)
    {
        _aICurrentDamage = AIDamage;
        return _aICurrentDamage; 
    }
    public int AICurrentDamage()
    {
        return _aICurrentDamage;
    }
    #endregion
    #region MOVEMENT AIBEHAVIOURS
    //movement\\

    public Transform GetCurrentPosition(Transform currentPosition) => _aICurrentPosition = currentPosition;
    //public Transform GetCurrentPosition(Transform currentPosition)
    //{


    //    _aICurrentPosition = currentPosition;

    //    return _aICurrentPosition;
    //}

    public Transform GetAIPosition()
    {
        return _aICurrentPosition;
    }
    public Transform GetTargetPosition(Transform targetPosition)
    {
        _aITargetPosition = targetPosition;


        return _aITargetPosition;
    }

    public Transform GetAITargetPosition()
    {


        return _aITargetPosition;
    }

    public Transform GetPatrolPosition(Transform patrolPosition)
    {
        _patrolPosition = patrolPosition;
        return _patrolPosition; 
    }

    public Transform GetPatrolPosition()
    {
        return _patrolPosition;
    }

    #endregion
}
