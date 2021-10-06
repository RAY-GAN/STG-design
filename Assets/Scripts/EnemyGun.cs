using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGun : MonoBehaviour
{

    public GameObject EnemyBulletGO;

    // Start is called before the first frame update
    void Start()
    {

        if(this.tag == "Enemygun")
        {
            Invoke("FireEnemyBullet", 1f);
        }
        else
        {
            InvokeRepeating("FireEnemyBullet", 1f, 2f);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FireEnemyBullet()
    {

        GameObject playerShip = GameObject.Find("PlayerGO");

        if (playerShip != null)
        {
            GameObject bullet = (GameObject)Instantiate(EnemyBulletGO);

            bullet.transform.position = transform.position;

            Vector2 direction = playerShip.transform.position - bullet.transform.position;

            bullet.GetComponent<EnemyBullet>().SetDirection(direction);

        }
    }
}
