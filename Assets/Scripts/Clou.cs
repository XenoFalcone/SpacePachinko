using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Clou : MonoBehaviour
{
    public UnityEvent OnCollide = new UnityEvent();

    //public GameObject OImpactSound;
    //private AudioSource ImpactSound;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Destroy(gameObject);
        //ImpactSound.   Play();
        OnCollide.Invoke();
    }
}
