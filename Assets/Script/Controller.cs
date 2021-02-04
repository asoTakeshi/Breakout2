using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    [Header("Playerの移動速度")]
    public float moveSpeed = 0.1f;
    [Header("Playernの移動範囲の制限値")]
    public float limitPos = 4.25f;  // 追加。この範囲内でpositionを制限する。
    public float tilt; // 傾ける角度の設定値。Inspectorで変更できるようにするため public にて宣言
    public float duration;   // 傾ける時間の設定値。Inspectorで変更できるようにするため public にて宣言
    public bool isTilt;     // playerゲームオブジェクトが傾いてるか傾いてないか判断。傾いている間は傾けられないように制御するために利用している。true が傾いている状態 




    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += transform.forward * 0.1f;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position -= transform.forward * moveSpeed;

        }
        // マウスの右クリックをした際に、playerゲームオブジェクトが傾いている状態ではないなら
        if (Input.GetMouseButtonDown(1) && !isTilt)
        {
            // playerゲームオブジェクトを傾ける
            StartCoroutine(Tilt());
        }
        // playerゲームオブジェクトの高さを一定に保つための制御(傾けた際に斜め移動しないようにするために必要)
        transform.position = new Vector3(-6.5f, transform.position.y, transform.position.z);


        //playerの移動範囲を制限
        float z = Mathf.Clamp(transform.position.z, -limitPos, limitPos);
        // 制限確認後、位置情報を更新
        transform.position = new Vector3(transform.position.x, transform.position.y, z);
    }
    ////* 新しいメソッドを１つ追加 *////

    /// <summary>
    /// playerゲームオブジェクトを傾ける
    /// </summary>
    /// <returns></returns>
    private IEnumerator Tilt()
    {
        // 傾ける角度を設定値内でランダムに設定して、現在のRotationの値にする
        transform.eulerAngles = new Vector3(0, Random.Range(-tilt, tilt), 0);

        // 傾いている状態にする
        isTilt = true;

        // 傾いている時間分だけ傾きを保持する。あまり長い時間傾けない方がよい
        yield return new WaitForSeconds(duration);

        // 傾いていない状態にする
        isTilt = false;

        // 傾いたplayerゲームオブジェクトのRotationを初期値に戻す
        transform.eulerAngles = Vector3.zero;
    }
}
