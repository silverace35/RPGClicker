using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class generalAdditiveText : MonoBehaviour
{
    [SerializeField]
    private float timeToKill = 2f;
    [SerializeField]
    private int zOffset = 10;
    [SerializeField]
    private int speed = 500;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, timeToKill);
        System.Random random = new System.Random();
        this.GetComponent<RectTransform>().localRotation = Quaternion.Euler(0f, 0f, random.Next(-zOffset, zOffset));
        this.GetComponent<RectTransform>().localPosition = new Vector3 (random.Next(-zOffset, zOffset) * 5, random.Next(-zOffset, zOffset) * 5, 0);
        this.GetComponent<RectTransform>().localScale = Vector3.one * 8;
    }

    // Update is called once per frame
    void Update()
    {
        this.GetComponent<RectTransform>().localPosition += Vector3.up * speed * Time.deltaTime;
    }
}
