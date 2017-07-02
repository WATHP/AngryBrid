using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class PointManager : MonoBehaviour {

    public Text text;

    void Update () {
        GetComponent<Text>().text = text.text.ToString();
	}
}
