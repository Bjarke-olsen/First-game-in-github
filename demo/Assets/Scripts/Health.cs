using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FloatEvent : UnityEvent<float> { }

public class Health : MonoBehaviour
{
    //Hvad er det nu den grønne tekst betyder?
    public UnityEvent deathEvent;
    public FloatEvent healEvent;
    public FloatEvent damageEvent;

    [SerializeField] //Hvad gør denne linje?
    [Range(20, 200)] //Hvad gør denne linje?
    private int health = 100;

    /*>/immunity>*/
    [SerializeField]
    private bool EnableImunity = false;

    [SerializeField]
    private float immuntyTime = 1.0f;

    private bool _curImmune = false;

    // Start is called before the first frame update
        void Awake()
    {
        deathEvent = new UnityEvent();
        healEvent = new FloatEvent();
        damageEvent = new FloatEvent();

        damageEvent.AddListener(TakeDamage);

    }

    /// <summary>
    /// Hvad gør denne funktion?
    /// </summary>
    /// <param name="damageRecieved">Hvad gør denne parameter?</param>
    private void TakeDamage(float damageRecieved)
    {
        // check om vi er immune
        if(!EnableImunity || (EnableImunity && !_curImmune))
        {
            health -= (int)damageRecieved;
            if (health <= 0)
            {
                deathEvent.Invoke();
            }

            if (EnableImunity)
            {
                StartCoroutine(ImmunityTimer(immuntyTime));
            }
            
        }
        
        // slå immune til her:

    }
    IEnumerator ImmunityTimer(float seconds)
    {
       
        _curImmune = true;
        yield return new WaitForSeconds(seconds);
        _curImmune = false;
    }
}
