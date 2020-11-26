using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class asteroids : MonoBehaviour
{
    [SerializeField]
    GameObject rockprefab;
    [SerializeField]
    Sprite rock1;
    [SerializeField]
    Sprite rock2;
    [SerializeField]
    Sprite rock3;
    [SerializeField]
    Sprite rock4;


    // Start is called before the first frame update
    void Start()
    {
        

       // GameObject rock = Instantiate(rockprefab) as GameObject;    //this line makes it spawn


        SpriteRenderer spriteRenderer = rockprefab.GetComponent<SpriteRenderer>();
        int spritenum = Random.Range(0, 4);
        if (spritenum == 0)
        {
            spriteRenderer.sprite = rock1;
        }
        else if (spritenum == 1)
        {
            spriteRenderer.sprite = rock2;
        }
        else if (spritenum==2) 
        {
            spriteRenderer.sprite = rock3;
        }
        else
        {
            spriteRenderer.sprite = rock4;
        }
    }


    public void initialize(Direction direc, Vector3 location)
    {
        transform.position = location;


        float angle = 0;

        float randomAngle = Random.value * 30f * Mathf.Deg2Rad;
        if (direc == Direction.Up)
        {
            angle = 75 * Mathf.Deg2Rad + randomAngle;
        }
        else if (direc == Direction.Left)
        {
            angle = 165 * Mathf.Deg2Rad + randomAngle;
        }
        else if (direc == Direction.Down)
        {
            angle = 255 * Mathf.Deg2Rad + randomAngle;
        }
        else
        {
            angle = -15 * Mathf.Deg2Rad + randomAngle;
        }

        StartMoving(angle);
    }

    public void StartMoving(float angle)
    {
        // apply impulse force to get asteroid moving
        const float MinImpulseForce = 0.5f;
        const float MaxImpulseForce = 1f;
        Vector2 moveDirection = new Vector2(
            Mathf.Cos(angle), Mathf.Sin(angle));
        float magnitude = Random.Range(MinImpulseForce, MaxImpulseForce);
        GetComponent<Rigidbody2D>().AddForce(
            moveDirection * magnitude,
            ForceMode2D.Impulse);
    }

   



    void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("bullet"))
        {
            AudioManager.Play(AudioClipName.AsteroidHit);

            if (transform.localScale.x < 0.4f)
            {
                Destroy(gameObject);
            }
            else
            {

                Vector3 newscale = transform.localScale;
                newscale.x *= 0.5f;
                newscale.y *= 0.5f;
                transform.localScale = newscale;

                CircleCollider2D collider = GetComponent<CircleCollider2D>();
                collider.radius = collider.radius / 2;

                // clone twice and destroy original
                GameObject newAsteroid = Instantiate<GameObject>(gameObject,
                                         transform.position, Quaternion.identity);
                newAsteroid.GetComponent<asteroids>().StartMoving(
                    Random.Range(0, 2 * Mathf.PI));
                newAsteroid = Instantiate<GameObject>(gameObject,
                    transform.position, Quaternion.identity);
                newAsteroid.GetComponent<asteroids>().StartMoving(
                    Random.Range(0, 2 * Mathf.PI));
                Destroy(gameObject);

            }
            
        } 
    }


    /* Update is called once per frame
    void Update()
    {
        
    }
    */
}
