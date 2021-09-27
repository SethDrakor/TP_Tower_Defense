using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public float speed;
    public Transform[] waypoints;
    public SpriteRenderer sprite;

    private Transform target;
    private int destPoint;

    void Start()
    {
        target = waypoints[0];
    }

    void Update()
    {
        float step = speed * Time.deltaTime;
        var t2 = new Vector2(target.position.x, transform.position.y);
        transform.position = Vector2.MoveTowards(transform.position, t2, step);

        if(Vector3.Distance(transform.position, t2) < 0.3f)
        {
            destPoint = (destPoint + 1) % waypoints.Length;
            target = waypoints[destPoint];
            sprite.flipX = !sprite.flipX;
        }
    }
}
