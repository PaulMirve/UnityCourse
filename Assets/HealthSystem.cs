using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class HealthSystem : MonoBehaviour
{
    //This line is for if I have to change the name of health variable, Unity IDE remembers the value that was saved.
    [FormerlySerializedAs("health")]
    public float health;
    private float currentHealth;
    public GameObject healthBarPrefab;
    HealthBar myHealthBar;
    public GameObject deathEffectPrefab;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = health;
        //Create our health panel ON canvas References.canvas
        GameObject healthBarObject = Instantiate(healthBarPrefab, References.canvas.transform);
        myHealthBar = healthBarObject.GetComponent<HealthBar>();
    }

    // Update is called once per frame
    void Update()
    {
        //Make our healthbar reflect our health
        myHealthBar.ShowHealthFraction(currentHealth / health);
        //Make our healthbar follow us
        myHealthBar.transform.position = Camera.main.WorldToScreenPoint(transform.position + Vector3.up * 2);
    }

    public void TakeDamage(float damageAmount)
    {
        currentHealth -= damageAmount;
        if (currentHealth <= 0)
        {
            if (deathEffectPrefab)
            {
                Instantiate(deathEffectPrefab, transform.position, transform.rotation);
            }
            Destroy(gameObject);
        }

    }

    private void OnDestroy()
    {
        //Don't create nothing in the OnDestroy event, is only for cleaning items
        if (myHealthBar)
            Destroy(myHealthBar.gameObject);
    }
}
