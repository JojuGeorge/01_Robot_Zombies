using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EnemyHealthManager : MonoBehaviour {

    public int enemyHealth;

    public GameObject deathParticle;
  //  ZombiePatrol zombieEnemy;

    Rigidbody2D thisRigidbody;

    public Slider enemyHealthSlider;

	// Use this for initialization
	void Start () {
        
      //  zombieEnemy = FindObjectOfType<ZombiePatrol>();
        thisRigidbody = GetComponent<Rigidbody2D>();

        //enemyHealthSlider = GetComponent<Slider>();
        enemyHealthSlider.maxValue = enemyHealth;
	}
	
	// Update is called once per frame
	void Update () {

        enemyHealthSlider.value = enemyHealth;
     
        // if health of enemy is 0 then kill enemy
        if (enemyHealth <= 0)
        {

            Instantiate(deathParticle, transform.position, transform.rotation);
          //  Destroy(zombieEnemy);
            Destroy(gameObject);
        }
	}   // END of UPdate();

    void FixedUpdate() {
        
        // so that if the enemy flips the slider flips too so as tol look consistent
        if (thisRigidbody.transform.localScale.x < 0)
        {
            enemyHealthSlider.direction = Slider.Direction.RightToLeft;
        }
        else enemyHealthSlider.direction = Slider.Direction.LeftToRight;
 
    }

    public void DamageEnemy(int damageValue) {
        // by default we unchecked the enemy health slider so it is not seen until the enemy is hit for the first time.
        // we are turning back or checking the enemy health slider back on 
         enemyHealthSlider.gameObject.SetActive(true);
         enemyHealth -= damageValue;
         gameObject.GetComponent<AudioSource>().Play();
    }
}
