using UnityEngine;
using System.Collections;

public class RockController : MonoBehaviour {

	float size;
	float fallSpeedX, fallSpeedY;
	float rotSpeed;
	float explosionLine;
	int life;
	bool GameCanEnd;
	public GameObject explosionPrefab;

	void Start () {
		// 変数の初期化
		this.size = 2.0f + 3.5f * Random.value;
		this.fallSpeedX = 20.0f + 50.0f * Random.value;
		this.fallSpeedY = -5.0f + 10.0f * Random.value;
		this.rotSpeed = -40.0f + 80.0f * Random.value;
		this.life = (int)(Mathf.Floor(size)) - 1;
		
		// 岩のサイズをランダムに決められた値に変更
		transform.localScale = new Vector3(size, size, 1);

		// rigidbody2dを用いて岩に力とトルクをかける
		Vector2 genForce = new Vector2(-fallSpeedX, fallSpeedY);
		Rigidbody2D rb = GetComponent<Rigidbody2D>();
		rb.AddForce(genForce);
		rb.angularVelocity = rotSpeed;
	}
	
	void FixedUpdate () {
		//画面範囲から大きく離れたらオブジェクトを破壊する
		if (transform.position.x < -10.0f || transform.position.y < -8.0f || transform.position.y > 8.0f) {
			Destroy (gameObject);
		}

		// ゲームがエンディングに進めるようになったら
		// exploosionLineの値が大きくなり始め、それよりx座標が小さい岩を破壊する
		explosionLine = GameObject.Find ("GameManager").GetComponent<RockManager> ().GetExplosionLine();
		if(transform.position.x < explosionLine){
			// 爆発エフェクト生成
			ExplosionEffect();
			ExplosionEffect();

			Destroy(gameObject);
		}
		
	}

	void ExplosionEffect(){
		// 爆発音を鳴らす
		GameObject.Find ("explosionSE").GetComponent<SEController> ().genSE2 ();

		// 爆発エフェクトを生成する	
		Instantiate (explosionPrefab, transform.position, Quaternion.identity);
	}

	void OnTriggerEnter2D(Collider2D coll) {
		GameCanEnd = GameObject.Find ("GameManager").GetComponent<FriendManager> ().AllFriendsIsDone();

		if(coll.gameObject == GameObject.Find("player")){
			// 対象がプレイヤーだった場合
			if(!GameCanEnd){
				// 爆発エフェクト生成
				ExplosionEffect();
				ExplosionEffect();

				// プレイヤーを破壊する
				Destroy (coll.gameObject);

				// ゲームオーバーの表示を出す
				GameObject.Find ("Canvas").GetComponent<UIController> ().GameOver ();
			}

		}else{
            // 対象がプレイヤー以外、すなわち対象がbulletだった場合

            // 爆発エフェクトを生成
            ExplosionEffect();

            // 岩にbulletからの力をかける
			Vector2 bulletForce = new Vector2(20.0f, 0);
			Rigidbody2D rb = GetComponent<Rigidbody2D>();
			rb.AddForce(bulletForce);

			// 衝突したときにスコアを更新
			GameObject.Find ("Canvas").GetComponent<UIController> ().AddScore ();

            // 岩のライフを減らす
            this.life -= 1;

            // ライフがゼロならば岩を破壊する
			if(this.life == 0){
				Destroy (gameObject);
			}

            // bulletを破壊する
			Destroy (coll.gameObject);
        }
	}
}