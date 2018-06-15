using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyCameraAnimController : MonoBehaviour {

    //Unityちゃんのオブジェクト
    //private GameObject unitychan;
    //private Vector3 unitychanFacePosition;

    //アニメーションするためのコンポーネントを入れる
    private Animator myAnimator;

	// Use this for initialization
	void Start () {
        //Animatorコンポーネントを取得
        this.myAnimator = GetComponent<Animator>();
    
    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKey(KeyCode.C) && Input.GetKey(KeyCode.Alpha2))
        {
            this.myAnimator.SetTrigger("Crane");
        }
	}
}
