using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public GameObject ExplosionPrefab;

    public float Speed;
    public float MaxLifetime = 30f;
    private void Start()
    {
        StartCoroutine(DestroyAfterLifetime(MaxLifetime));
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * Speed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            Player player = other.gameObject.GetComponent<Player>();
            player.OnHitByProjectile(this);
        }
        
        Instantiate(ExplosionPrefab, transform.position, transform.rotation);

        Destroy(gameObject);
    }

    private IEnumerator DestroyAfterLifetime(float maxLifetime)
    {
        yield return new WaitForSeconds(maxLifetime);
        Destroy(gameObject);
    }
}
