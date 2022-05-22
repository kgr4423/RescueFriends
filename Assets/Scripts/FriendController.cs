using UnityEngine;
using System.Collections;

public class FriendController : MonoBehaviour {

	int friendNum;
    float size;
	float fallSpeedX, fallSpeedY;
	float rotSpeed;
	int life;
	public GameObject explosionPrefab;

	[SerializeField]
	private Animator friendAnime;

	void Start () {

		// 変数の初期化
		this.friendNum = GameObject.Find("GameManager").GetComponent<FriendManager>().GetFirstFriendNum();
        this.size = 1.3f;
		this.fallSpeedX = 20.0f + 20.0f * Random.value;
		this.fallSpeedY = -5.0f + 10.0f * Random.value;
		this.rotSpeed = -40.0f + 80.0f * Random.value;
		this.life = 1;

		// friendNumが-1だったらFriendは即座に破壊する
		if(friendNum == -1){
			Destroy (gameObject);
		}

		// Friendのアニメーションを変更する
		friendAnime.SetFloat("X", (float)friendNum);

		// FriendInfoを更新
		GameObject.Find ("GameManager").GetComponent<FriendManager>().ChangeFriendInfo(friendNum, "on");

        // サイズを調整
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
			// FriendInfoを更新
			GameObject.Find ("GameManager").GetComponent<FriendManager>().ChangeFriendInfo(friendNum, "yet");
			
			Destroy (gameObject);
		}
	}



	void OnTriggerEnter2D(Collider2D coll) {
		if(coll.gameObject == GameObject.Find("player")){
			// 対象がプレイヤーだった場合

            // 救出エフェクト生成
            RescueEffect();

			// スコアを更新
			GameObject.Find ("Canvas").GetComponent<UIController> ().AddScore1000 ();

			// Playerが飲み込むアニメーションを再生する
			GameObject.Find ("player").GetComponent<Animator> ().SetTrigger("catched");
			
			// Uiの救出アイコンを明るくする
			GameObject.Find ("Canvas").GetComponent<UIController> ().BrightenImage(friendNum);

			// FriendInfoを更新
			GameObject.Find ("GameManager").GetComponent<FriendManager>().ChangeFriendInfo(friendNum, "rescued");

            // Friendを破壊する
			Destroy (gameObject);


		}else{
            // 対象がプレイヤー以外、すなわち対象がbulletだった場合

			if (transform.position.x < 8.6f) {
				// 爆発エフェクトを生成
				ExplosionEffect();
				ScreamEffect(friendNum);

				// Uiの救出アイコンを明るくする
				GameObject.Find ("Canvas").GetComponent<UIController> ().RedenImage(friendNum);

				// FriendInfoを更新
				GameObject.Find ("GameManager").GetComponent<FriendManager>().ChangeFriendInfo(friendNum, "dead");

				// 岩のライフを減らす
				this.life -= 1;

				// ライフがゼロならば岩を破壊する
				if(this.life == 0){
					Destroy (gameObject);
				}

				
			}

			// bulletを破壊する
			Destroy (coll.gameObject);
        }
	}

	void ExplosionEffect(){
		// 爆発音を鳴らす
		GameObject.Find ("explosionSE").GetComponent<SEController> ().genSE ();

		// 爆発エフェクトを生成する	
		Instantiate (explosionPrefab, transform.position, Quaternion.identity);
	}

    void RescueEffect(){
		// 救出音を鳴らす
		GameObject.Find ("rescueSE").GetComponent<SEController> ().genSE ();
	}

    void ScreamEffect(int friendNum){
		// 悲鳴音を鳴らす
		//GameObject.Find ("screamSE").GetComponent<SEController> ().genSE ();
		if(friendNum == 0){
			GameObject.Find ("dorayakiScreamSE").GetComponent<SEController> ().genSE ();
		}else if(friendNum ==1){
			GameObject.Find ("kaniScreamSE").GetComponent<SEController> ().genSE ();
		}else if(friendNum ==2){
			GameObject.Find ("nidaScreamSE").GetComponent<SEController> ().genSE ();
		}else if(friendNum ==3){
			GameObject.Find ("nyobakeScreamSE").GetComponent<SEController> ().genSE ();
		}else{
			GameObject.Find ("QQScreamSE").GetComponent<SEController> ().genSE ();
		}
	}
}