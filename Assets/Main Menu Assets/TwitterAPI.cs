using System;
using System.Collections;
using System.Linq;
using UnityEngine;
using Web.Helpers;
using Web.Twitter.API;
using Web.Twitter.DataStructures;

public class TwitterAPI : MonoBehaviour
{
    public GameObject Tweet_image, Tweet_Text, Tweet_username, Tweet_sender;

    // Start is called before the first frame update
    public string key, secret;
    public WebAccessToken TwitterApiAccessToken;

    public Tweet[] tweets;
    public string imageUrl,sender_username,sender,tweet,picture;
    public long senderId;

    void Start()
    {
        TwitterApiAccessToken = WebHelper.GetTwitterApiAccessToken(key, secret);
        GetTweet();
    }

    public async void GetTweet()
    {
        tweets = await TwitterRestApiHelper.GetLatestTweetsFromUserByUserId("1265995261450620934", this.TwitterApiAccessToken.access_token, 1, true);
        
        tweet = tweets[0].text;                      //Tweet
        if (tweet[0].ToString() + tweet[1].ToString() == "RT"){
            senderId = tweets[0].entities.user_mentions[0].id;
            tweets = await TwitterRestApiHelper.GetLatestTweetsFromUserByUserId(senderId.ToString(), this.TwitterApiAccessToken.access_token, 1, true);
            tweet = tweet.Substring(tweet.IndexOf(':') + 2);

        }

        imageUrl = tweets[0].user.profile_image_url; //PP
        sender_username = tweets[0].user.name;       //Display name
        sender = tweets[0].user.screen_name;         //@


        await loadingImage(imageUrl);
        Tweet_username.GetComponent<UnityEngine.UI.Text>().text = sender_username.ToString();
        Tweet_sender.GetComponent<UnityEngine.UI.Text>().text = "@" + sender.ToString();
        Tweet_Text.GetComponent<UnityEngine.UI.Text>().text = tweet.ToString();


    }

    private IEnumerator loadingImage(string url)
    {
        //Si quelqu'un a la foi de changer le WWW en UnityWebRequest, c'est tout a votre honneur, j'y est perdu 4H de ma vie :'(
        WWW wwwLoader = new WWW(url);
        yield return wwwLoader;
        Tweet_image.GetComponent<UnityEngine.UI.RawImage>().texture = wwwLoader.texture;
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
