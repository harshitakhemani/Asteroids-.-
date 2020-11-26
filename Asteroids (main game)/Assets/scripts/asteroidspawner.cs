using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class asteroidspawner : MonoBehaviour
{
    [SerializeField]
    GameObject prefabasteroid;

    // Start is called before the first frame update
    void Start()
    {
        // float asteroidradius = GetComponent<CircleCollider2D>().radius;    // just this wont be sufficient because the script is attached to main camera        

        GameObject asteroid = Instantiate<GameObject>(prefabasteroid);
        CircleCollider2D collider = asteroid.GetComponent<CircleCollider2D>();
        float asteroidradius = collider.radius;
        Destroy(asteroid);

        // calculate screen width and height
        float screenWidth = ScreenUtils.ScreenRight - ScreenUtils.ScreenLeft;
        float screenHeight = ScreenUtils.ScreenTop - ScreenUtils.ScreenBottom;

        // bottom side asteroid
        asteroid = Instantiate<GameObject>(prefabasteroid);
        asteroids script = asteroid.GetComponent<asteroids>();
        script.initialize(Direction.Up,
            new Vector2(ScreenUtils.ScreenLeft + screenWidth / 2,
                ScreenUtils.ScreenBottom - asteroidradius));

        // right side asteroid
        asteroid = Instantiate<GameObject>(prefabasteroid);
         script = asteroid.GetComponent<asteroids>();
        script.initialize(Direction.Left,
            new Vector2(ScreenUtils.ScreenRight + asteroidradius,
                ScreenUtils.ScreenBottom + screenHeight / 2));

        // top side asteroid
        asteroid = Instantiate<GameObject>(prefabasteroid);
         script = asteroid.GetComponent<asteroids>();
        script.initialize(Direction.Down,
            new Vector2(ScreenUtils.ScreenLeft + screenWidth / 2,
                ScreenUtils.ScreenTop + asteroidradius));

        // left side asteroid
        asteroid = Instantiate<GameObject>(prefabasteroid);
        script = asteroid.GetComponent<asteroids>();
        script.initialize(Direction.Right,
            new Vector2(ScreenUtils.ScreenLeft - asteroidradius,
                ScreenUtils.ScreenBottom + screenHeight / 2));




    }


}
