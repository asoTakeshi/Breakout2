using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    public int point;  //  得点
    public GameObject masterObj;  //  "Master"という名前のゲームオブジェクト用
    // Start is called before the first frame update
    public int initHp;   //  耐久力の最大値  
    private int currentHp;  //  耐久力の現在値

    public AudioClip hitSE;  //  破壊されない場合のSE    
    public AudioClip destroySE; //  破壊された場合のSE

    void Start()
    {
        //  Boxの耐久力を初期化します。(現在値＝最大値にする) 
        this.currentHp = initHp;

    }
    private void OnCollisionEnter(Collision collision)
    {
        //  ボールが接触するたびに、耐久力を1ずつ減らします。
        this.currentHp -= 1;
        //  壊れる場合
        if (this.currentHp <= 0)
        {
            //  破壊されるSEを再生
            AudioSource.PlayClipAtPoint(destroySE, transform.position);
            // 残りのブロック数を１つ減らす
            masterObj.GetComponent<GameMaster>().boxNum--;
            // スコアを加算する
            FindObjectOfType<Score>().AddPoint(point);
            // このゲームオブジェクト（ブロック）を破壊する
            Destroy(this.gameObject);
        }
        //  まだ壊れない場合
        else
        {
            //  ボールを跳ね返すSEを再生
            AudioSource.PlayClipAtPoint(hitSE, transform.position);
        }
    }

     
}
