using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour {
    //分数
    private int score = 0;
    //剩余时间
    private int gameTime = 0;

    private Grid gridComponent;
    //当前分数
    public Text scoreText;
    //剩余时间
    public Text timeText;
    //最终得分
    public Text finelScoreText;

    public GameObject OverPanel;

    public AnimationClip overAnimation;

    public AnimationClip TextAnimation;

    public bool isGameOver = false;

    private void OnGUI()
    {
        scoreText.text = score + "";
        timeText.text = gameTime + "";
    }

    public void initGameOver(int gametime , Grid grid) {
        gameTime = gametime;
        gridComponent = grid;
        StartCoroutine(timeConteller());
    }

    private IEnumerator timeConteller() {
        while (gameTime > 0) {
            if (gridComponent.getSystemUI.IsGame) {
                gameTime -= 1;
                if (gameTime <= 0) {
                    gameOver();
                    break;
                }
            }
            yield return new WaitForSeconds(1); 
        }
    }

    public void addScore(int s) {
        score += s;
        scoreText.GetComponent<Animator>().Play(TextAnimation.name);
    }

    public void addTime(int t) {
        gameTime += t;
        timeText.GetComponent<Animator>().Play(TextAnimation.name);
    }
    public void gameOver() {
        isGameOver = true;
        finelScoreText.text = score + "";
        OverPanel.SetActive(true);
        OverPanel.GetComponent<Animator>().Play(overAnimation.name);
    }
}
