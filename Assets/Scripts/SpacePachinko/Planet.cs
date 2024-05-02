using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Planet : MonoBehaviour
{

    public UnityEvent OnCollide = new UnityEvent();
    public float MoveDistanceX;
    public float MoveDistanceY;
    public float MoveSpeedX;
    public float MoveSpeedY;

    private float PlanetOriginalPositionX;
    private float PlanetOriginalPositionY;
    private bool goRight;
    private bool goUp;

    // Start is called before the first frame update
    void Start()
    {
        PlanetOriginalPositionX = transform.position.x;
        PlanetOriginalPositionY = transform.position.y;
        goRight = Random.value < 0.5f;
        goUp = Random.value < 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        if(MoveDistanceX > 0)
        {
            if (transform.position.x <= PlanetOriginalPositionX - MoveDistanceX)
            {
                goRight = true;
            }
            else if(transform.position.x >= PlanetOriginalPositionX + MoveDistanceX)
            {
                goRight = false;
            }

            if (goRight)
            {
                transform.Translate(MoveSpeedX * Vector2.right * Time.deltaTime);
            }
            else
            {
                transform.Translate(MoveSpeedX * Vector2.left * Time.deltaTime);
            }
        }

        if (MoveDistanceY > 0)
        {
            if (transform.position.y <= PlanetOriginalPositionY - MoveDistanceY)
            {
                goUp = true;
            }
            else if (transform.position.y >= PlanetOriginalPositionY + MoveDistanceY)
            {
                goUp = false;
            }

            if (goUp)
            {
                transform.Translate(MoveSpeedY * Vector2.up * Time.deltaTime);
            }
            else
            {
                transform.Translate(MoveSpeedY * Vector2.down * Time.deltaTime);
            }
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        OnCollide.Invoke();
    }
}
