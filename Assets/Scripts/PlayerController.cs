using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	private float progress = 0.15f;
	bool GameCanEnd;
	float explosionLine;
    public GameObject bulletPrefub;

	[SerializeField]
	private Animator playerAnime;


	void FixedUpdate () {
		GameCanEnd = GameObject.Find ("GameManager").GetComponent<FriendManager> ().AllFriendsIsDone();
		explosionLine = GameObject.Find ("GameManager").GetComponent<RockManager> ().GetExplosionLine();
		
		if(!GameCanEnd){
			//左右の移動を制御
			if (-8.8f < transform.position.x && transform.position.x < 8.8f){
				// (1)画面端じゃないとき
				if (Input.GetKey (KeyCode.A)) {
					playerAnime.SetFloat("X", -1f);
					transform.Translate (-progress, 0, 0);
				}else if (Input.GetKey (KeyCode.D)) {
					playerAnime.SetFloat("X", 1f);
					
					transform.Translate ( progress, 0, 0);
				}else{
					playerAnime.SetFloat("X", 0);
				}
			}else if(transform.position.x <= -8.8f){
				//(2)画面左端にいるとき
				if (Input.GetKey (KeyCode.D)) {
					playerAnime.SetFloat("X", 1f);
					transform.Translate ( progress, 0, 0);
				}else{
					playerAnime.SetFloat("X", 0);
				}
			}else{
				//(3)画面右端にいるとき
				if (Input.GetKey (KeyCode.A)) {
					playerAnime.SetFloat("X", -1f);
					transform.Translate (-progress, 0, 0);
				}else{
					playerAnime.SetFloat("X", 0);
				}
			}

			//上下の移動を制御
			if (-4.9f < transform.position.y && transform.position.y < 4.9f){
				// (1)画面端じゃないとき
				if (Input.GetKey (KeyCode.S)) {
					playerAnime.SetFloat("Y", -1f);
					transform.Translate (0, -progress, 0);
				}else if (Input.GetKey (KeyCode.W)) {
					playerAnime.SetFloat("Y", 1f);
					transform.Translate (0, progress, 0);
				}else{
					playerAnime.SetFloat("Y", 0);
				}
			}else if(transform.position.y <= -4.9f){
				//(2)画面下端にいるとき
				if (Input.GetKey (KeyCode.W)) {
					playerAnime.SetFloat("Y", 1f);
					transform.Translate (0, progress, 0);
				}else{
					playerAnime.SetFloat("Y", 0);
				}
			}else{
				//(3)画面上端にいるとき
				if (Input.GetKey (KeyCode.S)) {
					playerAnime.SetFloat("Y", -1f);
					transform.Translate (0, -progress, 0);
				}else{
					playerAnime.SetFloat("Y", 0);
				}
			}
		}else if(explosionLine > 10.0f){
			playerAnime.SetFloat("X", 0);
			playerAnime.SetFloat("Y", 0);
			transform.Translate (0.080f, 0, 0);

			if(transform.position.y < 0){
				transform.Translate (0, 0.005f, 0);
			}else if(transform.position.y > 0){
				transform.Translate (0, -0.005f, 0);
			}
		}
		

	}

	void Update(){
		// Spaceキーが押されたらビーム発射
		if (Input.GetKeyDown (KeyCode.Space)) {
			//発射サウンドを鳴らす
			GameObject.Find ("beamSE").GetComponent<SEController> ().genSE3 ();

			//発射の開始点を調整するためのvector
			Vector3 delta = new Vector3(0.29f, 0.38f, 0);
			delta = Vector3.Scale(delta, transform.localScale);

			//ビームの生成
			Instantiate (bulletPrefub, transform.position+delta, Quaternion.identity);
		}
	}
}