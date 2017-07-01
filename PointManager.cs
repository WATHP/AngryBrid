using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointManager : MonoBehaviour {

    public Text text;


    void Update () {
        this.GetComponent<Text>().text = text.text.ToString();
	}
	

}
