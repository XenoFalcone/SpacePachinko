using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using Vector2 = UnityEngine.Vector2;

public class Ship : MonoBehaviour
{
    [Header("Game Parameters")]
    public GameObject MeteorPrefab;
    [Range(0.2f, 10f)]
    public float MoveSpeed;
    public int nbrMeteor;
    [Tooltip("Time between two meteors")]
    [Range(0.2f, 5f)]
    public float shootInterval;

    public Sprite redShip;
    public Sprite greenShip;

    public bool isPaused = true;

    private bool goRight;
    private float chrono = 0f;
    private bool canShoot = true;
    private SpriteRenderer spriteRenderer;

    public UnityEvent OnShoot = new UnityEvent();
    public UnityEvent OnAddMeteor = new UnityEvent();

    [Header("UI Element")]
    public TextMeshProUGUI MeteorNbrLabel;

    // Start is called before the first frame update
    void Start()
    {
        if (transform.position.x < 2.55f)
        {
            goRight = true;
        }
        else
        {
            goRight = false;
        }

        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = greenShip;
        MeteorNbrLabel.text = "Meteores\n"+nbrMeteor.ToString();

    }

    // Update is called once per frame
    void Update()
    {

        if( isPaused)
        {
            return;
        }
        
        if((Input.GetButtonDown("Jump") || Input.GetMouseButtonDown(0)) && nbrMeteor > 0 && canShoot)
        {
            //Instantiate(ballPrefab, transform.position, Quaternion.identity);
            Instantiate(MeteorPrefab, new Vector3(transform.position.x, transform.position.y - 0.75f), Quaternion.identity);
            nbrMeteor--;
            canShoot = false;
            OnShoot.Invoke();
            MeteorNbrLabel.text = "Meteores\n" + nbrMeteor.ToString();


        }

        if (!canShoot)
        {
            chrono += Time.deltaTime;
            spriteRenderer.sprite = redShip;
        }

        if (chrono >= shootInterval)
        {
            canShoot = true;
            chrono = 0f;
            spriteRenderer.sprite = greenShip;
        }


        if (transform.position.x >= 2.55f)
        {
            goRight = false;
        }
        else if (transform.position.x <= -2.55f)
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
    }

    public void AddMeteor(int value)
    {
        nbrMeteor += value;
        MeteorNbrLabel.text = "Meteores\n" + nbrMeteor.ToString();
        OnAddMeteor.Invoke();
    }

    public void SetPause (bool value)
    {
        isPaused = value;
    }
}
