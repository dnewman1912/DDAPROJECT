using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Questionaire : MonoBehaviour
{
   // enum questionResults { stronglyDisagree,disagree,somewhatDisagree,neutral,somewhatAgree,agree,stronglyAgree}
  

    public string answer1;
    public string answer2;
    public string answer3;
    public string answer4;
    public string answer5;
    public string answer6;

    public Button but1;
    public Button but2;
    public Button but3;
    public Button but4;


    public string saveFolder = "Answers";
    public string saveFile = "_SurveyAnswers";

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
       
        

    }
   
    public void AnswersJson1()
    {
        //json\\
        QuestionResults questionResults = new QuestionResults();
        questionResults.q1 = "1.The Enemies were difficult " + answer1; 
        questionResults.q2 = "2.The Enemies affected the gameplay? " + answer2; 
        questionResults.q3 = "3.The Enemies were adaptive to game events? " + answer3; 
        questionResults.q4 = "4.The Enemies did not move during the level? " + answer4; 

        string json = JsonUtility.ToJson(questionResults, true);
        //  File.WriteAllText(Application.dataPath + "/01_Survey1Answers.json", json);
       
        var directoryPath = Application.dataPath + "/" + saveFolder + "/" + SceneManager.GetActiveScene().name + "/";
        if (!Directory.Exists(directoryPath)) Directory.CreateDirectory(directoryPath);
        var fullPath = directoryPath + SceneManager.GetActiveScene().name + "_" + saveFile + ".json";

        File.WriteAllText(fullPath, json);

    }
    public void AnswersJsonFinal()
    {
        //json\\
        QuestionResults questionResults = new QuestionResults();
        questionResults.q1 = "1.There was a noticeable difference with the DDA system in place? " + answer1;
        questionResults.q2 = "2.The Enemies behaved the same in each level? " + answer2;
        questionResults.q3 = "3.Of the four levels, which did you find the most enjoyable? " + answer3;
        questionResults.q4 = "4.Of the four levels, which did you feel was most challenging? " + answer4;
        questionResults.q5 = "5.Of the four levels, which one was the Dynamic difficulty adjustment most noticeable? " + answer5;
        questionResults.q6 = "6.Of the four levels, which one was the Dynamic difficulty adjustment least noticeable? " + answer6;

        string json = JsonUtility.ToJson(questionResults, true);
        //  File.WriteAllText(Application.dataPath + "/01_Survey1Answers.json", json);

        var directoryPath = Application.dataPath + "/" + saveFolder + "/" + SceneManager.GetActiveScene().name + "/";
        if (!Directory.Exists(directoryPath)) Directory.CreateDirectory(directoryPath);
        var fullPath = directoryPath + SceneManager.GetActiveScene().name + "_" + saveFile + ".json";

        File.WriteAllText(fullPath, json);



    }

    #region question1
    public void StronglyDisagree1()
    {
        answer1 = ("Strongly Disagree");
    }
    public void Disagree1()
    {
        answer1 = ("Disagree");
    }
    public void SomewhatDisagree1()
    {
        answer1 = ("Somewhat Disagree");
    }
    public void Neutral1()
    {
        answer1 = ("Neutral");
    }
    public void SomewhatAgree1()
    {
        answer1 = ("Somewhat Agree");
    }
    public void Agree1()
    {
        answer1 = ("Agree");
    }
    public void StronglyAgree1()
    {
        answer1 = ("Strongly Agree");
    }
    #endregion
    #region question2
    public void StronglyDisagree2()
    {
        answer2 = ("Strongly Disagree");
    }
    public void Disagree2()
    {
        answer2 = ("Disagree");
    }
    public void SomewhatDisagree2()
    {
        answer2 = ("Somewhat Disagree");
    }
    public void Neutral2()
    {
        answer2 = ("Neutral");
    }
    public void SomewhatAgree2()
    {
        answer2 = ("Somewhat Agree");
    }
    public void Agree2()
    {
        answer2 = ("Agree");
    }
    public void StronglyAgree2()
    {
        answer2 = ("Strongly Agree");
    }
    #endregion
    #region question3
    public void StronglyDisagree3()
    {
        answer3 = ("Strongly Disagree");
    }
    public void Disagree3()
    {
        answer3 = ("Disagree");
    }
    public void SomewhatDisagree3()
    {
        answer3 = ("Somewhat Disagree");
    }
    public void Neutral3()
    {
        answer3 = ("Neutral");
    }
    public void SomewhatAgree3()
    {
        answer3 = ("Somewhat Agree");
    }
    public void Agree3()
    {
        answer3 = ("Agree");
    }
    public void StronglyAgree3()
    {
        answer3 = ("Strongly Agree");
    }
    #endregion
    #region question4
    public void StronglyDisagree4()
    {
        answer4 = ("Strongly Disagree");
    }
    public void Disagree4()
    {
        answer4 = ("Disagree");
    }
    public void SomewhatDisagree4()
    {
        answer4 = ("Somewhat Disagree");
    }
    public void Neutral4()
    {
        answer4 = ("Neutral");
    }
    public void SomewhatAgree4()
    {
        answer4 = ("Somewhat Agree");
    }
    public void Agree4()
    {
        answer4 = ("Agree");
    }
    public void StronglyAgree4()
    {
        answer4 = ("Strongly Agree");
    }
    #endregion
    #region Final Survey q3
    public void Level31()
    {
        answer3 = ("Level 1");
    }  
    public void Level32()
    {
        answer3 = ("Level 2");
    }  
    public void Level33()
    {
        answer3 = ("Level 3");
    }  
    public void Level34()
    {
        answer3 = ("Level 4");
    }
    #endregion 

    #region Final Survey q4
    public void Level41()
    {
        answer4 = ("Level 1");
    }  
    public void Level42()
    {
        answer4 = ("Level 2");
    }  
    public void Level43()
    {
        answer4 = ("Level 3");
    }  
    public void Level44()
    {
        answer4 = ("Level 4");
    }
    #endregion

    #region Final Survey q5
    public void Level51()
    {
        answer5 = ("Level 1");
    }  
    public void Level52()
    {
        answer5 = ("Level 2");
    }  
    public void Level53()
    {
        answer5 = ("Level 3");
    }  
    public void Level54()
    {
        answer5 = ("Level 4");
    }
    #endregion

    #region Final Survey q6
    public void Level61()
    {
        answer6 = ("Level 1");
    }  
    public void Level62()
    {
        answer6 = ("Level 2");
    }  
    public void Level63()
    {
        answer6 = ("Level 3");
    }  
    public void Level64()
    {
        answer6 = ("Level 4");
    }

    #endregion


    private class QuestionResults
    {

        public string q1;
        public string q2;
        public string q3;
        public string q4;
        public string q5;
        public string q6;

       

    }

}


