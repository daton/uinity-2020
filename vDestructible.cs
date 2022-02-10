using DestroyIt;
using Invector;
using UnityEngine;

// This script provides an easy way to setup ModelShark Studio's Destructible objects
// to work with Invector's Third Person Controller Melee Combat Template.

// Place this script on your Destructible object, at the same level as the Destructible
// script.

[RequireComponent(typeof(Destructible))]
public class vDestructible : MonoBehaviour
{
    public float forceMultiplier = 0.5f;
    public GameObject defaultHitEffect;

    void Awake()
    {
        Destructible destructible = GetComponent<Destructible>();
        Collider[] colliders = destructible.GetComponentsInChildren<Collider>();
        for (int i = 0; i < colliders.Length; i++)
        {
            if (!colliders[i].isTrigger) // Ignore trigger colliders
            {
                // Add the DestructibleCollider script to each collider and configure it.
                vDestructibleCollider dc = colliders[i].gameObject.GetComponent<vDestructibleCollider>();
                if (dc == null)
                    dc = colliders[i].gameObject.AddComponent<vDestructibleCollider>();

                dc.ForceMultiplier = forceMultiplier;

                // If a Default Hit Effect was specified, add the HitDamageParticle script to each collider.
               
                
            }
        }
    }
}
