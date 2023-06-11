using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LoadSceneQuestion
{
    public GameObject scenePanel;
    public GameInformation.QuestionData question;
    // Start is called before the first frame update

    public void setData()
    {
        question = GameInformation.Instance.getCurQuestion();
        scenePanel.transform.GetChild(6).GetComponent<TextMeshProUGUI>().text = "Question: " + question.des;

        for (int i = 0; i < 4; i++)
        {
            Button btn = scenePanel.transform.GetChild(i + 1).GetComponent<Button>();
            btn.GetComponentInChildren<TextMeshProUGUI>().text = question.answers[i];
        }
    }
}
