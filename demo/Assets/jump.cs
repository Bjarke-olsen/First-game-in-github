using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jump : MonoBehaviour
{
    [SerializeField]
    private float forcemod = 10f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // hvis man trykker sker der noget
        if (Input.GetKeyDown(KeyCode.Space)) {
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * forcemod, ForceMode2D.Impulse);
        }
    }
}
