 using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl: MonoBehaviour
{
    public float speed;

    public GameObject GameManagerGO;
    public GameObject PlayerBulletGO;
    public GameObject BulletPosition1;
    public GameObject BulletPosition2;
    public GameObject BulletPosition;
    public GameObject BulletPosition3;
    public GameObject BulletPosition4;
    
    public GameObject ExplosionGO;

    int ammo;

    public Text LiveUIText;

    const int MaxLives = 3;
    int lives;

    public void Init()
    {
        lives = MaxLives;

        LiveUIText.text = lives.ToString();

        transform.position = new Vector2(0, 0);

        gameObject.SetActive(true);
    }

    // Start is called before the first frame update
    void Start()
    {
        ammo = 1;
    }

    // Update is called once per frame
    void Update()
    {

        if(Input.GetKeyDown("space"))
        {
            GetComponent<AudioSource>().Play();

            if (ammo == 1)
            {
                GameObject bullet01 = (GameObject)Instantiate(PlayerBulletGO);
                bullet01.transform.position = BulletPosition.transform.position;
            }

            if (ammo == 2)
            {
                GameObject bullet01 = (GameObject)Instantiate(PlayerBulletGO);
                bullet01.transform.position = BulletPosition1.transform.position;

                GameObject bullet02 = (GameObject)Instantiate(PlayerBulletGO);
                bullet02.transform.position = BulletPosition2.transform.position;
            }

            if (ammo == 3)
            {
                GameObject bullet01 = (GameObject)Instantiate(PlayerBulletGO);
                bullet01.transform.position = BulletPosition.transform.position;

                GameObject bullet02 = (GameObject)Instantiate(PlayerBulletGO);
                bullet02.transform.position = BulletPosition3.transform.position;

                GameObject bullet03 = (GameObject)Instantiate(PlayerBulletGO);
                bullet03.transform.position = BulletPosition4.transform.position;
            }

            if (ammo == 4)
            {
                GameObject bullet01 = (GameObject)Instantiate(PlayerBulletGO);
                bullet01.transform.position = BulletPosition1.transform.position;

                GameObject bullet02 = (GameObject)Instantiate(PlayerBulletGO);
                bullet02.transform.position = BulletPosition3.transform.position;

                GameObject bullet03 = (GameObject)Instantiate(PlayerBulletGO);
                bullet03.transform.position = BulletPosition2.transform.position;

                GameObject bullet04 = (GameObject)Instantiate(PlayerBulletGO);
                bullet04.transform.position = BulletPosition4.transform.position;
            }

            if (ammo >= 5)
            {
                GameObject bullet01 = (GameObject)Instantiate(PlayerBulletGO);
                bullet01.transform.position = BulletPosition1.transform.position;

                GameObject bullet02 = (GameObject)Instantiate(PlayerBulletGO);
                bullet02.transform.position = BulletPosition3.transform.position;

                GameObject bullet03 = (GameObject)Instantiate(PlayerBulletGO);
                bullet03.transform.position = BulletPosition2.transform.position;

                GameObject bullet04 = (GameObject)Instantiate(PlayerBulletGO);
                bullet04.transform.position = BulletPosition4.transform.position;

                GameObject bullet05 = (GameObject)Instantiate(PlayerBulletGO);
                bullet05.transform.position = BulletPosition.transform.position;
            }
        }

        float x = Input.GetAxisRaw ("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        Vector2 direction = new Vector2(x, y).normalized;

        Move(direction);
    }

    void Move(Vector2 direction)
    {
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0)); //bottom left
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1)); //top right


        max.x = max.x - 0.15f;
        min.x = min.x + 0.15f;

        max.y = max.y - 0.15f;
        min.y = min.y + 0.15f;

        Vector2 pos = transform.position;

        pos += direction * speed * Time.deltaTime;

        pos.x = Mathf.Clamp(pos.x, min.x, max.x);
        pos.y = Mathf.Clamp(pos.y, min.y, max.y);

        transform.position = pos;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if ((col.tag == "EnemyShipTag")||(col.tag == "EnemyBulletTag"))
	    {
            PlayExplosion();

            lives--;
            LiveUIText.text = lives.ToString();

            if (lives == 0)
            {
                GameManagerGO.GetComponent<GameManager>().SetGameManagerState(GameManager.GameManagerState.GameOver);

                gameObject.SetActive(false);
            }
        }
        
        if (col.tag == "LifeTag")
        {
            lives++;
            LiveUIText.text = lives.ToString();
        }

        if (col.tag == "SpeedTag")
        {
            speed += 0.4f;
        }

        if (col.tag == "PowerTag")
        {
            ammo++;

        }
    }

    void PlayExplosion()
    {
        GameObject explosion = (GameObject)Instantiate(ExplosionGO);

        explosion.transform.position = transform.position;
    }

}
