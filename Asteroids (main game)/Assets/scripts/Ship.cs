using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEditor;
using UnityEngine;

public class Ship : MonoBehaviour
{
    [SerializeField]
    GameObject Bulletprefab;
    [SerializeField]
    Rigidbody2D ship;
    [SerializeField]
    Vector2 thrustdirection = new Vector2(1.0f, 0.0f);
    [SerializeField]
    const float thrustforce = 5f;
    [SerializeField]
    HUD hud;
    [SerializeField]
    const float rotateDegreesPerSecond = 200f;


    private void Start()
    {
        
    }

    void FixedUpdate()
    {
        ship = gameObject.GetComponent<Rigidbody2D>();

        if (Input.GetAxis("Thrust")!=0)
        {           
           ship.AddForce(thrustdirection * thrustforce, ForceMode2D.Force);
        }

    }

   

   // Update is called once per frame
    void Update()
    {
        // calculate rotation amount and apply rotation

        float rotationInput = Input.GetAxis("Rotate");

        float rotationAmount = rotateDegreesPerSecond * Time.deltaTime;

        if (rotationInput < 0)
        { 
            rotationAmount *= -1;
           
        }
        else if(rotationInput>0)
        {
            rotationAmount *= 1;
            
        }
        else
        {
            rotationAmount=0;
        }

        transform.Rotate(Vector3.forward, rotationAmount);

        Vector3 currentEulerAngles=transform.eulerAngles;

        thrustdirection = new Vector2(Mathf.Cos(currentEulerAngles.z*Mathf.Deg2Rad),Mathf.Sin(currentEulerAngles.z*Mathf.Deg2Rad));

        if(Input.GetKeyDown(KeyCode.LeftControl))
        {
            

          /*  Vector3 newscale = Bulletprefab.transform.localScale;
            newscale.x *= 1f;
            newscale.y *= 1f;
            Bulletprefab.transform.localScale = newscale;
          */

            GameObject Bullet = Instantiate(Bulletprefab, transform.position, Quaternion.identity);
            bullet script = Bullet.GetComponent<bullet>();
            script.Applyforce(thrustdirection);

            AudioManager.Play(AudioClipName.PlayerShot);


        }


    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag=="asteroid")
        {
            AudioManager.Play(AudioClipName.PlayerDeath);
            hud = GameObject.FindGameObjectWithTag("HUD").GetComponent<HUD>();
            hud.stopgametimer();

            Destroy(gameObject);

            
        }
    }

}
