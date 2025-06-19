using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CatBonkBehaviour : MonoBehaviour


{
    [Header("UI")]
    public TextMeshProUGUI BonksText;

    [Header("Bonk Settings")]
    public int bonks = 0;
    public int bonksPerClick = 1;
    public int autoBonksPerSecond = 0;

    [Header("Upgrade Costs")]
    public int upgradeClickCost = 50;
    public int upgradeAutoCost = 100;

    private float autoBonkTimer = 0f;


    // you start with 0
    void Start()
    {
        bonks = 0;
    }

    
    void Update()
    {
        // the text updates automatically after clicking
        BonksText.text = "You have " + bonks + " Bonks\n" +
                         "Bonks per click: " + bonksPerClick + "\n" +
                         "Bonks per second: " + autoBonksPerSecond;

        // auto bonking
        if (autoBonksPerSecond > 0)
        {
            autoBonkTimer += Time.deltaTime;
            if (autoBonkTimer >= 1f)
            {
                bonks += autoBonksPerSecond;
                autoBonkTimer = 0f;
            }
        }

    }

    private void AddClickListener(GameObject obj)
    {
        if (!obj.GetComponent<Collider2D>())
            obj.AddComponent<BoxCollider2D>();

        var clickHandler = obj.AddComponent<CatBonkHandler>();
        clickHandler.manager = this;



    }

    public void HandleClick()
    {
        bonks += bonksPerClick;
    }

    public void UpgradeBonksPerClick()
    {
        if (bonks >= upgradeClickCost)
        {
            bonks -= upgradeClickCost;
            bonksPerClick++;
            upgradeClickCost += 50; // Increase of cost cause capitalism
            Debug.Log("Upgraded Bonks per Click to: " + bonksPerClick);
        }
        else
        {
            Debug.Log("Not enough bonks to upgrade click power.");
        }
    }

    // Upgrade auto bonks per second
    public void UpgradeAutoBonks()
    {
        if (bonks >= upgradeAutoCost)
        {
            bonks -= upgradeAutoCost;
            autoBonksPerSecond++;
            upgradeAutoCost += 100; // capitalism
            Debug.Log("Upgraded Auto Bonks per Second to: " + autoBonksPerSecond);
        }
        else
        {
            Debug.Log("Not enough bonks to upgrade auto bonks.");
        }
    }

}
