using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    private bool isGameOver = false;
    public GameOverScreen gameOverScreen;
    private int highScore; 

    private void Start() {
        this.highScore = PlayerPrefs.GetInt("HighScore",0);       
    }
    public void EndGame(int score){
        if(!this.isGameOver){
            if(score > this.highScore){
                this.highScore = score; 
                PlayerPrefs.SetInt("HighScore",score);
            }
            Debug.Log("Game Over");
            gameOverScreen.setup(score,this.highScore);
            this.isGameOver= true;
        }
        
    }

    public void Restart(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void MainMenu(){
         SceneManager.LoadScene("MenuScreen");
    }

    public void PlayGame(){
        SceneManager.LoadScene("SampleScene");
    }
}
