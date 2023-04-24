using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class GameManager : MonoBehaviour
{
    public Player player;
    public List<Enemie> enemies = new();
    public SpawnManager spawnManager;
    public Enemie currentEnemie;

    [SerializeField]
    private GameObject sparks;

    [SerializeField]
    public int explosionPower;

    [SerializeField]
    public int radius;

    [SerializeField]
    private Transform map;

    [SerializeField]
    public List<GameObject> enemiesList;

    [SerializeField]
    private string playerName;


    public string PlayerName { get => playerName; set => playerName = value; }

    public void initializePlayer()
    {
        player.PlayerName = this.playerName;
    }

    // Start is called before the first frame update
    void Start()
    {
        this.initializePlayer();
        this.spawnEnemie();
    }

    private void spawnEnemie()
    {
        this.spawnManager.spawnMonster();
    }

    public void OnEnemieDeath()
    {
        spawnEnemie();
    }

    private void Update()
    {
        //probably in the player ?
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100f))
            {
                if (this.currentEnemie.collider != null)
                {
                    if (hit.collider.gameObject == this.currentEnemie.collider.gameObject)
                    {
                        if (getParentOfChild(hit.collider.gameObject.transform) == this.currentEnemie)
                        {
                            this.currentEnemie.getHit(this.player.Strenght);
                            hitSpark(hit.point);
                        }
                    }
                }

                if (hit.collider.gameObject.GetComponent<Rigidbody>() != null)
                {
                    if (getParentOfChild(hit.collider.gameObject.transform) == this.currentEnemie)
                    {
                        this.currentEnemie.getHit(this.player.Strenght);
                        hitSpark(hit.point);
                    }
                    Rigidbody rb = hit.collider.gameObject.GetComponent<Rigidbody>();
                    rb.AddExplosionForce(this.explosionPower * 10, hit.point, radius);
                }
            }
        }
    }

    private void hitSpark(Vector3 pos)
    {
        this.sparks.transform.position = pos;
        this.sparks.GetComponent<ParticleSystem>().Play();
    }

    private Enemie getParentOfChild(Transform child)
    {
        Transform parent = child.parent;
        Enemie enemie = parent.GetComponent<Enemie>();

        if (enemie == null)
        {
            getParentOfChild(parent);
        }
        return enemie;
    }
}
