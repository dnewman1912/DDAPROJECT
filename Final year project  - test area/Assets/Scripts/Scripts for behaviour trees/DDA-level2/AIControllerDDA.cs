using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI; 
// THIS IS WHERE THE BEHAVIOUR TREE IS FORMED \\
public class AIControllerDDA : MonoBehaviour, AIBehaviourDDA
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
    public BTselector RootAIDDA;
    //Patrol\\
    public BTsequence FindPatrolAreaDDA;
    public BTselector PatrolTypeDDA;
    //Defensive\\
    public BTsequence RetreatDDA;
    //attacking\\
    public BTselector AttackPlayerDDA;
    //general use \\
    public NavMeshAgent cubeNav;
    public GameObject Player;
    public GameObject _playergo;
    public GameObject _statCol;
    private Controller enemyDefeatedCounter;
    

    void Start()
    {
        // general \\
        enemyDefeatedCounter = FindObjectOfType(typeof(Controller)) as Controller;
        _playergo = Player;
        _statCol = GameObject.FindGameObjectWithTag("statCollector");

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
        FindPatrolAreaDDA = new BTsequence(new List<BTNode>
        {
            new CheckPlayerDistanceDDA(this),
            new PatrolAreaDDA(this,cubeNav),
           

        });


        PatrolTypeDDA = new BTselector(new List<BTNode>
        {

            new MoveToPlayerDDA(this, cubeNav),
            new PatrolAreaDDA(this,cubeNav),


        });

        #endregion

        #region DEFENSIVE NODES
        RetreatDDA =new BTsequence(new List<BTNode>
        {
            new RunFromPlayerDDA(this, cubeNav)
        });
        #endregion

        #region ATTCKING NODES

        AttackPlayerDDA = new BTselector(new List<BTNode>
        {

            new AttackPlayerDDA(this,cubeNav),

        });


        #endregion

        RootAIDDA = new BTselector(new List<BTNode>
        {
            //add here the list of behaviours from above for the selector to choose from.THE ORDER MATTERS
        //PATROL BRANCH\\
         FindPatrolAreaDDA,
         PatrolTypeDDA,
        //DEFENSIVE BRANCH\\
         RetreatDDA, 

        //ATTACKING BRANCH\\
        AttackPlayerDDA, 





        });

        #endregion
    }




    // Update is called once per frame
    void Update()
    {
        RootAIDDA.Evaluate();
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
    public GameObject PlayerGO(GameObject Playergo)
    {
        _playergo = Playergo; 
        return _playergo; 
    }

    public GameObject PlayerGO()
    {
        return _playergo;
    }
    public GameObject StatCollector(GameObject StatCol)
    {
        _statCol = StatCol;
        return _statCol;
    }
    public GameObject PlayeStatCollectorrGO()
    {
        return _statCol; 
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
