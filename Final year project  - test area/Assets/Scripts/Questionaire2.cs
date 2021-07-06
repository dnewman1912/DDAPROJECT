using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI; 

public class Questionaire2 : MonoBehaviour
{
   // enum questionResults { stronglyDisagree,disagree,somewhatDisagree,neutral,somewhatAgree,agree,stronglyAgree}
  

    public string answer1;
    public string answer2;
    public string answer3;
    public string answer4;
      // Start is called before the first frame update
      void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
       
    }
  
    public void AnswersJson2()
    {
        //json\\
        QuestionResults questionResults = new QuestionResults();
        questionResults.q1 = answer1; 
        questionResults.q2 = answer2; 
        questionResults.q3 = answer3; 
        questionResults.q4 = answer4; 

        string json = JsonUtility.ToJson(questionResults, true);
        File.WriteAllText(Application.dataPath + "/02_Survey2Answers.json", json);
     
        
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


    private class QuestionResults
    {

        public string q1;
        public string q2;
        public string q3;
        public string q4;

       

    }




}
