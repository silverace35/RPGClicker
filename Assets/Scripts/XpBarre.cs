using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class XpBarre : MonoBehaviour
{
    [SerializeField]
    Player player;

    [SerializeField]
    TextMeshProUGUI playerLevelText;

    [SerializeField]
    TextMeshProUGUI playerCurrentXpText;

    [SerializeField]
    TextMeshProUGUI playerRequiredXpText;

    [SerializeField]
    Slider playerXpSlider;

    [SerializeField]
    GameObject sliderBar;

    [SerializeField]
    private float xpRequireInitial;

    [SerializeField]
    private float xp;

    [SerializeField] 
    private float xpMax;

    [SerializeField]
    private int level;

    [SerializeField]
    private float xpScale;

    [SerializeField]
    public RectTransform xpRectTransform;


    // Start is called before the first frame update
    void Start()
    {
        this.level = 0;
        this.levelUp();
        this.xp = 0;
        this.xpMax = this.xpRequireInitial;
        this.playerRequiredXpText.text = ((int)this.xpMax).ToString();
        this.playerXpSlider.value = this.xp;
        this.playerXpSlider.maxValue = this.xpMax;
    }

    // Update is called once per frame
    void Update()
    {
        updatePlayerXp();
    }

    public void grantXp(float xp)
    {
        float reste = 0;
        this.xp += xp;
        if (this.xp > this.xpMax)
        {
            reste = this.xp - this.xpMax;
            this.xp = reste;
            this.levelUp();
        }
    }

    private void updatePlayerXp()
    {
        if (this.xp < 1)
        {
            this.sliderBar.SetActive(false);
        } else
        {
            this.sliderBar.SetActive(true);
        }

        this.playerCurrentXpText.text = ((int)this.xp).ToString();
        this.playerXpSlider.value = (int)this.xp;
    }

    private void levelUp()
    {
        this.level++;
        this.playerLevelText.text = "Niveau " + this.level;
        this.xpMax = xpRequireInitial * Mathf.Pow(this.xpScale, this.level);
        this.playerRequiredXpText.text = ((int)this.xpMax).ToString();
        this.playerXpSlider.value = this.xp;
        this.playerXpSlider.maxValue = this.xpMax;
    }
}
