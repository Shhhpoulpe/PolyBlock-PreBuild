using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Web.Helpers;
using Web.Twitter.API;
using Web.Twitter.DataStructures;

public class Example : MonoBehaviour
{
    public string TwitterApiConsumerKey;
    public string TwitterApiConsumerSecret;

    public WebAccessToken TwitterApiAccessToken;

    [Header("GetGlobalTrends")]
    public Trend[] GlobalTrends;
    [Header("GetLatestTweetsFromUserByScreenName")]
    public Tweet[] LatestTweetsFromUserByScreenName;
    [Header("GetLatestTweetsFromUserByUserId")]
    public Tweet[] LatestTweetsFromUserByUserId;
    [Header("GetLikedTweetsOfUserByUsername")]
    public Tweet[] LikedTweetsOfUserByUsername;
    [Header("GetLikedTweetsOfUserByUserID")]
    public Tweet[] LikedTweetsOfUserByUserID;
    [Header("GetLocalTrends")]
    public Trend[] LocalTrends;
    [Header("GetTweetByID")]
    public Tweet TweetById;
    [Header("GetUserProfileByUserId")]
    public UserProfile GetUserProfileByUserId;
    [Header("GetUserProfileByUsername")]
    public UserProfile GetUserProfileByUsername;
    [Header("SearchForTweets")]
    public Tweet[] SearchResults;

    private void Start()
    {
        TwitterApiAccessToken = WebHelper.GetTwitterApiAccessToken(TwitterApiConsumerKey,TwitterApiConsumerSecret);
        ExampleFunction();
    }

    public async void ExampleFunction()
    {
        TweetById = await TwitterRestApiHelper.GetTweetByID("1221121465220771840", this.TwitterApiAccessToken.access_token);
        
        LatestTweetsFromUserByScreenName =  await TwitterRestApiHelper.GetLatestTweetsFromUserByScreenName("polyblock_game", this.TwitterApiAccessToken.access_token, 10, true);
        LatestTweetsFromUserByUserId =      await TwitterRestApiHelper.GetLatestTweetsFromUserByUserId("1265995261450620934", this.TwitterApiAccessToken.access_token, 10, true);

        LikedTweetsOfUserByUsername =       await TwitterRestApiHelper.GetLikedTweetsOfUserByUsername("polyblock_game", this.TwitterApiAccessToken.access_token);
        LikedTweetsOfUserByUserID =         await TwitterRestApiHelper.GetLikedTweetsOfUserByUserID("1265995261450620934", this.TwitterApiAccessToken.access_token);

        LocalTrends =                       await TwitterRestApiHelper.GetLocalTrends(1, this.TwitterApiAccessToken.access_token);
        GlobalTrends =                      await TwitterRestApiHelper.GetGlobalTrends(this.TwitterApiAccessToken.access_token);

        GetUserProfileByUserId =            await TwitterRestApiHelper.GetUserProfileByUserId("1265995261450620934", this.TwitterApiAccessToken.access_token);
        GetUserProfileByUsername =          await TwitterRestApiHelper.GetUserProfileByUsername("polyblock_game", this.TwitterApiAccessToken.access_token);

        SearchResults =                     await TwitterRestApiHelper.SearchForTweets("#polyblock", this.TwitterApiAccessToken.access_token, 50);
    }
}
