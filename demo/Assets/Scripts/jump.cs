using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jump : MonoBehaviour
{
    [SerializeField]
    private float forcemod = 10f;

    private Rigidbody2D rb2d;

    private GroundCheck gc;

    // det er forkortes af nogle lange ord som vi har ændet som til kort

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        gc = GetComponentInChildren<GroundCheck>(); 
        // det er noget godt
    }

    // Update is called once per frame
    void Update()
    {
        // hvis man trykker sker der noget
        if (Input.GetKeyDown(KeyCode.Space) && gc.Grounded) {
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * forcemod, ForceMode2D.Impulse);
        }
    }
}
