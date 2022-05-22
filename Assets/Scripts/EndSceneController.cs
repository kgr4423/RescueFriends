using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndSceneController : MonoBehaviour
{
    int frameCount;
    float alpha;
    int NumOfkilled;
    int NumOfRescued;
    int scoreResult;
    private float time;
    string end;
    GameObject tinkle;
    GameObject blackScreen;
    GameObject whiteScreen;
    GameObject resultText;
    GameObject resultScoreText;
    GameObject endKeyText;
    GameObject endRootText;
    GameObject happyEndImage;
    GameObject bitterEndImage;
    GameObject badEndImage;

    // Start is called before the first frame update
    void Start()
    {
        alpha = 0.0f;
        frameCount = 0;
        this.tinkle = GameObject.Find("tinkle");
        this.blackScreen = GameObject.Find("blackScreen");
        this.whiteScreen = GameObject.Find("whiteScreen");
        this.resultScoreText = GameObject.Find("ResultScoreText");
        this.NumOfkilled = VariableController.killedFriendForResult;
        this.NumOfRescued = VariableController.rescuedFriendForResult; 
        this.scoreResult = VariableController.scoreForResult;
        // this.NumOfkilled = 0;
        // this.NumOfRescued = 3;
        // this.scoreResult = 100;
        this.resultText = GameObject.Find("ResultText");
        this.endKeyText = GameObject.Find("EndKeyText");
        this.endRootText = GameObject.Find("EndRootText");
        this.happyEndImage = GameObject.Find("HappyEndImage");
        this.bitterEndImage = GameObject.Find("BitterEndImage");
        this.badEndImage = GameObject.Find("BadEndImage");

        if(NumOfRescued == 5){
            this.end = "happy";
        }else if(NumOfRescued == 0){
            this.end = "bad";
        }else{
            this.end = "bitter";
        }

        
    }
    void Update()
    {
        if(frameCount > 500){
            if(NumOfRescued == 5){
                alpha = GetAlphaColor();
                this.tinkle.GetComponent<SpriteRenderer>().color = new Color(255, 210, 0, alpha);
            }else if(NumOfRescued == 0){
                alpha = GetAlphaColor();
                this.tinkle.GetComponent<SpriteRenderer>().color = new Color(255, 0, 0, alpha);
            }else{
                alpha = GetAlphaColor();
                this.tinkle.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, alpha);
            }
            
        }
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        frameCount += 1;
        this.tinkle.transform.Translate (0.003f, 0, 0);

        if(frameCount == 50){
            if(NumOfRescued == 0){
            GameObject.Find ("EndBGM3").GetComponent<SEController> ().genSE ();
            }else if(NumOfRescued == 5){
                GameObject.Find ("EndBGM").GetComponent<SEController> ().genSE ();
            }else{
                GameObject.Find ("EndBGM2").GetComponent<SEController> ().genSE ();
            }
        }

        
        if(frameCount == 1){
			FadeBlack(0.8f);
		}
        if(frameCount == 20){
			FadeBlack(0.6f);
		}
        if(frameCount == 50){
			FadeBlack(0.4f);
		}
        if(frameCount == 80){
			FadeBlack(0.2f);
		}
        if(frameCount == 100){
			FadeBlack(0.0f);
		}
        

        if(frameCount == 290){
            GameObject.Find ("TextGenSE").GetComponent<SEController> ().genSE ();
        }

        if(frameCount == 300){
            

            if(NumOfRescued == 0){
                resultText.GetComponent<Text>().text = "友ヲ スベテ 殺シタ ";
            }else if(NumOfRescued == 5){
                resultText.GetComponent<Text>().text = "スベテノ 友ヲ 救出シタ";
            }else{
                resultText.GetComponent<Text>().text = "友ヲ " + NumOfRescued.ToString("D1") + "人 救出シタ ガ  " + NumOfkilled.ToString("D1") + "人 殺シタ";
            }
            
        }

        if(frameCount == 690){
            GameObject.Find ("TextGenSE").GetComponent<SEController> ().genSE ();
        }

        if(frameCount == 700){

            if(NumOfRescued == 0){
                resultScoreText.GetComponent<Text>().text = "Score : " + scoreResult.ToString("D");
            }else if(NumOfRescued == 5){
                resultScoreText.GetComponent<Text>().text = "Score : " + scoreResult.ToString("D");
            }else{
                resultScoreText.GetComponent<Text>().text = "Score : " + scoreResult.ToString("D");
            }
        }

        if(frameCount == 1100){
			FadeWhite(0.2f);
		}
        if(frameCount == 1130){
			FadeWhite(0.4f);
		}
        if(frameCount == 1160){
			FadeWhite(0.6f);
		}
        if(frameCount == 1190){
			FadeWhite(0.8f);
		}
        if(frameCount == 1220){
			FadeWhite(1.0f);
		}

        if(frameCount == 1300){
			FadeEndImage(end, 0.2f);
		}
        if(frameCount == 1320){
			FadeEndImage(end, 0.4f);
		}
        if(frameCount == 1340){
			FadeEndImage(end, 0.6f);
		}
        if(frameCount == 1360){
			FadeEndImage(end, 0.8f);
		}
        if(frameCount == 1380){
			FadeEndImage(end, 1.0f);
		}

        if(frameCount == 1400){
            if(end == "happy"){
            endRootText.GetComponent<Text>().text = "HAPPY END";
            }else if(end == "bad"){
                endRootText.GetComponent<Text>().text = "BAD END";
            }else{
                endRootText.GetComponent<Text>().text = "BITTER END";
            }
        }

        if(frameCount == 1420){
			endRootText.GetComponent<Text>().color = new Color(0, 0, 0, 0.2f);
		}
        if(frameCount == 1440){
			endRootText.GetComponent<Text>().color = new Color(0, 0, 0, 0.8f);
		}
        if(frameCount == 1460){
			endRootText.GetComponent<Text>().color = new Color(0, 0, 0, 1.0f);
		}

        if(frameCount == 1465){
            endKeyText.GetComponent<Text>().text = "Press Enter key to Back";
        }
        

        if(frameCount > 800){
            if (Input.GetKey (KeyCode.Return)) {

                Invoke(nameof(Black), 1.0f);

                Invoke(nameof(StopBGM), 1.0f);
                
                Invoke(nameof(EndToStart), 3.0f);
            }
        }

        

    }

    void StopBGM(){
        if(NumOfRescued == 0){
            GameObject.Find ("EndBGM3").GetComponent<SEController> ().stopSE();
        }else if(NumOfRescued == 5){
            GameObject.Find ("EndBGM").GetComponent<SEController> ().stopSE ();
        }else{
            GameObject.Find ("EndBGM2").GetComponent<SEController> ().stopSE ();
        }
    }
    void EndToStart(){
        SceneManager.LoadScene("StartScene");
    }
    void Black(){
		this.blackScreen.GetComponent<Image>().color = new Color(255, 255, 255, 1.0f);
        
	}

    public void FadeBlack(float alpha){
		this.blackScreen.GetComponent<Image>().color = new Color(255, 255, 255, alpha);
        
	}

    public void FadeWhite(float alpha){
		this.whiteScreen.GetComponent<Image>().color = new Color(255, 255, 255, alpha);
        
	}

    public void FadeEndImage(string endInfo, float alpha){
        if(endInfo == "happy"){
            this.happyEndImage.GetComponent<Image>().color = new Color(255, 255, 255, alpha);
        }else if(endInfo == "bitter"){
            this.bitterEndImage.GetComponent<Image>().color = new Color(255, 255, 255, alpha);
        }else if(endInfo == "bad"){
            this.badEndImage.GetComponent<Image>().color = new Color(255, 255, 255, alpha);
        }
		
        
	}

    float GetAlphaColor(){

        if(Mathf.Sin(time) < 0.3f){
            time += Time.deltaTime * 2.0f;
            return 0.0f;
        }else{
            time += Time.deltaTime * 1.0f;
            return 0.5f + Mathf.Sin(time) * 0.5f;
        }
    }
}
