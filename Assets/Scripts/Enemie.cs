using System.Collections;
using UnityEngine;
using UnityEngine.Events;


public class Enemie : MonoBehaviour, Damageable
{
    private GameManager gameManager;

    public UnityEvent onEnemieDeath;

    private bool deathFlag = false;

    [SerializeField]
    private bool isRigged;

    [SerializeField]
    public string enemieName;

    public float health;

    [SerializeField]
    private int speed;

    [SerializeField]
    private Transform enemieHead;

    [SerializeField]
    private GameObject prefabText;

    [SerializeField]
    private float tempsMort;

    [SerializeField]
    public Collider collider;

    public float Health { get => health; set => health = value; }
    public int Speed { get => speed; set => speed = value; }
    public GameManager GameManager { set => gameManager = value; }

    public void getHit(float value)
    {
        if (!deathFlag)
        {
            this.health -= value;
            GameObject text = Instantiate(prefabText, this.enemieHead.position, Quaternion.identity, this.gameManager.transform);
            text.GetComponent<DamageText>().TextMeshPro.text = "-" + value.ToString();
            text.transform.SetParent(this.enemieHead);
            Destroy(text, tempsMort);
        }
    }

    public void hitEnemie(Damageable damageable, float value)
    {
        damageable.getHit(value);
    }

    private void Start()
    {
        setRagdoll(false);
        onEnemieDeath.AddListener(gameManager.OnEnemieDeath);
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
        if (deathFlag == false)
        {
            deathFlag = true;
            StartCoroutine(MortCoroutine());
        }
    }

    IEnumerator MortCoroutine()
    {
        if(isRigged)
        {
            setRagdoll(true);
            Destroy(collider);
        } 
        else
        {
            this.collider.gameObject.AddComponent<Rigidbody>();
            this.collider.gameObject.GetComponent<Rigidbody>().mass = 20f;
        }
        yield return new WaitForSeconds(tempsMort);
        onEnemieDeath?.Invoke();
        //Destroy(this.gameObject);
    }

    private void setRagdoll(bool boolean)
    {
        Rigidbody[] rigidbodies = GetComponentsInChildren<Rigidbody>();

        foreach (Rigidbody childrb in rigidbodies)
        {
            childrb.isKinematic = !boolean;
        }
    }
}
