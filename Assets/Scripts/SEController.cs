using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SEController : MonoBehaviour
{

    public void genSE()
    {
        // サウンドを鳴らす
        GetComponent<AudioSource>().Play();
    }

    public void genSE2()
    {
        // サウンドを鳴らす
        GetComponent<AudioSource>().pitch = Random.Range(2.2f, 1.8f);
        GetComponent<AudioSource>().Play();
        
    }    

    public void genSE3()
    {
        // サウンドを鳴らす
        GetComponent<AudioSource>().pitch = Random.Range(1.05f, 0.95f);
        GetComponent<AudioSource>().Play();
        
    }    

    public void stopSE()
    {
        // サウンドを止める
        GetComponent<AudioSource>().Stop();
    }

}
