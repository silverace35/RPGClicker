using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class toggleShop : MonoBehaviour
{
    [SerializeField]
    private Boolean toggle;

    public int positionToggled;
    public int positionUntoggled;

    [SerializeField]
    private TextMeshProUGUI tmpButton;

    [SerializeField]
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        this.toggle = false;
        this.tmpButton.text = "<";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void toggleShopAction()
    {
        if (toggle)
        {
            this.gameObject.transform.parent.GetComponent<RectTransform>().anchoredPosition = new Vector3(this.positionUntoggled, 0f, 0f);
            this.tmpButton.text = "<";
            this.animator.ResetTrigger("open");
            this.animator.SetTrigger("close");
        }
        else
        {
            this.gameObject.transform.parent.GetComponent<RectTransform>().anchoredPosition = new Vector3(this.positionToggled, 0f, 0f);
            this.tmpButton.text = ">";
            this.animator.ResetTrigger("close");
            this.animator.SetTrigger("open");
        }

        toggle = !toggle;
    }
}
