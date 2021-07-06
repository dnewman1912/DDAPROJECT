using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using PlayFab;
using PlayFab.ClientModels;


public class PlayFabManager : MonoBehaviour
{
    private string userEmail;
    private string userPassword;
    private string username;
    public GameObject loginPanel;
    public statCollector statCollector;
    public float goalTime;

    public void Start()
    {
        if (string.IsNullOrEmpty(PlayFabSettings.staticSettings.TitleId))
        {
            /*
            Please change the titleId below to your own titleId from PlayFab Game Manager.
            If you have already set the value in the Editor Extensions, this can be skipped.
            */
            PlayFabSettings.staticSettings.TitleId = "61059";
        }
        // var request = new LoginWithCustomIDRequest { CustomId = "GettingStartedGuide", CreateAccount = true };
        // PlayFabClientAPI.LoginWithCustomID(request, OnLoginSuccess, OnLoginFailure);
        if (PlayerPrefs.HasKey("EMAIL"))
        {
            userEmail = PlayerPrefs.GetString("EMAIL");
            userPassword = PlayerPrefs.GetString("PASSWORD");
            var request = new LoginWithEmailAddressRequest { Email = userEmail, Password = userPassword };
            PlayFabClientAPI.LoginWithEmailAddress(request, OnLoginSuccess, OnLoginFailure);
            SetStats();
        }
        //PlayerPrefs.DeleteAll(); // use sparingly due to potential issues




        goalTime = statCollector.time2Goal;
    }
    #region Login


    public void GetUserEmail(string emailIn)
    {
        userEmail = emailIn; 
    }


    public void GetUserPassword( string passwordIn)
    {
        userPassword = passwordIn;
    }

    public void GetUsername( string usernameIn)
    {
        username = usernameIn; 
    }

    public void OnClickLogin()
    {
        var request = new LoginWithEmailAddressRequest { Email = userEmail, Password = userPassword };
        PlayFabClientAPI.LoginWithEmailAddress(request, OnLoginSuccess, OnLoginFailure);
    }

    private void OnLoginSuccess(LoginResult result)
    {
        Debug.Log("Congratulations, you made your first successful API call!");
        PlayerPrefs.SetString("EMAIL", userEmail);
        PlayerPrefs.SetString("PASSWORD", userPassword); //TURN ON TO REMOVE NEED TO LOGIN EVERYTIME
        loginPanel.SetActive(false);
    }

    private void OnLoginFailure(PlayFabError error)
    {
        var registerRequest = new RegisterPlayFabUserRequest { Email = userEmail, Password = userPassword, Username = username };
        PlayFabClientAPI.RegisterPlayFabUser(registerRequest, OnRegisterSuccess, OnRegisterFailure);
    }

    private void OnRegisterSuccess(RegisterPlayFabUserResult result)
    {
        PlayerPrefs.SetString("EMAIL", userEmail);
        PlayerPrefs.SetString("PASSWORD", userPassword);
        loginPanel.SetActive(false);
        Debug.Log("Congratulations, you made your first successful API call!");


    }

    private void OnRegisterFailure(PlayFabError error)
    {
        Debug.LogError(error.GenerateErrorReport());
    }

    #endregion Login

    #region Playerstats

    
    
   

    public void SetStats()
    {

        //PlayFabClientAPI.UpdatePlayerStatistics(new UpdatePlayerStatisticsRequest
        //{
        //    // request.Statistics is a list, so multiple StatisticUpdate objects can be defined if required.
        //    Statistics = new Dictionary<StatisticUpdate> 
        //    {
        //        new StatisticUpdate { StatisticName = "goalTime", Value = statCollector.time2Goal },
        //    }
        //},
        //result => { Debug.Log("User statistics updated"); },
        //error => { Debug.LogError(error.GenerateErrorReport()); });



        PlayFabClientAPI.UpdateUserData(new UpdateUserDataRequest()
        {
            Data = new Dictionary<string, string>()
            {
            {"GoalTimer", goalTime.ToString("0.00") },
          
            }
        },
            result => Debug.Log("Successfully updated user data"),
            error => 
            {
                Debug.Log("Got error setting user data Ancestor to Arthur");
                Debug.Log(error.GenerateErrorReport());
            });

    }










    #endregion Playerstats


}
