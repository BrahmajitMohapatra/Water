using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

    public float m_Force = 100;
    public float m_LifeTime = 5;
    public float m_Value = 0.1f;
    private Rigidbody m_Rigidbody;

	// Use this for initialization
	void Start () {
        m_Rigidbody = GetComponent<Rigidbody>();
        m_Rigidbody.AddForce(transform.right * m_Force);

        Destroy(gameObject, m_LifeTime);
	}
	
	// Update is called once per frame
	void Update () {
	    
	}
}
