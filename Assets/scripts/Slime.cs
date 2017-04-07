using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : MonoBehaviour {


    private Rigidbody2D rb2d;
    [SerializeField]
    private float speed;

	void Start () {
        rb2d = GetComponent<Rigidbody2D>();
	}
	

	void FixedUpdate () {
        rb2d.velocity = Vector2.left * speed;
        if (rb2d.position.x < -21)
        {
            Destroy(this.gameObject);
        }
    }

  
}
