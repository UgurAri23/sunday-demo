using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableBehaviour : MonoBehaviour
{
    public GameObject Collectable;
    public ParticleSystem CollectParticle;
    public Collider Trigger;
    
    public void Collect()
    {

        Collectable.gameObject.SetActive(false);
        CollectParticle.Play(true);
        Trigger.enabled = false;

    }

}
