using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class EasterEgg : PickupBase


{
    public GameObject EasterEggMessage;
    
    public override void PickupEffect(){
        base.PickupEffect();
        EasterEggMessage.SetActive(true);
    }


}
