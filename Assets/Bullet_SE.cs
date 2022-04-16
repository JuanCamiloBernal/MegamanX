using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_SE : MonoBehaviour
{
    [SerializeField] float speed;
    Animator MyAnim;
    // Start is called before the first frame update
    void Start()
    {
        MyAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //MyAnim.SetBool("Destroy", true);
            Object.Destroy(gameObject, 0.0f);
        }
        if (collision.gameObject.CompareTag("B"))
        {
            //MyAnim.SetBool("Destroy", true);
            Object.Destroy(gameObject, 0.0f);
        }
    }
}
