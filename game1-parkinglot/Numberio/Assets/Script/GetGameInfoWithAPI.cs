using System;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GetGameInfoWithAPI : MonoBehaviour
{
    public const string resourceURL = "http://localhost:3001/api/gameSession/getData/";
    public string token;
    public GameObject gameInfomationPanel;

    public void getData()
    {
        StartCoroutine(FetchData());
    }

    public void Start()
    {
        Debug.Log("Scene 1");
        getData();
        try
        {
            Uri userURI = new Uri(Application.absoluteURL);
            token = HttpUtility.ParseQueryString(userURI.Query).Get("token");
        }
        catch(Exception e)
        {
            Debug.Log("Cant iddentify test id");
        }
        PrepareGame.Instance.Prepare();
    }
    // /api/gameSession/$token ///
    // /api/gameSession/record/ (: userAnswers: [1,2,1,4]) // {questions: explaination,}
    public IEnumerator FetchData()
    {
        using (UnityWebRequest request = UnityWebRequest.Get(resourceURL+token))
        {
            yield return request.SendWebRequest();
            if (request.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(request.error);
            }
            else
            {
                GameInformation.Instance.setData(request.downloadHandler.text);

                Debug.Log(GameInformation.Instance.getQuestion(0).des);
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
    }

    
}
