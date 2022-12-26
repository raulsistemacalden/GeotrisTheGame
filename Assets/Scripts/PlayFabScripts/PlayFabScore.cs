using PlayFab;
using PlayFab.ClientModels;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayFabScore : MonoBehaviour
{
    
    public void SubmitScore(int playerScore)
    {
        UpdatePlayerStatisticsRequest requestData = new UpdatePlayerStatisticsRequest(){
            Statistics =new List<StatisticUpdate>(){
                new StatisticUpdate(){StatisticName = "HighScore", Value= playerScore}
            }
        };
        PlayFabClientAPI.UpdatePlayerStatistics(requestData, OnStatisticsUpdated, FailureCallback);
    }

    private void OnStatisticsUpdated(UpdatePlayerStatisticsResult updateResult)
    {
        Debug.Log("Successfully submitted high score");
    }

    private void FailureCallback(PlayFabError error)
    {
        Debug.LogWarning("Something went wrong with your API call. Here's some debug information:");
        Debug.LogError(error.GenerateErrorReport());
    }


    public void RequestLeaderboard()
    {
        GetLeaderboardRequest requestData = new GetLeaderboardRequest(){
            StatisticName = "HighScore",
            StartPosition = 0,
            MaxResultsCount = 10
        };
        PlayFabClientAPI.GetLeaderboard(requestData, DisplayLeaderboard, FailureCallback);
        
    }

    private void DisplayLeaderboard(GetLeaderboardResult result)
    {
        List<PlayerLeaderboardEntry> scoreList = result.Leaderboard;
        int i = 0;
        foreach (var item in scoreList)
        {
            GameObject.Find("Score" + (i + 1)).GetComponent<Text>().text = item.DisplayName + ": " + item.StatValue;
            i++;
            //Debug.Log(item.StatValue);
        }


    }
}
