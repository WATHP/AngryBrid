using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Getpoint : MonoBehaviour {

    public AudioSource getPoint;
    public Text point;
    public GameObject bird;
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (bird.GetComponent<Collider>().isTrigger!=true)
            {
                getPoint.Play();
                int i = 0;
                int.TryParse(point.text, out i);
                i += 1;
                point.text = i.ToString();
            }
        }
    }

}
