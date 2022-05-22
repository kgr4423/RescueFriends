using UnityEngine;
using System.Collections;

public class RockGenerator : MonoBehaviour {

	public GameObject rockPrefub;
	public GameObject diagonalRockPrefub;
	public GameObject longRockPrefub;
	int frameCount;
	int gameLevel;
	bool GameCanEnd;

	void Start () {
		frameCount=0;
		gameLevel=60;
	}

	void FixedUpdate(){
		GameCanEnd = GameObject.Find ("GameManager").GetComponent<FriendManager> ().AllFriendsIsDone();
		Debug.Log(gameLevel);

		if(GameCanEnd){
			frameCount = -1;
		}else{
			frameCount += 1;
		}

		if(frameCount%gameLevel == 0){
			GenRock();
		}

		if(frameCount%500 == 0){
			GenLongRock();
		}

		if(frameCount%gameLevel == 0){
			GenDiagonalRock();
		}

		if(gameLevel == 10){
			//do nothing
		}else if(frameCount%600 == 0){
			gameLevel -= 5;
		}
	}
	
	public Sprite GetSprite(string fileName, string spriteName) {
		// fileNameのパスにあるSpriteを読み込む
        Sprite[] sprites = Resources.LoadAll<Sprite>(fileName);

		// spriteNameに対応したSpriteの要素を返す
        return System.Array.Find<Sprite>(sprites, (sprite) => sprite.name.Equals(spriteName));
    }

	void ChangeSpriteForRock(){
		// "rock_0" 〜 "rock_4" の文字列をランダムで生成
        string name = "rock_" + Random.Range(0, 5);

        // Spriteを取得
        Sprite sp = GetSprite("Sprites/rock", name);

        // SpriteRendererを取得する
        SpriteRenderer sr = rockPrefub.GetComponent<SpriteRenderer>();
		
        // Spriteを変更する
        sr.sprite = sp;
	}

	void ChangeSpriteForDiagonalRock(){
		// "rock_0" 〜 "rock_3" の文字列をランダムで生成
        string name = "diagonalRock_" + Random.Range(0, 4);

        // Spriteを取得
        Sprite sp = GetSprite("Sprites/diagonalRock", name);

        // SpriteRendererを取得する
        SpriteRenderer sr = rockPrefub.GetComponent<SpriteRenderer>();
		
        // Spriteを変更する
        sr.sprite = sp;
	}

	void GenRock () {
		// Spriteの変更
		ChangeSpriteForRock();

		// rockPrefubの生成
		Instantiate (rockPrefub, new Vector3 (10.0f, -6.0f + 12.0f * Random.value, 0), Quaternion.identity);
	}

	void GenDiagonalRock () {
		// Spriteの変更
		ChangeSpriteForDiagonalRock();

		// diagonalRockPrefubの生成
		if(Random.Range(0, 2) == 0){
			Instantiate (diagonalRockPrefub, new Vector3 (9.0f - 9.0f * Random.value, -5.5f, 0), Quaternion.identity);
		}else{
			Instantiate (diagonalRockPrefub, new Vector3 (9.0f - 9.0f * Random.value, 5.5f, 0), Quaternion.identity);
		}
	}

	void GenLongRock () {
		// longRockPrefubの生成
		int temp = Random.Range(0, 5);
		if(temp == 0){
			Instantiate (longRockPrefub, new Vector3 (10.0f, -5.5f, 0), Quaternion.identity);
		}else if(temp == 1){
			Instantiate (longRockPrefub, new Vector3 (10.0f, 5.5f, 0), Quaternion.identity);
		}else if(temp == 2){
			Instantiate (longRockPrefub, new Vector3 (3.0f, 6.0f, 0),  Quaternion.identity);
		}else if(temp == 3){
			Instantiate (longRockPrefub, new Vector3 (3.0f, -6.0f, 0), Quaternion.identity);
		}else{
			Instantiate (longRockPrefub, new Vector3 (18.0f, 0, 0), Quaternion.identity);
		}
	}



	


}