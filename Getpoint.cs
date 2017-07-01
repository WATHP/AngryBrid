using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Getpoint : MonoBehaviour {

    public Text point;
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            int i = 0;
            int.TryParse(point.text, out i);
            i += 1;
            point.text = i.ToString();
        }
    }

}
