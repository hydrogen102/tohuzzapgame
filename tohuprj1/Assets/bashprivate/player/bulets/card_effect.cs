using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class card_effect : MonoBehaviour
{
    public int dmg;
    ParticleSystem thispar;
    public GameObject bounced_particle;

    private void Awake()
    {
        thispar = GetComponent<ParticleSystem>();
        
    }

    private void OnParticleCollision(GameObject card)
    {
        if(card.CompareTag("card"))
        {
            card.GetComponent<bulets>().hit();
        }
        else
        if(card.CompareTag("enemy"))
        {
            card.GetComponent<Health>().damage(dmg);
        }
        
        if(card.CompareTag("parry"))
        {
            if (thispar.subEmitters.subEmittersCount <= 0)
            {
               GameObject secondcard = Instantiate(bounced_particle, transform);
               thispar.subEmitters.AddSubEmitter(secondcard.GetComponent<ParticleSystem>(),ParticleSystemSubEmitterType.Manual,ParticleSystemSubEmitterProperties.InheritNothing);
            }
            thispar.TriggerSubEmitter(0);
        }
        else
        {
            
           
        }
    }
}
