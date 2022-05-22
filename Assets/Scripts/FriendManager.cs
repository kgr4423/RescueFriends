using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendManager : MonoBehaviour
{
    int i;
    int count;
    string[] friendInfo = new string[5];
    // Start is called before the first frame update
    void Start()
    {
        for(i=0; i<5; ++i){
            friendInfo[i] = "yet";
        }
    }

    void FixedUpdate(){
        VariableController.rescuedFriendForResult = GetNumOfRescued();
        VariableController.killedFriendForResult = GetNumOfKilled();
    }

    // 状態yetかつ最も番号が小さいFriendは何番か（0から4）を返す
    // 状態yetのFriendがいなかったら-1を返す
    public int GetFirstFriendNum(){
        for(i=0; i<5; ++i){
            if(friendInfo[i] == "yet"){
                return i;
            }
        }
        return -1;
    }

    // 与えられた引数番号のFriendの状態を返す（dead, yet, on ,rescued）
    public string GetFriendInfo(int friendNum){
        return friendInfo[friendNum];
    }

    int GetNumOfRescued(){
        count =0;
        for(i=0; i<5; ++i){
            if(friendInfo[i] == "rescued"){
                count += 1;
            }
        }
        return count;
    }

    int GetNumOfKilled(){
        count =0;
        for(i=0; i<5; ++i){
            if(friendInfo[i] == "dead"){
                count += 1;
            }
        }
        return count;
    }

    // ゲームがエンディングに進めるかどうかを返す
    public bool AllFriendsIsDone(){
        for(i=0; i<5; ++i){
            if(friendInfo[i] == "yet" || friendInfo[i] == "on"){
                return false;
            }
        }

        return true;
    }

    // 第1引数番目のFriendの状態を第2引数に変える
    public void ChangeFriendInfo(int friendNum, string info){
        friendInfo[friendNum] = info;
    }
}
