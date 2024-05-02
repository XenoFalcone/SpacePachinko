using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Quaternion = UnityEngine.Quaternion;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;
using TMPro;
using UnityEngine.Events;

public class Creator : MonoBehaviour
{

    [Header("Game Parameters")]
    public GameObject ballPrefab;
    [Space(15)]
    [Range(0.2f, 10f)]
    public float MoveSpeed;
    [Range(0, 100)]
    public int nbrBille;
    [Tooltip("Time between two ball")]
    [Range(0.2f, 5f)]
    public float freqBille;
    [Space(15)]
    [Header("UI Element")]
    public TextMeshProUGUI ballNumLabel;

    public UnityEvent OnAddBille = new UnityEvent();

    public bool isPaused = true;

    private bool goRight;
    private float chrono = 0f;
    private bool canShoot = true;

    // Start is called before the first frame update
    void Start()
    {
        if(transform.position.x < 2.45f)
        {
            goRight = true;
        }
        else
        {
            goRight = false;
        }

        gameObject.GetComponent<SpriteRenderer>().color = Color.red;
        ballNumLabel.text = nbrBille.ToString();

    }

    // Update is called once per frame
    void Update()
    {

        if (isPaused)
        {
            return;
        }

        if ((Input.GetButtonDown("Jump") || Input.GetMouseButtonDown(0)) && nbrBille > 0 && canShoot)
        {
            //Instantiate(ballPrefab, transform.position, Quaternion.identity);
            Instantiate(ballPrefab, new Vector3(transform.position.x, transform.position.y - 0.75f), Quaternion.identity);
            nbrBille--;
            canShoot =false;

            ballNumLabel.text = nbrBille.ToString();


        }

        if (!canShoot)
        {
            chrono += Time.deltaTime;

            gameObject.GetComponent<SpriteRenderer>().color = Color.black;
        }
        

        if (chrono >= freqBille)
        {
            canShoot = true;
            chrono = 0f;
            gameObject.GetComponent<SpriteRenderer>().color = Color.red;
        }
        
        

        //Debug.Log(transform.position.x);

        if(transform.position.x >= 2.45f)
        {
            goRight = false;
        }
        else if(transform.position.x <= -2.45f)
        {
            goRight = true;
        }

        if (goRight)
        {
            transform.Translate(MoveSpeed * Vector2.right * Time.deltaTime);
        }
        else
        {
            transform.Translate(MoveSpeed * Vector2.left * Time.deltaTime);
        }

        //0 :Left
        //1 :Right
        //2 :Molette
        //Input.GetMouseButton() = > Etat du bouton de la souris
    }

    public void AddBille(int value)
    {
        nbrBille += value;
        ballNumLabel.text = nbrBille.ToString();
        OnAddBille.Invoke();
    }

    public void SetPause(bool value)
    {
        isPaused = value;
    }

}
