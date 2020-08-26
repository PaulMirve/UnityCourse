using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    public float bulletSpeed;
    public float secondUntilDestroy;
    public float damage;
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody ourRigidBody = GetComponent<Rigidbody>();
        ourRigidBody.velocity = transform.forward * bulletSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        secondUntilDestroy -= Time.deltaTime;

        if (secondUntilDestroy < 1)
            transform.localScale *= secondUntilDestroy;

        if (secondUntilDestroy < 0)
            Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject collisionGameObject = collision.gameObject;
        if (collisionGameObject.GetComponent<EnemyBehaviour>())
        {
            //Do damage to the enemy
            HealthSystem theirHealthSystem = collisionGameObject.GetComponent<HealthSystem>();
            if (theirHealthSystem)
                theirHealthSystem.TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
