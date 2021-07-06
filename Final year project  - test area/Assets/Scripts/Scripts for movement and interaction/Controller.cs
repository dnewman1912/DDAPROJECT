using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 


public class Controller : MonoBehaviour
{
    // movement \\
    public float acceleration; 
    public float maxSpeed;
    public float rotationSpeed;
    //fighting\\
    public int pHealth;
    public int pDamage;
    public int pHitCounter;
    public int enemiesDefeated; 
    public bool hitByEnemy;
    public bool attacking;
    public GameObject sword;
    public GameObject aISword;
    public CapsuleCollider aISwordCollider; 
    // General \\
    private BasicAI aiScript;
    private EnemySpawner aispawnerscript;
    public FinishPoint finishPoint;
    public Rigidbody playerRB;
    public Canvas gameOverCan;
    public Text lives; 
    void Start()
    {
        aiScript = FindObjectOfType(typeof(BasicAI)) as BasicAI;
        aispawnerscript = FindObjectOfType(typeof(EnemySpawner)) as EnemySpawner;

        playerRB = GetComponent<Rigidbody>();

        lives.text = "lives Remaining " + pHealth;

        Time.timeScale = 0; 
    }

   
    void Update()
    {
        // general \\
        lives.text = "lives Remaining " + pHealth;
        GameOver(); 


        // movement \\

        Momentum();

        if (Input.GetKey(KeyCode.W) & (acceleration < maxSpeed))
        {
            acceleration+= 0.2f;
        }

        if (acceleration >= maxSpeed)
        {
            acceleration-= 0.9f;
        }

        // roatation \\

        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0.0f, rotationSpeed * Time.deltaTime, 0.0f);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0.0f, -rotationSpeed * Time.deltaTime, 0.0f);
        }

        // attacking \\

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
           
            SwordSwing();
            attacking = true;
           
        }
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {

            SwordSwing();
            attacking = false;

        }

        if (hitByEnemy)
        {
            pHealth--;
            pHitCounter++;
            hitByEnemy = false;
        }



        if (aispawnerscript.enemyCounter >= 1)
        {

            aISword = GameObject.FindGameObjectWithTag("enemyMelee");
            aISwordCollider = aISword.GetComponent<CapsuleCollider>(); // need to add a null part
            /// needs to find a way to delay the above two lines until first enemy has spawned... add bool to spawnner script then check it here in update before running those lines

        }
        else
        {
            // need to add a null reference blocker here
        }


    }

    private void Momentum()
    {
        transform.Translate(0f, 0f, Input.GetAxis("Vertical") * Time.deltaTime * acceleration);
    }

    private void SwordSwing()
    {
        //insert animation here
    }

    private void GameOver()
    {

        if (pHealth <= 0)
        {
            Time.timeScale = 0f;
            this.enabled = false;
            gameOverCan.gameObject.SetActive(true);
        }
    }
  
     private void OnTriggerEnter(Collider other)
     {

        if (other == aISwordCollider)
        {

            hitByEnemy = true;
            Debug.Log("Ouch!!");


        }

     }

}
