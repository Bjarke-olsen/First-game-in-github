using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    // den skud vi skal indcætte 
    [SerializeField]
    GameObject bullet;

    //true vis du er spilleren false hvis det er fjenden 
    [SerializeField]
    bool playerMode = false;

     // tid mellem hver skud
    [SerializeField]
    float cooldown = 1f;

    private Vector3 direction;
    // knap man bruger for at få den til at skyde.
    [SerializeField]
    private KeyCode shootKey = KeyCode.Mouse0;

    //gør man ikke kan skyde igen
    bool _currentlyCoolingdown = false;


    // Start is called before the first frame update
    void Start()
    {
        if(!playerMode)
        {
            StartCoroutine(EnemyShootTimer(cooldown));
               
        }
    }

    private IEnumerator EnemyShootTimer(float cooldown)
    {
        while (true)
        {
            yield return new WaitForSeconds(cooldown);

            CreateBulletTowardsTarget(GameObject.FindGameObjectWithTag("Player").transform.position);

        }
    }

    private GameObject CreateBulletTowardsTarget(Vector3 position)
    {
        return Instantiate(bullet, transform.position + (position.normalized).normalized, Quaternion.identity, null);
    }

    // Update is called once per frame
    void Update()
    {
        //Denne er efterladt tom, 
        if(playerMode && Input.GetKeyDown(shootKey) && !_currentlyCoolingdown )
        {
            Debug.Log("vi skyder");
            GameObject instanciatedBullet = CreateBulletTowardsTarget(GetMousePos());
            //force her:
            instanciatedBullet.GetComponent<Rigidbody2D>().AddForce((GetMousePos() - transform.position).normalized * 5f, ForceMode2D.Impulse);
        }

    }

    private static Vector3 GetMousePos(bool normalized = false)
    {
        Vector3 camvec = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        camvec.z = 0f;
        return normalized ? camvec.normalized : camvec;
    }

}
