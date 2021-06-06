using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class MenuManager : MonoBehaviour
{
    // Start is called before the first frame update

    public Text highscoretext;
    private int highscore;
    void Start()
    {
        this.highscore = PlayerPrefs.GetInt("HighScore",0);
        highscoretext.text = "Current Highscore \n" + this.highscore.ToString();
    }

    public void StartGame(){
        SceneManager.LoadScene("SampleScene");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
