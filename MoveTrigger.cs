using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTrigger : MonoBehaviour {

    public Transform currentBg;

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            //move the bg to the front of first transform
            //1.get the first transform
            Transform firstBg = GameManager.instance.firstBg;
            //2.move
            currentBg.transform.position = new Vector3(firstBg.position.x + 9, currentBg.transform.position.y, currentBg.transform.position.z);

            GameManager.instance.firstBg = currentBg;
        }
    }

}
