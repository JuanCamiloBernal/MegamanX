using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Staticenemy : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject Bullet_SE;
    [SerializeField] GameObject point;
    [SerializeField] float Fire_rate;
    Animator MyAnim;
    float nextfire = 0.0f;



    // Start is called before the first frame update
    void Start()
    {
        MyAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        ShootPlayer();
        
    }
    void ShootPlayer()
    {
       
        Collider2D col = Physics2D.OverlapCircle(transform.position, 8f, LayerMask.GetMask("Player"));
        if (col != null)
        {
            if (Time.time > nextfire)
            {
                nextfire = Time.time + Fire_rate;
                Instantiate(Bullet_SE, point.transform.position, transform.rotation);
            }
        }            
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, 8f);
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "B")
        {
            Object.Destroy(gameObject, 0.0f);
        }
    }
}

