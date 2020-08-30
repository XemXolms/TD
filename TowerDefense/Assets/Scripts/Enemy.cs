using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 100;
    public int value = 50;
    public float speed = 10f;
    public GameObject deathEffect;

    private Transform target;
    private int waypointIndex = 0;

    void Start ()
    {
        target = Waypoints.points[0];
    }

    void Update ()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) <= 0.4f)
        {
            GetNextWaypoint();
        }

        void GetNextWaypoint()
        {
            if ( waypointIndex >= Waypoints.points.Length - 1 ) 
            {
                EndPath();
                return;
            }

            waypointIndex++;
            target = Waypoints.points[waypointIndex];
        }
    }

    public void TakeDamage(int amount)
    {
        health -= amount;

        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        PlayerStats.Money += value;

        GameObject effect = (GameObject)Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(effect, 5f);

        Destroy(gameObject);
    }

    void EndPath()
    {
        PlayerStats.Lives--;
        Destroy(gameObject);
    }
}