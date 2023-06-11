using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndSceneManager : MonoBehaviour
{
    public TMP_Text questionTXT, answerTXT, resultTXT, explainTXT;
    int curQuestion = 0;
    // Start is called before the first frame update
    void Start()
    {
        curQuestion = 0;
        resultTXT.text = "RESULT: " + GameInformation.Instance.record.Score.ToString();
        UpdateQuestion(0);
    }

    void UpdateQuestion(int index)
    {
        questionTXT.text = GameInformation.Instance.record.questions[index].des;
        answerTXT.text = GameInformation.Instance.record.questions[index].correctAnswer.ToString();
        explainTXT.text = GameInformation.Instance.record.questions[index].Explaination;
    }
    public void NextButton()
    {
        curQuestion++;
        UpdateQuestion(curQuestion);
    }
}
