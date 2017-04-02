using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]

public class Missile : MonoBehaviour {

    [SerializeField]
    private float speed;
    private Rigidbody2D rb2d;
    private Vector2 direction;

	// Use this for initialization
	void Start () {
        rb2d = GetComponent<Rigidbody2D>();
        direction = Vector2.down;
	}

    
    void FixedUpdate()
    {
        rb2d.velocity = direction * speed;
        if (rb2d.position.y < -6)
        {
            Destroy(this.gameObject);
        }
    }




}
