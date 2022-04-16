using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
public class FlyingEnemy : MonoBehaviour
{
    [SerializeField] GameObject player;
    AIPath mypath;

    // Start is called before the first frame update
    void Start()
    {
        mypath = GetComponent<AIPath>();
        
    }

    // Update is called once per frame
    void Update()
    {
        ChasePlayer();
    }

    void ChasePlayer()
    {
        //opcion 1  con vector 2
        //float distancia = Vector2.Distance(transform.position, player.transform.position);
        //Debug.Log("Distancia con megaman: " + distancia);
        //if(distancia<8)
        //{

        //}
        //Opcion 2 con ovelapcircle
        Collider2D col = Physics2D.OverlapCircle(transform.position, 8f, LayerMask.GetMask("Player"));
        if (col != null)
            mypath.isStopped = false;
        else
            mypath.isStopped = true;
    }
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
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
