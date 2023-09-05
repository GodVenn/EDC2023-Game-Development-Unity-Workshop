using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float Speed = 10f;
    public float MaxLifetime = 30f;

    private void Start()
    {
        StartCoroutine(DestroyAfterLifetime());
    }

    void Update()
    {
        // Fly forward with constant speed
        transform.position += transform.forward * Speed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Player player = collision.gameObject.GetComponent<Player>();
            player.OnHitByProjectile(this);
        }
        
        Debug.Log("Hit something");
        Destroy(gameObject);
    }

    private IEnumerator DestroyAfterLifetime()
    {
        yield return new WaitForSeconds(MaxLifetime);
        Destroy(gameObject);
    }
}
