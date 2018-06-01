using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerator : MonoBehaviour
{

    public GameObject carPrefab;
    public GameObject coinPrefab;
    public GameObject conePrefab;

    //スタート地点
    private int startPos = -160;
    //ゴール地点
    private int goalPos = 120;

    //アイテム生成距離
    private int itemMakeLength = 45;

    //アイテムを出すx方向の範囲
    private float posRange = 3.4f;

    //ユニティちゃん
    private GameObject unitychan;

    //アイテム生成すべき場所
    private int itemMakePosUpd ;

    // Use this for initialization
    void Start()
    {
        //unityちゃんの場所を取得
        this.unitychan = GameObject.Find("unitychan");

 
        // はじめ45m分アイテムを作成
        MakeRandomItem(startPos, startPos + itemMakeLength);

    }

    // Update is called once per frame
    void Update() {

        if (((this.unitychan.transform.position.z - startPos) - itemMakePosUpd) > 5
           && goalPos - itemMakePosUpd > 10           
           ) {
            //Debug.Log(itemMakePosUpd);
            MakeRandomItem(itemMakePosUpd, itemMakePosUpd + 5);
        }
    }

    // 
    private void MakeRandomItem (int makeStartPos, int makeEndPos) {
        
        for (int i = makeStartPos; i < makeEndPos; i += 5) {
            int num = Random.Range(0, 30);
            if (num <= 1) {
                //コーンをx軸方向に一直線に生成
                for (float j = -1; j <= 1; j += 0.4f)
                {
                    GameObject cone = Instantiate(conePrefab) as GameObject;
                    cone.transform.position = new Vector3(4 * j, cone.transform.position.y, i);
                }
            } else {
                for (int j = -1; j < 2; j++)
                {
                    //レーンごとにアイテムを生成
                    int item = Random.Range(1, 11);
                    //アイテムを置くZ座標のオフセットをランダムに設定
                    int offsetZ = Random.Range(-1, 2);
                    //20%コイン配置;10%車両;70%なし
                    if (1 <= item && item <= 3)
                    {
                        //コインを生成
                        GameObject coin = Instantiate(coinPrefab) as GameObject;
                        coin.transform.position = new Vector3(posRange * j, coin.transform.position.y, i + offsetZ);

                    }
                    else if (item == 4)
                    {
                        //車を生成
                        GameObject car = Instantiate(carPrefab) as GameObject;
                        car.transform.position = new Vector3(posRange * j, car.transform.position.y, i + offsetZ);
                    }
                }
            }
            itemMakePosUpd = i + 5;
        }
    }
}
