using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class platform : MonoBehaviour
{
    public float jumpforce = 8f;
    public bool isCloud = false;
    public Text scoreText;

    private bool isMoving = false;
    public float speed = 0.05f;
    private Vector3 posTarget;
    private float widht = 2.5f;


    void Start() {
        this.isMoving =  Random.Range(1 ,11) % 5 == 0;
        Vector3 posObject = transform.position;
        this.posTarget = transform.position;
        if(Random.Range(1 ,11) % 2 == 0){
            this.widht = -widht;
        }
        this.posTarget.x = this.widht;
    }

    void FixedUpdate() {
        if(this.isMoving){
            if(transform.position == this.posTarget){
                this.posTarget.x = -1* this.posTarget.x;
            }  
            Vector3 posObject = transform.position;
            transform.position = Vector3.MoveTowards(posObject,this.posTarget,this.speed);
        }  
    }
    void OnCollisionEnter2D(Collision2D collision){

        if(collision.relativeVelocity.y <= 0f){
            Rigidbody2D rb = collision.collider.GetComponent<Rigidbody2D>();
            Player playerObject = collision.collider.GetComponent<Player>();
            if(rb != null){
                Vector2 velocity = rb.velocity;
                velocity.y = jumpforce;
                rb.velocity = velocity;

                FindObjectOfType<AudioManager>().Play("Jump");
                
                Debug.Log(GetInstanceID());
                if(!playerObject.platformHaveBeenCollision.Contains(GetInstanceID())){
                    playerObject.platformHaveBeenCollision.Add(GetInstanceID());
                    playerObject.score = playerObject.score + 1;
                    scoreText.text = playerObject.score.ToString();
                }

                if(this.isCloud){
                    gameObject.SetActive(false);
                }
               

            }
        }
        
    }
}
