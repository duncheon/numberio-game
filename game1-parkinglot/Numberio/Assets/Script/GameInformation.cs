using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInformation : MonoBehaviour 
{

    [System.Serializable]
    public class QuestionData
    {
        public int id;
        public string des;
        public string[] answers;
    }
    public class RecordQuestionData
    {
        public string des;
        public string[] Answers;
        public int correctAnswer;
        public int Difficulty;
        public string Explaination;
        public string createAt;
        public bool Active;
        public string id;
    }

    [Serializable]
    private class FetchDataModel
    {
        public List<QuestionData> questions;
        public string gameId;
        public int level;
        public string email;
        public string id;
    }
    public class RecordModel
    {
        public int Score;
        public List<bool> selectionResult;
        public List<RecordQuestionData> questions;
    }

    public RecordModel record;

    public static GameInformation Instance;

    public string gameId;
    public int level;
    public string email;
    public string id;
    public int curQuestion = 0;

    //public string token;
    [SerializeField]
    public List<QuestionData> questions;
    public List<int> answers;

    private void Awake()
    {
       Instance = this;

        DontDestroyOnLoad(this.gameObject);
    }


    public void setData(string jsonData)
    {
        Debug.Log(jsonData);
        FetchDataModel newData = new FetchDataModel();
        newData = JsonUtility.FromJson<FetchDataModel>(jsonData);
        this.gameId = newData.gameId;
        this.level = newData.level;
        this.email = newData.email;
        this.id = newData.id;
        this.questions = newData.questions;

    }
    public QuestionData getQuestion(int idx)
    {
        return questions[idx];
    }

    public void nextQuestion()
    {
        curQuestion+= 1;
    }

    public int getTotalQuestion()
    {
        return questions.Count;
    }

    public QuestionData getCurQuestion()
    {
        return questions[curQuestion];
    }

    public void saveAnswers(int idx, int answer)
    {
        if (this.answers == null)
        {
            answers = new List<int>();
        }

        if (idx > answers.Count - 1)
        {
            answers.Add(answer);
        }
        else
        {
            answers[idx] = answer;
        }

    }
}


