using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public float speed;
    public float lineOfSite;
    public float shootingRange;
    public float fireRate = 1f;
    private float nextFireTime;
    public GameObject bullet;
    public GameObject bulletParent;
    private Transform monster;

    void Start()
    {
        monster = GameObject.FindGameObjectWithTag("Monster").transform;

    }


    void Update()
    {
        float distanceFromMonster = Vector2.Distance(monster.position, transform.position);
        if(distanceFromMonster < lineOfSite && distanceFromMonster > shootingRange)
        {
            transform.position = Vector2.MoveTowards(this.transform.position,monster.position,speed*Time.deltaTime);
        }
        else if(distanceFromMonster <= shootingRange && nextFireTime < Time.time)
        {
            Instantiate(bullet, bulletParent.transform.position, Quaternion.identity);
            nextFireTime = Time.time + fireRate;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lineOfSite);
        Gizmos.DrawWireSphere(transform.position, shootingRange);
    }
}
