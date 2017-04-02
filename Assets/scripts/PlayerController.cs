using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {


    [SerializeField]
    private float speed;
    private Rigidbody2D rb2d;
    [SerializeField]
    private Stat health;


    private void Awake()
    {
        health.Initialize();
    }
	void Start () {
        rb2d = GetComponent<Rigidbody2D>();
		
	}


	
    private void HandleMovement(float horizontal, float vertical)

    {
        rb2d.velocity = new Vector2(horizontal * speed, vertical * speed);
    }

	void Update () {
        

        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");
        HandleMovement(horizontal,vertical);

        if (Input.GetKeyDown(KeyCode.Q))
        {
            health.CurrentVal -= 10;
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            health.CurrentVal += 10;
        }


    }



}
