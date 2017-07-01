using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour {

    public Canvas Canvas;
    public GameObject _camera;
    public float timer = 0;
    public int frameNumber = 10;    //frame number one seconds
    public int frameCount = 0;      //frame counter
	// Use this for initialization
	void Start () {
        GetComponent<Rigidbody>().velocity = new Vector3(4, 0, 0);

    }
	
	// Update is called once per frame
	void Update () {
        _camera.transform.position = new Vector3(this.transform.position.x + 5, _camera.transform.position.y, _camera.transform.position.z);
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

        if (Input.GetMouseButtonDown(0))
        {
            this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + 1, this.transform.position.z);
            GetComponent<Rigidbody>().velocity = new Vector3(GetComponent<Rigidbody>().velocity.x, 0, 0);
        }
	}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Pipe")
        {
            Canvas.enabled = true;
        }
    }

}
