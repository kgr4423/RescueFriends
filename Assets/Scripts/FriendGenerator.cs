using UnityEngine;
using System.Collections;

public class FriendGenerator : MonoBehaviour {

	public GameObject friendPrefub;
	int frameCount;
	int gameLevel;
	bool GameCanEnd;

	void Start () {
		frameCount=0;
		gameLevel=1250;
	}

	void FixedUpdate(){
		GameCanEnd = GameObject.Find ("GameManager").GetComponent<FriendManager> ().AllFriendsIsDone();

		if(GameCanEnd){
			frameCount = -1;
		}else{
			frameCount += 1;
		}
		
		if(frameCount%gameLevel == 1000){
			GenFriend();
		}

	}
	

	void GenFriend () {
		// friendPrefubの生成
		Instantiate (friendPrefub, new Vector3 (10.0f, 0, 0), Quaternion.identity);
	}

}