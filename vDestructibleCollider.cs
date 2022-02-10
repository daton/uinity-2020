using DestroyIt;

using Invector;



using UnityEngine;



// This script provides an easy way to setup ModelShark Studio's Destructible objects

// to work with Invector's Third Person Controller Melee Combat Template. 



// This script is automatically added to each collider when the vDestructible script is

// on your Destructible object.



[RequireComponent(typeof(Collider))]

public class vDestructibleCollider : MonoBehaviour, vIDamageReceiver

{

    public float ForceMultiplier { get; set; }

    public OnReceiveDamage onStartReceiveDamage => throw new System.NotImplementedException();

    public OnReceiveDamage onReceiveDamage => throw new System.NotImplementedException();

    private Rigidbody rbody;

    private Destructible destructible;



    void Start()

    {

        destructible = GetComponent<Destructible>();

        rbody = GetComponentInParent<Rigidbody>();

    }



    public void TakeDamage(vDamage damage)

    {

        print("antes del dano ");

        if (ForceMultiplier <= 0f) // Default to 0.5f if for some reason ForceMultiplier hasn't been set.

            ForceMultiplier = 5.5f;



        var point = damage.hitPosition;

        var relativePoint = transform.position;

        relativePoint.y = point.y;

        var forceForward = relativePoint - point;



        if (rbody != null && destructible != null)

        {

            Debug.Log("[" + destructible.name + "] got hit for " + damage.damageValue + " points of damage!");
            print("SI SE VA A APLICAR DANO ");

            destructible.ApplyDamage(damage.damageValue);

            rbody.AddForce(forceForward * (damage.damageValue * ForceMultiplier), ForceMode.Impulse);

        }

    }

    /*
    public void TakeDamage(vDamage damage)
    {
        // throw new System.NotImplementedException();
        print("Vamos a danaaaar al cubo malo jajajja");
    }

    */
}