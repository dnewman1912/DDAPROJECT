using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;

public class statCollector : MonoBehaviour
{
    public Goal goalScript;
    public Goal2 goal2Script;
    public FinishPoint finishScript;
    public float time2Goal;
    public float time2Goal2;
    public float time2Finish;
    public int timesHit;
    public int enemiesSpawnned;
    public int enemiesDefeated;
    public int levelAttemptsTotal;
    public string saveFolder = "Stats";
    public string saveFile = "_FinalStats";

    private Controller controllerScript;
    private BasicAI aiScript;
    private EnemySpawner spawnerScript;
    private LevelAttemptCounter levelACS;


    void Start()
    {
        //  goalScript.goalHitTimer = 0f;
        controllerScript = FindObjectOfType(typeof(Controller)) as Controller;
        aiScript = FindObjectOfType(typeof(BasicAI)) as BasicAI;
        spawnerScript = FindObjectOfType(typeof(EnemySpawner)) as EnemySpawner;
        levelACS = FindObjectOfType(typeof(LevelAttemptCounter)) as LevelAttemptCounter;


      

    }
    void Update()
    {
        if (goalScript.goalHit)
        {
            Time2Goal(); 
        } 
        if (goal2Script.goalHit)
        {
            Time2Goal2(); 
        }
        if (finishScript.levelFinish)
        {
            Time2Finish();
        }
       

        EnemiesSpawned();

        EnemiesDefeated(); 

        HitRecievedCounter();

        if (levelACS) LevelAttemptsTotal(); /// need to att if to stop it running until needed

        //json\\
        
    }
    public void EnemiesSpawned()
    {

        enemiesSpawnned = spawnerScript.enemyCounter;

    }
    public void EnemiesDefeated()
    {

        enemiesDefeated = controllerScript.enemiesDefeated;

    }
    public void HitRecievedCounter()
    {

        timesHit = controllerScript.pHitCounter;

    }
    public void Time2Goal()
    {
        time2Goal = goalScript.goalHitTimer;

    }
    public void Time2Goal2()
    {
        time2Goal2 = goal2Script.goalHitTimer2;

    }
   
    public void LevelAttemptsTotal()
    {
        levelAttemptsTotal = levelACS.levelAttempts;
    }
    public void Time2Finish()
    {
        //duplicate json below and change the finalstats based on the scene......add if to check level ?????

        time2Finish = finishScript.finalHitTimer;

            //json\\
            FinalStats finalStats = new FinalStats();
            finalStats.time2Finish = time2Finish;
            finalStats.time2Goal = time2Goal;
            finalStats.time2Goal2 = time2Goal2;
            finalStats.timesHit = timesHit;
            finalStats.enemiesSpawnned = enemiesSpawnned;
            finalStats.enemiesDefeated = enemiesDefeated;
            finalStats.levelAttemptsTotal = levelAttemptsTotal;

            //string json = JsonUtility.ToJson(finalStats);
            string json = JsonUtility.ToJson(finalStats, true);
        
        var directoryPath = Application.dataPath + "/" + saveFolder + "/" + SceneManager.GetActiveScene().name + "/";
        if (!Directory.Exists(directoryPath)) Directory.CreateDirectory(directoryPath);
        var fullPath = directoryPath + SceneManager.GetActiveScene().name + "_" + levelACS.levelAttempts + saveFile + ".json";

        File.WriteAllText( fullPath, json);

        

    }

    //json\\
 private class FinalStats
    {
        public float time2Goal;
        public float time2Goal2;
        public float time2Finish;
        public int timesHit;
        public int enemiesSpawnned;
        public int enemiesDefeated;
        public int levelAttemptsTotal; 
    }

}






