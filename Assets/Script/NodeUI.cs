using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NodeUI : MonoBehaviour
{
    public GameObject ui;
    private node target;
    public TextMeshProUGUI upgradeCost;
    // public Button upgradeButton;


    public void SetTarget (node _target)
    {
        target = _target;
        transform.position = target.GetBuildPosition();


        if (!target.isUpgraded)
        {
            upgradeCost.text = "$" + target.turretBlueprint.upgradeCost;
            // upgradeButton.interactactable = true;
        }
        else{
            upgradeCost.text = "DONE";
            // upgradeButton.interactactable = false;
        }


        ui.SetActive(true);
    }
    public void Hide ()
    {
        ui.SetActive(false);
    }
    public void Upgrade ()
    {
        target.UpgradeTurret();
        BuildManager.instance.DeselectNode();
    }

}
