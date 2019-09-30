using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamreaMove : MonoBehaviour
{
    private Transform Player;

    private Vector3 offset;

    private Vector3 speed = Vector3.zero;
    // private er hvor det kun er os som kan se det og det andre ting er en kode start hvor det er det som man forklare gennem koden

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;
        //det er til at finde hvad vi skal bruge
        offset = transform.position - Player.position;
        // det er hvor den fortæller hvor vi er 
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.SmoothDamp(transform.position, offset + Player.position, ref speed, 0.5f); 
        // den er bagrunde til at camret bevæger sig
    }
}
