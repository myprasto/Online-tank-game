using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaserAiMovement : MonoBehaviour {

    public float speed;

    public float enemyDistance;

    private Transform target;

	// Use this for initialization
	void Start () {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {

        var screen = Camera.main.WorldToViewportPoint(transform.position);
        screen.x = Mathf.Clamp01(screen.x);
        screen.y = Mathf.Clamp01(screen.y);
        transform.position = Camera.main.ViewportToWorldPoint(screen);

        if (Vector2.Distance(transform.position,target.position) > enemyDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
	}
}
