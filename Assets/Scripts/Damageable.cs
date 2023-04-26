using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Damageable
{
    public float Health { get; set; }

    public void hitEnemie(Damageable damageable, float value);
    public void getHit(Damageable Hiter,float value);
    public void mort();
}