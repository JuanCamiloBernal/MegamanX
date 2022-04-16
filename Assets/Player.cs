using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D myBody;
    Animator MyAnim;
    AudioSource Mysound;
    [SerializeField] GameObject Bullet;
    [SerializeField] GameObject point;
    [SerializeField] AudioClip S_shoot;
    [SerializeField] AudioClip S_death;
    [SerializeField] float Speed;
    [SerializeField] float Jumpforce;
    bool isGrounded = false;
    [SerializeField] float Fire_rate;
    float nextfire = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        myBody = GetComponent<Rigidbody2D>();
        MyAnim = GetComponent<Animator>();
        Mysound = GetComponent<AudioSource>();
        StartCoroutine(ShowTime());
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D ray = Physics2D.Raycast(transform.position, Vector2.down,1.2f,LayerMask.GetMask("Ground"));
        
        //Debug.DrawRay(transform.position, Vector2.down * 1.2f, Color.red);
        isGrounded = ray.collider != null;
        Jump();
        Fire();
       
    }
    //Corutina
    IEnumerator ShowTime()
    {
        while(true)
        {
            yield return new WaitForSeconds(1);
            Debug.Log(Time.time);
        }
    }
    void Fire()
    {
        //if (Input.GetKey(KeyCode.Z)&& Time.time > nextfire)
        //{
        //    MyAnim.SetLayerWeight(1, 1);

        //    nextfire = Time.time + Fire_rate;
        //    Instantiate(Bullet, point.transform.position, transform.rotation);
        //    Mysound.PlayOneShot(S_shoot, 0.7f);


        //}
        //else
        //{
        //    MyAnim.SetLayerWeight(1, 0);
        //}
        if (Input.GetKey(KeyCode.Z))
        {
            MyAnim.SetLayerWeight(1, 1);
            if (Time.time > nextfire)
            {
                nextfire = Time.time + Fire_rate;
                Instantiate(Bullet, point.transform.position, transform.rotation);
                Mysound.PlayOneShot(S_shoot, 0.7f);
            }

        }
        else
        {
            MyAnim.SetLayerWeight(1, 0);
        }
    }
    void Jump()
    {
        if (isGrounded && !MyAnim.GetBool("isJumping"))
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                myBody.AddForce(Vector2.up * Jumpforce, ForceMode2D.Impulse);
                MyAnim.SetBool("isJumping", true);
            }
         
        }
        if (myBody.velocity.y != 0 && !isGrounded)
            MyAnim.SetBool("isJumping", true);
        else
            MyAnim.SetBool("isJumping", false);



    }
    void OnCollisionEnter2D(Collision2D collision)
        {
        if (collision.gameObject.tag == "F_enemy")
        {
            MyAnim.SetBool("Death", true);
            Mysound.PlayOneShot(S_death, 0.7f);
          
             //Object.Destroy(gameObject, 0.0f);
            }if (collision.gameObject.tag == "S_enemy")
        {
            MyAnim.SetBool("Death", true);
            Mysound.PlayOneShot(S_death, 0.7f);
          
             //Object.Destroy(gameObject, 0.0f);
            }
        if (collision.gameObject.tag == "B_enemy")
        {
            Mysound.PlayOneShot(S_death, 0.7f);
            MyAnim.SetBool("Death", true);
            
            //Object.Destroy(gameObject, 0.0f);
        }
    }
    
    private void FixedUpdate()
    {
        float DirH = Input.GetAxis("Horizontal");
        if (DirH!=0)
        {
            MyAnim.SetBool("isRunning", true);
            if (DirH<0)
            {
                transform.localScale = new Vector2(-1, 1);
            }
            else
            {
                transform.localScale = new Vector2(1, 1);
            }
        }
        else
        {
            MyAnim.SetBool("isRunning", false);
        }
        myBody.velocity = new Vector2(DirH * Speed, myBody.velocity.y);
       
    }
}
