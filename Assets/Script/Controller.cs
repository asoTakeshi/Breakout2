using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    [Header("Playerの移動速度")]
    public float moveSpeed = 0.1f;
    [Header("Playernの移動範囲の制限値")]
    public float limitPos = 4.25f;  // 追加。この範囲内でpositionを制限する。
   
   
    
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
        //playerの移動範囲を制限
        float z = Mathf.Clamp(transform.position.z, -limitPos, limitPos);
        // 制限確認後、位置情報を更新
        transform.position = new Vector3(transform.position.x, transform.position.y, z);
    }
}
