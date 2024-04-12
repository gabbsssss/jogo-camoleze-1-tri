using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Player : MonoBehaviour
{
    SpriteRenderer sr;
    Animator anim;
    Rigidbody2D rig;
    [Range (-1, 8)]public int Speed = 5;
    bool chao, puloDuplo;
    public int Jump = 4;
    public Transform respawn;

    public string hannah;

    // Start is called before the first frame update
    void Start()
    {
        rig=GetComponent<Rigidbody2D>();
        anim=GetComponent<Animator>();
        sr=GetComponent<SpriteRenderer>();
        transform.position = respawn.position;
        gameObject.name = hannah;
    }

    // Update is called once per frame
    void Update()
    {
        mover();
        pular();
    }

   void mover ()
    {
        rig.velocity=new Vector2(Input.GetAxis("Horizontal") * Speed, rig.velocity.y);
        if (Input.GetAxis("Horizontal") != 0 )
        {
            anim.SetBool("Esta andando", true); 
        }
        if (Input.GetAxis("Horizontal") == 0)
        {
            anim.SetBool("Esta andando", false);
        }
        if (Input.GetAxis("Horizontal") > 0)
        {
            sr.flipX = true;
        }
        if (Input.GetAxis("Horizontal") < 0)
        {
            sr.flipX = false;
        }
    }

    void pular()
    {
        if (Input.GetButtonDown("Jump"))
        {
            if (chao)
            {
                rig.AddForce(Vector2.up * Jump, ForceMode2D.Impulse);
                chao = false;
                puloDuplo = true;
            }
            else if(puloDuplo)
            {
                rig.AddForce(Vector2.up * Jump, ForceMode2D.Impulse);
                chao = false;
                puloDuplo = false;
            }
        }
    }

     void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Plataforma"))
        {
            chao = true;
            puloDuplo = false;
        }

        if (collision.gameObject.CompareTag("morteKK"))
        {
            transform.position = respawn.position;
            Debug.Log("vc morreuKKKKKKK");

        }


    }

}
