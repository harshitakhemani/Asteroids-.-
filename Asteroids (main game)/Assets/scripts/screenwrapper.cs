using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class screenwrapper : MonoBehaviour
{

    [SerializeField]
    float Radius;


    // Start is called before the first frame update
    void Start()
    {
        Radius = GetComponent<CircleCollider2D>().radius;

    }

    void OnBecameInvisible()
    {
       

        Vector3 shipposition = transform.position;

        if (shipposition.x + Radius > ScreenUtils.ScreenRight)
        {
            shipposition.x = ScreenUtils.ScreenLeft - ScreenUtils.ScreenRight + shipposition.x;
        }

        else if (shipposition.x - Radius < ScreenUtils.ScreenLeft)
        {
            shipposition.x = ScreenUtils.ScreenRight + ScreenUtils.ScreenLeft - shipposition.x;
        }

        if (shipposition.y + Radius > ScreenUtils.ScreenTop)
        {
            shipposition.y = ScreenUtils.ScreenBottom - ScreenUtils.ScreenTop + shipposition.y;
        }

        else if (shipposition.y - Radius < ScreenUtils.ScreenBottom)
        {
            shipposition.y = ScreenUtils.ScreenBottom + ScreenUtils.ScreenTop - shipposition.y;
        }
        transform.position = shipposition;
    }


}
