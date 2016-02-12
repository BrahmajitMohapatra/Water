using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour {

    private Transform m_BulletEmitter;
    private Transform m_WeaponPivot;
    private GameObject m_Bullet;

    public float m_RotateSpeed = 3;
    public float m_RotateMinAngle = -30;
    public float m_RotateMaxAngle = 30;
    public float m_MagSize = 30;

    public float m_ShootCooldown = 1;
    public float m_ShootCooldownRegen = 0.25f;
    public float m_MaxShootTime = 10;

    private float m_CurrentMag;
    private float m_CurrentShootCooldown;
    private float m_CurrentShootCooldownRegen;

    // Use this for initialization
    void Start () {
        m_Bullet = Resources.Load("WaterBullet") as GameObject;
        m_BulletEmitter = GameObject.Find("BulletEmitter").GetComponent<Transform>();
        m_WeaponPivot = GameObject.Find("WeaponPivot").GetComponent<Transform>();

        m_CurrentMag = m_MagSize;
        m_CurrentShootCooldown = m_ShootCooldown;
        m_CurrentShootCooldownRegen = m_ShootCooldownRegen;
    }

    float z;

    // Update is called once per frame
    void Update () {
	    if(Input.GetButton("Fire1")) {
            if(/*m_CurrentMag > 0 &&*/ m_CurrentShootCooldown > 0) {
                Bullet bullet;
                GameObject go = GameObject.Instantiate(m_Bullet, m_BulletEmitter.position, m_BulletEmitter.rotation) as GameObject;
                bullet = go.GetComponent<Bullet>();

                m_CurrentMag = Mathf.Clamp(m_CurrentMag - bullet.m_Value, 0, m_MagSize);

                m_CurrentShootCooldown = Mathf.Clamp(m_CurrentShootCooldown - m_ShootCooldown * Time.deltaTime, 0, m_MaxShootTime);
            }
        }

        m_CurrentShootCooldown = Mathf.Clamp(m_CurrentShootCooldown + m_ShootCooldownRegen * Time.deltaTime, 0, m_MaxShootTime);

        if(Input.GetAxis("VerticalLook") != 0) {
            z = m_WeaponPivot.eulerAngles.z + Input.GetAxis("VerticalLook") * m_RotateSpeed;
            z = Mathf.Clamp(z, m_RotateMinAngle, m_RotateMaxAngle);

            m_WeaponPivot.rotation = Quaternion.Euler(m_WeaponPivot.eulerAngles.x,
                                                    m_WeaponPivot.eulerAngles.y,
                                                    z);
        }
	}
}
