using UnityEngine;
using System.Collections;

public class BackgroundImageController : MonoBehaviour {



	void FixedUpdate () {
		// 背景画像を一定速度で動かす
		// ある点をこえたら開始点に戻る
		transform.Translate (-0.02f, 0, 0);
		if (transform.position.x < -20) {
			transform.position = new Vector3 (17.3f, 0, 0);
		}
	}
}