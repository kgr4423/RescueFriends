using UnityEngine;
using System.Collections;

public class BulletController : MonoBehaviour {
	
	void FixedUpdate () {
		// bulletを移動させる
		transform.Translate (0.8f, 0, 0);

		//画面外に出たらオブジェクトを破壊する
		if (transform.position.x > 12) {
			Destroy (gameObject);
		}
	}

}