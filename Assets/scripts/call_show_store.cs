using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class call_show_store : MonoBehaviour
{
    [SerializeField] show_reward a;
    [SerializeField] Picker picker;
    public void trigger()
    {
        if (transform.GetComponent<Dropdown>().value == 0)
            a.show("Decide how to spend your money^^");
        else if (transform.GetComponent<Dropdown>().value == 1)
            a.show("Spend $100 to accelerate growth of the Tree.");
        else if (transform.GetComponent<Dropdown>().value == 2)
            a.show("Spend "+ picker.weapon_level*200 + " to upgrade your weapon.");
        else if (transform.GetComponent<Dropdown>().value == 3)
            a.show("Spend $50 to regain 5 of ground energy value(HP).");
    }

}
