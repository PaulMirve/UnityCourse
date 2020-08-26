using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public float speed;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Rigidbody ourRigidBody = GetComponent<Rigidbody>();
        if (References.thePlayer)
        {
            Vector3 vectorToPlayer = References.thePlayer.transform.position - transform.position;
            ourRigidBody.velocity = vectorToPlayer.normalized * speed;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject collisionGameObject = collision.gameObject;
        if (collisionGameObject.GetComponent<PlayerBehaviour>())
        {
            //Do damage to the enemy
            HealthSystem theirHealthSystem = collisionGameObject.GetComponent<HealthSystem>();
            if (theirHealthSystem)
                theirHealthSystem.TakeDamage(1);
        }
    }
}
