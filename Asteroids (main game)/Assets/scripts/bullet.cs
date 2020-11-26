using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    // death support
    const float LifeSeconds = 0.8f;
    Timer deathTimer;

    /// <summary>
    /// Use this for initialization
    /// </summary>
    void Start()
    {
        // create and run death timer
        deathTimer = gameObject.AddComponent<Timer>();    //addcomponent!!!! not get !!
        deathTimer.Duration = LifeSeconds;
        deathTimer.Run();
    }

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    void Update()
    {
        // kill bullet when timer is done
        if (deathTimer.Finished)
        {
            Destroy(gameObject);
        }
    }


    public void Applyforce(Vector2 direction)
    {
        float force = 8f;
        GetComponent<Rigidbody2D>().AddForce(
           direction * force,
           ForceMode2D.Impulse);
    }

}
