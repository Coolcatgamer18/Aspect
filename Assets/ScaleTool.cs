using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleTool : MonoBehaviour
{

    public float Scale;
    public float maxscale;
    public float minscale;
    public float currentscale;

    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        Scale = 1.0f;


    }

    // Update is called once per frame
    void Update()
    {
        float dt = Time.deltaTime;

        currentscale = Scale;


        if (Input.GetKey(KeyCode.Mouse0))
        {
            Scale += 0.1f * dt * 20;
        }


        if (Input.GetKey(KeyCode.Mouse1))
        {
            Scale -= 0.1f * dt * 20;
        }

        if (Scale > maxscale)
        {
            Scale = maxscale;
        }
        else
        {
            Scale = Scale;
        }

        if (Scale < minscale)
        {
            Scale = minscale;
        }
        else
        {
            Scale = Scale;
        }

        player.transform.localScale = new Vector3(currentscale, currentscale, 0);

    }
}
