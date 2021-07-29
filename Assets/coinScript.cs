using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinScript : MonoBehaviour
{
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<Rigidbody2D>().AddForce(Vector2.up * speed * Time.deltaTime);
        Destroy(this.gameObject, 0.75f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
