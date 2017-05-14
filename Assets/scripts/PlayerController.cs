using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {


    [SerializeField]
    private float speed;
    private Rigidbody2D rb2d;
    [SerializeField]
    private Stat health;

    public Stat Health
    {
        get
        {
            return health;
        }

        set
        {
            health = value;
        }
    }

    private void Awake()
    {
        Health.Initialize();
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

    }

    void OnTriggerEnter2D(Collider2D other)
    {    
        if (other.tag.Equals("SlimeProjectile") || other.tag.Equals("Missile"))
        {
            GotDamage(10); 
            Destroy(other.gameObject);
        }
    }

    public void GotDamage(int damage)
    {
        Health.CurrentVal -= damage;
    }




}
