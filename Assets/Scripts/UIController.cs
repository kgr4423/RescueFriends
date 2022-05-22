using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIController : MonoBehaviour {

	int score = 0;
	
	GameObject scoreText;
    GameObject gameOverText;
	GameObject gameEndText;

	GameObject dorayaki;
	GameObject kani;
	GameObject nida;
	GameObject nyobake;
	GameObject QQ;


	void Start () {
		this.scoreText = GameObject.Find ("Score");
		this.gameOverText = GameObject.Find ("GameOver");
		this.gameEndText = GameObject.Find("EndText");

		this.dorayaki = GameObject.Find("dorayaki");
		this.kani = GameObject.Find("kann-ninn");
		this.nida = GameObject.Find("nida");
		this.nyobake = GameObject.Find("nyobake");
		this.QQ = GameObject.Find("QQ");
	}

	void FixedUpdate () {
		scoreText.GetComponent<Text> ().text = "  Score       " + score.ToString("D5");

		VariableController.scoreForResult = score;

		
	}

	public void GameOver(){
		this.gameOverText.GetComponent<Text>().text = "You are Dead";
		this.gameEndText.GetComponent<Text>().text = "Press Enter key to End";
	}

	public void AddScore(){
		this.score += 10;
	}

	public void AddScore1000(){
		this.score += 1000;
	}

	

	public void BrightenImage(int order){
		if(order == 0){
			this.dorayaki.GetComponent<Image>().color = new Color(255, 255, 255, 255);
		}else if(order ==1){
			this.kani.GetComponent<Image>().color = new Color(255, 255, 255, 255);
		}else if(order ==2){
			this.nida.GetComponent<Image>().color = new Color(255, 255, 255, 255);
		}else if(order ==3){
			this.nyobake.GetComponent<Image>().color = new Color(255, 255, 255, 255);
		}else{
			this.QQ.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
		}
	}

	public void RedenImage(int order){
		if(order == 0){
			this.dorayaki.GetComponent<Image>().color = new Color(255, 0, 0, 255);
		}else if(order ==1){
			this.kani.GetComponent<Image>().color = new Color(255, 0, 0, 255);
		}else if(order ==2){
			this.nida.GetComponent<Image>().color = new Color(255, 0, 0, 255);
		}else if(order ==3){
			this.nyobake.GetComponent<Image>().color = new Color(255, 0, 0, 255);
		}else{
			this.QQ.GetComponent<Image>().color = new Color32(255, 0, 0, 255);
		}
	}
}