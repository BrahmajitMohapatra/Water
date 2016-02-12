using UnityEngine;
using System.Collections;

public class Teleport : MonoBehaviour {

    public Teleport target;
    public bool busy = false;

    void OnTriggerEnter(Collider other) {
        if(other.name == "Player" && !busy) {
            target.busy = true;
            other.transform.position = target.transform.position;
        }
    }

    void OnTriggerExit(Collider other) {
        if(other.name == "Player") {
            busy = false;
        }
    }
}
