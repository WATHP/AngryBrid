using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour {

    public float timer = 0;
    public int frameNumber = 10;    //frame number one seconds
    public int frameCount = 0;      //frame counter
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        if (timer >= 1.0f / frameNumber)    //每过10分之一秒
        {
            frameCount++;
            timer -= 1.0f / frameNumber;
            int frameIndex = frameCount % 3;
            //update material's offset
            //how to set the property of (x offset) 
            //MainTex:着色器中主要的漫反射纹理
            GetComponent<Renderer>().material.SetTextureOffset("_MainTex", new Vector2(0.3333f*frameIndex, 0));
        }
	}
}
