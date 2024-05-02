using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Detector : MonoBehaviour
{

    public UnityEvent OnCollide = new UnityEvent();

    private void Awake()
    {
        //Debug.Log(" Awake ");
        // Pour communiquer avec ce GameObject
    }

    // Start is called before the first frame update
    void Start()
    {
       // Debug.Log(" Start ");
        // Pour communiquer avec les autres GameObject
    }

    // Update is called once per frame
    void Update()
    {
       // Debug.Log(" Update ");
        //Appelé au taux de rafraichissement du moteur graphique
    }

    //Appelé à chaque frame après l'Update
    private void LateUpdate()
    {
        //Debug.Log(" LateUpdate ");
        //Appelé au taux de rafraichissement du moteur graphique
    }

    private void FixedUpdate()
    {
        //Debug.Log(" FixedUpdate ");
        //Appelé au taux de rafraichissement du moteur physique
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log( "OnTriggerEnter2D" );
        Destroy(gameObject);
        OnCollide.Invoke();
        //collision.gameObject.name = "BalleRouge";
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
       // Debug.Log( "OnTriggerStay2D" );
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //Debug.Log( "OnTriggerExit2D" );
    }

}
