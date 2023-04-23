using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour , Damageable 
{
    [SerializeField]
    private string playerName;
    [SerializeField]
    private int health;
    [SerializeField]
    private int playerPA;
    [SerializeField]
    private int playerSpeed;
    [SerializeField]
    private int strenght;


    public string PlayerName { get => playerName; set => playerName = value; }
    public int PlayerPA { get => playerPA; set => playerPA = value; }
    public int PlayerSpeed { get => playerSpeed; set => playerSpeed = value; }
    public int Health { get => health; set => health = value; }
    public int Strenght { get => strenght; set => strenght = value; }

    public void getHit(int value)
    {
        this.health -= value;
    }

    public void hitEnemie(Damageable damageable, int value)
    {
        damageable.getHit(value);
    }

    private void Update()
    {
        if (health <= 0)
        {
            this.mort();
        }
    }

    public void mort()
    {
        Destroy(gameObject);
    }
}
