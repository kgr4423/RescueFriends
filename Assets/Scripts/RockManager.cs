using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockManager : MonoBehaviour
{

    bool GameCanEnd;
    float explosionLine;
    // Start is called before the first frame update
    void Start()
    {
        explosionLine = -13f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        GameCanEnd = GameObject.Find ("GameManager").GetComponent<FriendManager> ().AllFriendsIsDone();

        if(GameCanEnd){
            explosionLine += 0.15f;
        }

        if(explosionLine > 10.0f && explosionLine < 11.0f){
            GameObject.Find ("mainEndSE").GetComponent<SEController> ().genSE ();
        }
    }

    public float GetExplosionLine(){
        return explosionLine;
    }
}
