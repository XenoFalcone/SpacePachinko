using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Vector3 = UnityEngine.Vector3;
using UnityEngine.Events;

public class BlackHole : MonoBehaviour
{

    public float RotateSpeed;
    public UnityEvent OnCollide = new UnityEvent();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0.0f, 0.0f, RotateSpeed* Time.deltaTime, Space.Self);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(collision.gameObject, 0.02f);
        OnCollide.Invoke();
        //collision.gameObject.name = "BalleRouge";

    }
}
