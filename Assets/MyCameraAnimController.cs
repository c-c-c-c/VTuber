using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyCameraAnimController : MonoBehaviour {

    //Unityちゃんのオブジェクト
    //private GameObject unitychan;
    //private Vector3 unitychanFacePosition;

    //アニメーションするためのコンポーネントを入れる
    private Animator myAnimator;

    private string cameraButton;

	// Use this for initialization
	void Start () {
        //Animatorコンポーネントを取得
        this.myAnimator = GetComponent<Animator>();
    
    }
	
	// Update is called once per frame
	void Update () {

        if ( (Input.GetKey(KeyCode.C) && Input.GetKey(KeyCode.Alpha2) ) || cameraButton == "Crane")
        {
            this.myAnimator.enabled = true;
            this.myAnimator.SetTrigger("Crane");
            cameraButton = "";
        }

        if ((Input.GetKey(KeyCode.C) && Input.GetKey(KeyCode.Alpha4)) || cameraButton == "Panup" )
        {
            this.myAnimator.enabled = true;
            this.myAnimator.SetTrigger("Panup");
            cameraButton = "";
        }
	}

    //カメラクレーン
    public void GetMyCameraCrane()
    {
        this.cameraButton = "Crane";
    }

    public void GetMyCameraPanup()
    {
        this.cameraButton = "Panup";
    }

}
