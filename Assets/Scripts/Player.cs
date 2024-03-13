using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class Player : MonoBehaviour
{
    public static Player instance;

    public int currentMoney;

    public float maxStamina;
    public float currentMaxStamina;
    public float currentStamina;
    public float timeBtwStaminaInc;

    public float maxHealth;
    private float currentHealth;

    public bool isPlayerDead;
    public bool isUsingStamina;

    public TextMeshProUGUI infoText;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        currentHealth = maxHealth;
        currentStamina = maxStamina;
    }

    void Update()
    {
        if (Physics.Raycast (transform.position, transform.TransformDirection(Vector3.forward), out RaycastHit hitInfo, 3.5f))
        {
            if (hitInfo.collider.gameObject.tag == "ShopArea")
            {
                //Debug.Log("SHOOOPP");
                infoText.gameObject.SetActive(true);
                infoText.text = "SHOP";
            }
        }
        else
        {
                //Debug.Log("not shop");
            Animator infoTextAnim = infoText.GetComponent<Animator>();
            infoTextAnim.SetTrigger("outro");
        }

        Debug.Log(currentStamina);

        if (Input.GetKeyDown(KeyCode.R))
        {
            DamagePlayer(25);
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            HealPlayer(10);
        }

        if (!isPlayerDead)
        {
            //Debug.Log(currentHealth);
        }
        else if (isPlayerDead) 
        {
            //Debug.Log("Player is Dead");
        }

        if (!isUsingStamina)
        {
            IncreaseStamina();
        }
    }

    public void DamagePlayer(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            isPlayerDead = true;
        }
    }

    public void HealPlayer(int amount)
    {
        currentHealth += amount;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }

    public void IncreaseStamina()
    {
        if (!isUsingStamina)
        {
            if (currentStamina < maxStamina)
            {
                StartCoroutine(StaminaIncrease());
            }
            if (currentStamina > maxStamina)
            {
                currentStamina = maxStamina;
                StopStaminaIncrease();
            }

        }
    }

    public void DeacreaseStamina()
    {
        if (currentStamina > 0) 
        {
            currentStamina -= Time.deltaTime * 2;
            isUsingStamina = true; 
            if (currentStamina < 0)
            {
                currentStamina = 0;

            }
        }
    }

    IEnumerator StaminaIncrease()
    {
        yield return new WaitForSeconds(5);
        Debug.Log("waited");
        currentStamina += Time.deltaTime;
    }

    public void StopStaminaIncrease()
    {
        StopCoroutine(StaminaIncrease());
    }


}
