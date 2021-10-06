using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{

    GameObject scoreUITextGO;

    float speed;
    public GameObject ExplosionGO;
    public GameObject LifeGO;
    public GameObject PowerGO;
    public GameObject SpeedGO;


    float rand;

    // Start is called before the first frame update
    void Start()
    {
        speed = 2f;

        scoreUITextGO = GameObject.FindGameObjectWithTag("ScoreTextTag");

        rand = Random.Range(0, 100);
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 position = transform.position;

        position = new Vector2(position.x, position.y - speed * Time.deltaTime);

        transform.position = position;

        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

        if (transform.position.y < min.y)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if ((col.tag == "PlayerShipTag")||(col.tag == "PlayerBulletTag") || (col.tag == "BossTag"))
	{
            PlayExplosion();

            scoreUITextGO.GetComponent<GameScore>().Score += 100;

            
            if(rand > 70 & rand < 90)

    {
                GameObject speed = (GameObject)Instantiate(SpeedGO);
                speed.transform.position = transform.position;
            }

            if(rand > 95 & rand < 100)

    {
                GameObject life = (GameObject)Instantiate(LifeGO);
                life.transform.position = transform.position;
            }

            if(rand > 85 & rand < 95)

    {
                GameObject power = (GameObject)Instantiate(PowerGO);
                power.transform.position = transform.position;
            }



            Destroy(gameObject);
        }
    }

    void PlayExplosion()
    {
        GameObject explosion = (GameObject)Instantiate(ExplosionGO);

        explosion.transform.position = transform.position;
    }

}
