using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionBehaviour : MonoBehaviour
{
    public float secondsToExist;
    private float secondsWeHaveBeenAlive;

    // Start is called before the first frame update
    void Start()
    {
        secondsWeHaveBeenAlive = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        secondsWeHaveBeenAlive += Time.fixedDeltaTime;

        float lifeFraction = secondsWeHaveBeenAlive / secondsToExist;
        Vector3 maxScale = Vector3.one * 5;
        transform.localScale = Vector3.Lerp(Vector3.zero, maxScale, lifeFraction);

        if (secondsWeHaveBeenAlive >= secondsToExist)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        HealthSystem theirHealthSystem = other.gameObject.GetComponent<HealthSystem>();
        if (theirHealthSystem)
        {
            theirHealthSystem.TakeDamage(10);
        }
    }
}
