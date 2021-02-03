using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    public int point;  
    public GameObject masterObj;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnCollisionEnter(Collision collision)
    {
        //スコア処理を追加
        FindObjectOfType<Score>().AddPoint(point);
        masterObj.GetComponent<GameMaster>().boxNum--;
        Destroy(gameObject);
    }
}
