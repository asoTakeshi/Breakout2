using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    // スコアを表示するUIの取得用
    public Text scoreText;
    // ハイスコアを表示するUIの取得用
    public Text highScoreText;
    // スコアのカウント用
    private int score;
    // ハイスコアのカウント用
    private int highScore;
    // PlayerPrefsで保存するためのキー
    private string highScoreKey = "highScoer";


    void Start()
    {
       Initialize ();
    }
    // ゲーム開始前の状態に戻す
    private void Initialize()
    {
        // スコアを0に戻す
        score = 0;
        // highScoreKeyの値で保存されているハイスコアを検索して取得する。保存されてなければ0を取得する。
        highScore = PlayerPrefs.GetInt(highScoreKey, 0);
    }

    // ポイントの追加。修飾子をpublicにしているので外部より参照できるメソッドになっている
    public void AddPoint(int point)  //　外部より受け取ったint型の引数をpointとして受け取る
    {
        score += point;

        Debug.Log(score);    // ここで確認すると、ブロックからの情報が届いているか確認できる。表示されなければ届いていないということになる。

        // スコアがハイスコアより大きくなれば、ハイスコアを更新する
        if (highScore < score)
        {
            highScore = score;

            Debug.Log(highScore);   // ハイスコアの更新が正常に行われたか確認できる
        }
        // ゲーム画面上のスコアとハイスコアの表示を更新する
        DisplayScores();


    }
    // ゲーム画面上のスコアとハイスコアの表示を更新する
    private void DisplayScores()
    {
        // 現在のスコアとハイスコアを画面に表示する
        scoreText.text = score.ToString();
        highScoreText.text = highScore.ToString();

    }
    // ハイスコアの保存
    public void Save()
    {
        // ハイスコアを保存する
        PlayerPrefs.SetInt(highScoreKey, highScore);
        PlayerPrefs.Save();

        // ゲーム開始前の状態に戻す
        Initialize();


    }
}
