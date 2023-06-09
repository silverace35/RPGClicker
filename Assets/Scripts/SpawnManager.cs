using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameManager gameManager;

    [SerializeField]
    private int monsterCount = 0;

    [SerializeField]
    private int currentMonster;

    [SerializeField]
    private int currentWave;

    [SerializeField]
    private float currentScale;

    [SerializeField]
    private List<int> waveMonsters;

    [SerializeField]
    private Transform spawnPoint;

    public AnimationCurve hpScale;

    // Start is called before the first frame update
    void Start()
    {
        this.currentWave = 0;
        this.currentMonster = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void spawnMonster()
    {
        this.monsterCount++;
        this.currentMonster++;

        

        if (this.currentMonster > this.waveMonsters[this.currentWave])
        {
            this.currentMonster = 1;
            this.currentWave++;
            Debug.Log("Nouvelle vague");
        }

        if (this.waveMonsters.Count == this.currentWave)
        {
            this.currentWave = 0;
            Debug.Log("Ascention");
            foreach (Transform child in this.spawnPoint.transform)
            {
                Destroy(child.gameObject, 3f);
            }
        }

        System.Random random = new System.Random();
        GameObject enemie = Instantiate(gameManager.enemiesList[random.Next(0, gameManager.enemiesList.Count)], this.spawnPoint);
        enemie.GetComponent<Enemie>().GameManager = gameManager;
        enemie.transform.LookAt(gameManager.player.transform);
        gameManager.currentEnemie = enemie.GetComponent<Enemie>();
        //Set enemie health
        enemie.GetComponent<Enemie>().health = this.hpScale.Evaluate(this.monsterCount);
    }

    public int getMonsterCount()
    {
        return this.monsterCount;
    }
}
