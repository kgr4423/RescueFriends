using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ライブラリの追加
using UnityEngine.SceneManagement;

public class GameEnder : MonoBehaviour {

    bool GameCanEnd;
    float explosionLine;
    int count = 0;

	void Update () {
        if(count < 1100){
            count += 1;
        }
        
        // Enterが押されたらスタート画面に戻る
        if (count >= 100 && Input.GetKey (KeyCode.Return)) {
			MainToStart();
		}

        GameCanEnd = GameObject.Find ("GameManager").GetComponent<FriendManager> ().AllFriendsIsDone();
        if(GameCanEnd){
            GameObject.Find ("BGM").GetComponent<SEController> ().stopSE();
        }

        explosionLine = GameObject.Find ("GameManager").GetComponent<RockManager> ().GetExplosionLine();
        if(explosionLine > 70.0f){
            MainToEnd();
        }
	}

    void MainToStart()
    {
        // StartSceneをロード
        SceneManager.LoadScene("StartScene");
    }
    void MainToEnd()
    {
        // StartSceneをロード
        SceneManager.LoadScene("EndScene");
    }
}