using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class ButtonLevelCounter : MonoBehaviour
{
    public Button but1;
    public GameObject levelcounter;

    public LevelAttemptCounter lac; 

    // Start is called before the first frame update
    void Start()
    {
        lac = FindObjectOfType(typeof(LevelAttemptCounter)) as LevelAttemptCounter;
        but1.onClick.AddListener(lac.LevelAttemptsIncrease); 
    }

    // Update is called once per frame
    void Update()
    {
        




    }
}
