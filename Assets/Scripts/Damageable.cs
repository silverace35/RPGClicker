using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Damageable
{
    public int Health { get; set; }

    public void hitEnemie(Damageable damageable, int value);
    public void getHit(int value);
    public void mort();
}