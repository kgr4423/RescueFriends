using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;

public class BlackScreenController : MonoBehaviour
{
    float explosionLine;
    GameObject blackScreen;

    void Start(){
        this.blackScreen = GameObject.Find("blackScreen");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        explosionLine = GameObject.Find ("GameManager").GetComponent<RockManager> ().GetExplosionLine();
		if(explosionLine > 32.0f){
			FadeBlack(1.0f);
		}else if(explosionLine > 30.0f){
			FadeBlack(0.8f);
		}else if(explosionLine > 28.0f){
			FadeBlack(0.6f);
		}else if(explosionLine > 25.0f){
			FadeBlack(0.4f);
		}else if(explosionLine > 20.0f){
			FadeBlack(0.2f);
		}
    }

    public void FadeBlack(float alpha){
		this.blackScreen.GetComponent<Image>().color = new Color(255, 255, 255, alpha);
        
	}
}
