using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ライブラリの追加
using UnityEngine.SceneManagement;

public class GameStarter : MonoBehaviour {

    int count=0;

	void Update () {
        if(count < 500){
            count += 1;
        }

        // Enterが押された時、ゲームをスタートする
        if (count > 100 && Input.GetKey (KeyCode.Return)) {
			StartGame();
		}
	}

    void StartGame()
    {
        // GameSceneをロード
        SceneManager.LoadScene("MainScene");
    }
}