using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DumbAiMovement : MonoBehaviour {

    public float moveSpeed;

    private Rigidbody2D rb;

    public bool isWalking;

    public float walkTime;
    private float walkCounter;
    public float waitTime;
    private float waitCounter;

    private int walkDirection;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();

        waitCounter = waitTime;
        walkCounter = walkTime;
	}
	
	// Update is called once per frame
	void Update () {

        var screen = Camera.main.WorldToViewportPoint(transform.position);
        screen.x = Mathf.Clamp01(screen.x);
        screen.y = Mathf.Clamp01(screen.y);
        transform.position = Camera.main.ViewportToWorldPoint(screen);

		if(isWalking)
        {
            walkCounter -= Time.deltaTime;

            if (walkCounter < 0)
            {
                isWalking = false;
                waitCounter = waitTime;
            }

            switch(walkDirection)
            {
                case 0:
                    rb.velocity = new Vector2(0, moveSpeed);
                    break;

                case 1:
                    rb.velocity = new Vector2(moveSpeed, 0);
                    break;

                case 2:
                    rb.velocity = new Vector2(0, -moveSpeed);
                    break;

                case 3:
                    rb.velocity = new Vector2(-moveSpeed, 0);
                    break;
            }
        }
        else
        {
            waitCounter -= Time.deltaTime;

            if (waitCounter < 0)
            {
                ChooseDirection();
            }
        }
	}

    public void ChooseDirection()
    {
        walkDirection = Random.Range(0, 4);
        isWalking = true;
        walkCounter = walkTime;
    }
}
