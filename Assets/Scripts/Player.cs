using System.Collections;
using System.Collections.Generic;
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
    private int strenght;
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

    public string PlayerName { get => playerName; set => playerName = value; }
    public int PlayerSpeed { get => playerSpeed; set => playerSpeed = value; }
    public float Health { get => health; set => health = value; }
    public int Strenght { get => strenght; set => strenght = value; }

    public void getHit(Damageable hiter, float value)
    {
        this.health -= value;
    }

    public void hitEnemie(Damageable damageable, float value)
    {
        damageable.getHit(this, value);
    }

    private void Start()
    {
        this.moneyText.text = "Money : " + this.money;
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
        this.strenght = (int)strenghtScale.Evaluate(this.xpBarre.getLevel());
    }
}