using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PrepareGame : MonoBehaviour
{
    public TMP_Text username, testID;
    public static PrepareGame Instance;
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Prepare()
    {
        username.text = GameInformation.Instance.gameId;
        testID.text = GameInformation.Instance.id;
    }
    public void LoadMainLevel()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
