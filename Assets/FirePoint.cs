using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class FirePoint : MonoBehaviour
{

    public GameObject bullet1;
    public Rigidbody2D player1;
    public float fireRate = 0.5f;
    public float lastShot = 0f;
    public bool canShoot = false;
    public Rigidbody2D shooter;
    public float bulletSpeed = 100f;
    public Transform firePoint;

   
    public GameObject playership;
    
    void Awake()
    {

        player1 = GetComponent<Rigidbody2D>();

    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        DoFire();
    }

    public void DoFire()
    {

        if (Time.time > fireRate + lastShot && Input.GetButtonDown("Fire1"))
        {
            GameObject clone = Instantiate(bullet1, firePoint.transform.position, firePoint.transform.rotation * Quaternion.Euler(0, 0, 90f));
            // Physics2D.IgnoreCollision(clone.GetComponent<Collider2D>(), playership.GetComponent<Collider2D>());
            shooter = clone.GetComponent<Rigidbody2D>();
            shooter.AddForce(new Vector2(1 * Mathf.Sin(player1.rotation), 1 * -Mathf.Cos(player1.rotation)) * bulletSpeed, ForceMode2D.Impulse);
            Debug.Log(player1.rotation);
            Destroy(clone.gameObject, 1f);
            lastShot = Time.time;
        }

    }
}

