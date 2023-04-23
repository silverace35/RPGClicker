using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DamageText : MonoBehaviour
{
    [SerializeField]
    private TextMeshPro textMeshPro;

    public TextMeshPro TextMeshPro { get => textMeshPro; set => textMeshPro = value; }

    void Start()
    {
        textMeshPro.transform.LookAt(Camera.main.transform);
        textMeshPro.transform.Rotate(new Vector3(textMeshPro.transform.rotation.x, -180f, textMeshPro.transform.rotation.z));
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.localPosition += Vector3.up * Time.deltaTime;
    }
}
