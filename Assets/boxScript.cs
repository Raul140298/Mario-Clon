using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boxScript : MonoBehaviour
{
    public Animator animator;
    public GameObject moneda;
    // Start is called before the first frame update
    void Start()
    {
        animator = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Contains("player"))
        {
            animator.SetBool("pushed", true);

            //Botar moneda
            Instantiate(moneda, new Vector3(this.transform.position.x, this.transform.position.y,1f), Quaternion.identity);
        }

    }
}
