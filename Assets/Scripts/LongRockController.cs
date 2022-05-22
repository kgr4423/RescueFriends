using UnityEngine;
using System.Collections;

public class LongRockController : MonoBehaviour {

	float size;
	float fallSpeedX, fallSpeedY;
	float rotSpeed;
	float explosionLine;
	int life;
	bool GameCanEnd;
	public GameObject explosionPrefab;   //爆発エフェクトのPrefab

	void Start () {
		// 変数の初期化
		this.size = 2.0f + 3.0f * Random.value;
		this.fallSpeedX = 200.0f + 200.0f * Random.value;
		this.fallSpeedY = -300.0f + 600.0f * Random.value;
		this.rotSpeed = -40.0f + 80.0f * Random.value;
		this.life = (int)(Mathf.Floor(size)) * 2 + 3;		
		
		// 岩のサイズをランダムに決められた値に変更
		transform.localScale = new Vector3(size, size, 1);

		// 岩の姿勢を水平にする
		transform.rotation = Quaternion.Euler(0.0f, 0.0f, 90.0f);

		// rigidbody2dを用いて岩に力とトルクをかける
		Vector2 genForce = new Vector2(-fallSpeedX, fallSpeedY);
		Rigidbody2D rb = GetComponent<Rigidbody2D>();
		rb.AddForce(genForce);
		rb.angularVelocity = rotSpeed;
	}

	
	
	void FixedUpdate () {
		//画面範囲から大きく離れたらオブジェクトを破壊する
		if (transform.position.x < -11.0f || transform.position.y < -12.0f || transform.position.y > 12.0f) {
			Destroy (gameObject);
		}

		// ゲームがエンディングに進めるようになったら
		// exploosionLineの値が大きくなり始め、それよりx座標が小さい岩を破壊する
		explosionLine = GameObject.Find ("GameManager").GetComponent<RockManager> ().GetExplosionLine();
		if(transform.position.x < explosionLine){
			// 爆発エフェクト生成
			Vector3 delta = transform.position;
			ExplosionEffect(delta);
			ExplosionEffect(delta);

			Destroy(gameObject);
		}
	}

	void ExplosionEffect(Vector3 delta){
		// 引数deltaで爆発エフェクト生成位置を調整する

		// 爆発音を鳴らす
		GameObject.Find ("explosionSE").GetComponent<SEController> ().genSE2 ();

		// 爆発エフェクトを生成する	
		Instantiate (explosionPrefab, transform.position - delta, Quaternion.identity);
	}

	void OnTriggerEnter2D(Collider2D coll) {
		GameCanEnd = GameObject.Find ("GameManager").GetComponent<FriendManager> ().AllFriendsIsDone();

		if(coll.gameObject == GameObject.Find("player")){
			// 対象がプレイヤーだった場合
			if(!GameCanEnd){
				// 爆発エフェクト生成
				Vector3 delta = transform.position - coll.transform.position;
				ExplosionEffect(delta);
				ExplosionEffect(delta);

				// プレイヤーを破壊する
				Destroy (coll.gameObject);

				// ゲームオーバーの表示を出す
				GameObject.Find ("Canvas").GetComponent<UIController> ().GameOver ();
			}

		}else{
			// 対象がプレイヤー以外、すなわち対象がbulletだった場合

            // 爆発エフェクトを生成
			Vector3 delta = transform.position - coll.transform.position;
			ExplosionEffect(delta);

			// 岩にbulletからの力をかける
			Vector2 bulletForce = new Vector2(15.0f, 0);
			Rigidbody2D rb = GetComponent<Rigidbody2D>();
			rb.AddForce(bulletForce);

			// 衝突したときにスコアを更新
			GameObject.Find ("Canvas").GetComponent<UIController> ().AddScore ();

			// 岩のライフを減らす
            life -= 1;
			
			// ライフがゼロならば岩を破壊する
			if(life == 0){
				Destroy (gameObject);
			}

			// bulletを破壊する
			Destroy (coll.gameObject);
        }
	}
}