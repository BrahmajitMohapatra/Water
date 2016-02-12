using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

    public float speed = 10;

    // Use this for initialization
    void Start () {
	
	}

    // Update is called once per frame
    void Update() {
        Vector3 targetPosition = new Vector3(Mathf.Clamp(transform.position.x + Input.GetAxis("Horizontal") * speed, -25, 25),
                                             Mathf.Clamp(transform.position.y + Input.GetAxis("Vertical") * speed, -10, 10),
                                             transform.position.z);

        transform.position = targetPosition;
    }
}
