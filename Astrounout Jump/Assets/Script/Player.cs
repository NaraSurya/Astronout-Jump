using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{   
    public float movementSpeed = 5f;
    Rigidbody2D rb;
    float movement = 0f;

    public int score = 0;
    public List<int> platformHaveBeenCollision = new List<int>();
    // Start is called before the first frame update
    void Start()
    {
       rb = GetComponent<Rigidbody2D>(); 
    }

    // Update is called once per frame
    void Update()
    {
        movement = Input.acceleration.x * movementSpeed;
        Vector3 stageDimensions = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0));
        if(stageDimensions.y > GetComponent<Transform>().position.y){
            gameObject.SetActive(false);
            FindObjectOfType<GameManager>().EndGame(score);
        }
    }

    void FixedUpdate(){
        Vector2 velocity = rb.velocity;
        velocity.x = movement;
        rb.velocity = velocity;
    }
}
