using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using System.IO;

public class Bird : MonoBehaviour {

    public Text text;
    public Text highPoint;
    public AudioSource clickToFly;
    public AudioSource hitSource;
    public AudioSource dieSource;
    public Canvas Canvas;
    public Canvas QuitCanvas;
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
            if (clickToFly.isPlaying)
            {
                clickToFly.Stop();
            }
            this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + 1, this.transform.position.z);
            clickToFly.Play();
            GetComponent<Rigidbody>().velocity = new Vector3(GetComponent<Rigidbody>().velocity.x, 0, 0);
        }
        if (this.transform.position.y <= -6)
        {
            /*pointManager();*/
            Canvas.enabled = true;
            Time.timeScale = 0;
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 0;
            QuitCanvas.enabled = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Pipe")
        {
            GetComponent<Collider>().isTrigger = true;
            StartCoroutine(BirdStop());

        }
    }

    IEnumerator BirdStop()
    {
        hitSource.Play();
        GetComponent<Rigidbody>().useGravity = false;
        GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
        yield return new WaitForSeconds(0.25f);
        GetComponent<Rigidbody>().useGravity = true;
        this.transform.Rotate(0, 0, 100 * Time.deltaTime);
        GetComponent<Rigidbody>().velocity = new Vector3(0, 8, 0);
        yield return new WaitForSeconds(0.5f);
        dieSource.Play();
        GetComponent<Rigidbody>().velocity = new Vector3(0, -2.5f, 0);
    }

    void pointManager()
    {
        int i = 0;
        int maxPoint = 0;
        int content = 0;
        if (File.Exists("HighPoint.txt") == false)
        {
            //不存在文件
            File.Create("HighPoint.txt");//创建该文件
            File.WriteAllText("HighPoint.txt", text.text.ToString());
            int.TryParse(text.text.ToString(), out maxPoint);
        }
        else
        {
            int.TryParse(File.ReadAllText("HighPoint.txt"), out content);
            int.TryParse(text.text.ToString(),out i);
            if (content <= i) 
            {
                maxPoint = i;
                File.WriteAllText("HighPoint.txt", maxPoint.ToString());
            }
            else
            {
                maxPoint = content;
                File.WriteAllText("HighPoint.txt", maxPoint.ToString());
            }
        }


        highPoint.text = maxPoint.ToString();
    }

    public void yesClick()
    {
        Application.Quit();
    }

    public void noClick()
    {
        Time.timeScale = 1;
        QuitCanvas.enabled = false;
    }
}
