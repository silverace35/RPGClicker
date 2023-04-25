using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EnemieUI : MonoBehaviour
{
    [SerializeField]
    Enemie currentEnemie;

    [SerializeField]
    TextMeshProUGUI enemieNameText;

    [SerializeField]
    TextMeshProUGUI enemieCurrentHpText;

    [SerializeField]
    TextMeshProUGUI enemieMaxHpText;

    [SerializeField]
    Slider enemieHpSlider;

    [SerializeField]
    GameObject sliderBar;


    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (this.currentEnemie == null)
        {
            this.enabled = false;
        } else
        {
            updateEnemieHp();
        }
    }
    public void setNewEnemie(Enemie enemie)
    {
        this.sliderBar.SetActive(true);
        this.currentEnemie = enemie;
        this.enemieMaxHpText.text = ((int)enemie.health).ToString();
        this.enemieNameText.text = enemie.enemieName.ToString();
        this.enemieCurrentHpText.text = ((int)enemie.health).ToString();
        this.enemieHpSlider.maxValue = (int)this.currentEnemie.health;
    }


    private void updateEnemieHp()
    {
        if(this.currentEnemie.health < 1)
        {
            this.sliderBar.SetActive(false);
        }
        this.enemieCurrentHpText.text = ((int)this.currentEnemie.health).ToString();
        this.enemieHpSlider.value = (int)this.currentEnemie.health;
    }
}
