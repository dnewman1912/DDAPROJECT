using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonLevelResetCounter : MonoBehaviour
{
    public Button but1;
    public GameObject levelcounter;

    public LevelAttemptCounter lac;

    // Start is called before the first frame update
    void Start()
    {
        lac = FindObjectOfType(typeof(LevelAttemptCounter)) as LevelAttemptCounter;
        but1.onClick.AddListener(lac.LevelAttemptsReset);
    }

    // Update is called once per frame
    void Update()
    {





    }
}
