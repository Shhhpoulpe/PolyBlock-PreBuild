using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Web.Twitter.DataStructures;

public class EndLevelMenu : MonoBehaviour
{
    public GameObject timer;
    public Text printTimer, BDDreturn;

    public string time, IDJoueur, url, httpReturn;
    public int sceneID;

    private void Start()
    {
        timer.SetActive(false);
        time = timer.GetComponent<UnityEngine.UI.Text>().text;
        printTimer.text = time;

        StartCoroutine(SendTime());

    }
   
    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

    public void NextLevel()
    {
        Time.timeScale = 1f;
        sceneID = SceneManager.GetActiveScene().buildIndex;
        if(Application.CanStreamedLevelBeLoaded(sceneID + 1))
        {
            SceneManager.LoadScene(sceneID + 1);
        }
        else
        {
            Debug.Log("404");
            SceneManager.LoadScene(0);
        }
        
    }

    IEnumerator SendTime()
    {
        url = "http://localhost/PolyBlock-scores/api/insert_score.php?";

        IDJoueur = "STEAM_1:0:11101";
        url += "IDJoueur=" + IDJoueur;

        sceneID = SceneManager.GetActiveScene().buildIndex;
        url += "&niveau=" + sceneID;

        time = timer.GetComponent<UnityEngine.UI.Text>().text;
        url += "&temps=" + time;

        UnityWebRequest www = UnityWebRequest.Get(url);

        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);
            BDDreturn.text = "Error while sending time";
        }
        else
        {
            httpReturn = www.downloadHandler.text;
            Debug.Log(httpReturn);
            BDDreturn.text = "Time successfully sent";
        }
    }
}