using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class Player : MonoBehaviour , Damageable 
{
    [SerializeField]
    private string playerName;
    [SerializeField]
    private float health;
    [SerializeField]
    private int playerSpeed;
    [SerializeField]
    private int money;
    [SerializeField]
    private XpBarre xpBarre;
    [SerializeField]
    private TextMeshProUGUI moneyText;

    public RectTransform addMoneyTextPos;

    public GameObject textPrefab;

    public AnimationCurve strenghtScale;

    public WeaponData weaponData;

    public GameObject rightHand;

    public GameObject leftHand;

    [SerializeField]
    private Stat[] stats;

    public string PlayerName { get => playerName; set => playerName = value; }
    public int PlayerSpeed { get => playerSpeed; set => playerSpeed = value; }
    public float Health { get => health; set => health = value; }


    private void Awake()
    {
        this.setStatValue(EStat.STRENGHT, this.strenghtScale.Evaluate(this.xpBarre.getLevel()));
    }

    private void Start()
    {
        this.moneyText.text = "Money : " + this.money;
        this.setStatValue(EStat.STRENGHT_COEF, this.weaponData.coef);
    }

    private void Update()
    {
        //Old code
        if (health <= 0)
        {
            this.mort();
        }
    }

    public void getHit(Damageable hiter, float value)
    {
        this.health -= value;
    }

    public void hitEnemie(Damageable damageable, float value)
    {
        damageable.getHit(this, value);
    }

    public void mort()
    {
        Destroy(gameObject);
    }

    public void grantReward(float money, float xp)
    {
        GameObject textXp = Instantiate(textPrefab, this.xpBarre.xpRectTransform.position, Quaternion.identity);
        textXp.GetComponent<TextMeshProUGUI>().text = "+" + ((int)xp).ToString();
        textXp.transform.SetParent(this.xpBarre.xpRectTransform.transform);

        GameObject textMoney = Instantiate(textPrefab, this.addMoneyTextPos.GetComponent<RectTransform>().position, Quaternion.identity);
        textMoney.GetComponent<TextMeshProUGUI>().text = "+" + ((int)money).ToString();
        textMoney.transform.SetParent(this.addMoneyTextPos);

        this.money += (int)money;
        this.moneyText.text = "Money : " + this.money;
        this.xpBarre.grantXp(xp);
    }

    public void onPlayerLevelUp()
    {
        this.stats[(int)EStat.STRENGHT].value = (int)strenghtScale.Evaluate(this.xpBarre.getLevel());
    }

    public float getStatValue(EStat enumStat) {
        return this.stats[(int)enumStat].value;
    }

    public void setStatValue(EStat enumStat, float value)
    {
        this.stats[(int)enumStat].value = value;
    }
}