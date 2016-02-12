using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

    public GameObject target;
    public float speed = 5;
    public float edgeAngle = 10;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 targetPosition = new Vector3(Mathf.Clamp(target.transform.position.x, -20, 20),
                                             Mathf.Clamp(target.transform.position.y, -10, 10),
                                             transform.position.z);

        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * speed);

        if(transform.position.x >= 19) {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, edgeAngle, 0) , Time.deltaTime * speed);
            //transform.eulerAngles = Vector3.Lerp(transform.eulerAngles, new Vector3(0, edgeAngle, 0), Time.deltaTime * speed);
        } else if(transform.position.x <= -19) {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, -edgeAngle, 0), Time.deltaTime * speed);
            //transform.eulerAngles = Vector3.Lerp(transform.eulerAngles, new Vector3(0, -edgeAngle, 0), Time.deltaTime * speed);
        } else {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, 0), Time.deltaTime * speed);
            //transform.eulerAngles = Vector3.Lerp(transform.eulerAngles, Vector3.zero, Time.deltaTime * speed);
        }
	}
}
