using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverScreen : MonoBehaviour
{   
    public Text text_score;
    public Text text_highscore;
    public void setup(int score , int highscore){
        gameObject.SetActive(true);
        FindObjectOfType<AudioManager>().Play("Death");
        FindObjectOfType<AudioManager>().Stop("Theme");
        if(score > highscore){
            text_score.text = "Your New Highscore :\n" + score.ToString();
        }
        text_score.text = "Your Score :\n" + score.ToString();

        text_highscore.text = "Your Highscore :\n" + highscore.ToString();
    }
}
