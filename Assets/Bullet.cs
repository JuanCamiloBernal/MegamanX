using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Animator MyAnim;
    [SerializeField] float speed;
    float direction;
    // Start is called before the first frame update
    void Start()
    {
        MyAnim = GetComponent<Animator>();
        GameObject player = GameObject.Find("Megaman");
        Transform playerTransform = player.transform;
        direction = playerTransform.localScale.x;
    }

    // Update is called once per frame
    void Update()
    {
        //transform.Translate(Vector2.right * speed * Time.deltaTime);
        transform.Translate(new Vector3(direction * speed * Time.deltaTime, 0, 0));
    }
    void OnCollisionEnter2D(Collision2D Other)
    {
        MyAnim.SetBool("Destroy", true);
        Object.Destroy(gameObject, 0.0f);
        //if (collision.gameObject.CompareTag("F_enemy"))
        //{
        //    MyAnim.SetBool("Destroy", true);
        //    Object.Destroy(gameObject, 0.0f);
        //}
        //if (collision.gameObject.CompareTag("S_enemy"))
        //{
        //    MyAnim.SetBool("Destroy", true);
        //    Object.Destroy(gameObject, 0.0f);
        //}
        //if (collision.gameObject.CompareTag("B_enemy"))
        //{
        //    MyAnim.SetBool("Destroy", true);
        //    Object.Destroy(gameObject, 0.0f);
        //}
        //if (collision.gameObject.CompareTag("Ground"))
        //{
        //    MyAnim.SetBool("Destroy", true);
        //    Object.Destroy(gameObject, 0.0f);
        //}
    }
}

