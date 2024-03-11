using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Player : MonoBehaviour
{
    public static Player instance;

    public int currentMoney;

    public float maxStamina;
    public float currentMaxStamina;
    private float currentStamina;

    public float maxHealth;
    private float currentHealth;

    public TextMeshProUGUI infoText;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        
    }

    void Update()
    {
        if (Physics.Raycast (transform.position, transform.TransformDirection(Vector3.forward), out RaycastHit hitInfo, 3.5f))
        {
            if (hitInfo.collider.gameObject.tag == "ShopArea")
            {
                Debug.Log("SHOOOPP");
                infoText.gameObject.SetActive(true);
                infoText.text = "SHOP";
            }
        }
        else
        {
                Debug.Log("not shop");
            Animator infoTextAnim = infoText.GetComponent<Animator>();
            infoTextAnim.SetTrigger("outro");
        }
    }

    public void DamagePlayer(int damage)
    {

    }

    public void HealPlayer(int amount)
    {

    }

    public void IncreaseStamina()
    {

    }

    public void DeacreaseStamina()
    {

    }


}
