using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossControl : MonoBehaviour
{

    GameObject scoreUITextGO;
    public GameObject pivot;
    public GameObject ExplosionGO;
    public GameObject GameManagerGO;
    float speed;

    int life;

    // Start is called before the first frame update
    void Start()
    {

        speed = 2f;

        scoreUITextGO = GameObject.FindGameObjectWithTag("ScoreTextTag");

        life = 70;
    }

    // Update is called once per frame
    void Update()
    {
        if (scoreUITextGO.GetComponent<GameScore>().Score > 10000)
        {
            Vector2 position = transform.position;

            Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0)); //bottom left
            Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1)); //top right


            max.x = max.x - 0.5f;
            min.x = min.x + 0.5f;


            if (transform.position.y > pivot.transform.position.y)
            {
                position = new Vector2(position.x, position.y - speed * Time.deltaTime);

                transform.position = position;
            }
            
        }




    }






    void OnTriggerEnter2D(Collider2D col)
    {
        if ((col.tag == "PlayerShipTag") || (col.tag == "PlayerBulletTag"))
        {
            PlayExplosion();

            life--;
        }

        if (life == 0)
        {
            Destroy(gameObject);

            scoreUITextGO.GetComponent<GameScore>().Score += 10000;

            GameManagerGO.GetComponent<GameManager>().SetGameManagerState(GameManager.GameManagerState.GameOver);
        }
    }

    void PlayExplosion()
    {
        GameObject explosion = (GameObject)Instantiate(ExplosionGO);

        explosion.transform.position = transform.position;
    }
}
