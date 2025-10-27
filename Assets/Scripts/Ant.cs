using System;
using UnityEngine;

public class Ant : Enemy
{

    [SerializeField] private Vector2 velocity;
    public Transform[] MovePoint;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        base.Intialize(20);
        DamageHit = 20;
        velocity = new Vector2(-1.0f, 0.0f);
    }

    public override void Behavior()
    {
        rb.MovePosition(rb.position + velocity * Time.deltaTime);
        if ( velocity.x < 0 && rb.position.x <= MovePoint[0].position.x )
        {
            Flip();
        }
        //move right และเกินขอบขวา
        if ( velocity.x > 0 && rb.position.x >= MovePoint[1].position.x )
        {
            Flip();
        }
    }
    
    //flip ant to the opposite direction
    public void Flip()
    {
        velocity.x *= -1; //change direction of movement
        //Flip the image
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    private void FixedUpdate()
    {
        Behavior();
    }

    // Update is called once per frame
    void Update()
    {

    }
}