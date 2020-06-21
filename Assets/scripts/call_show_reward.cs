using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class call_show_reward : MonoBehaviour
{
    [SerializeField] show_reward a;
    public void trigger()
    {
        if (transform.GetComponent<Dropdown>().value == 0)
            a.show("Choose one crop to plant.");
        else if (transform.GetComponent<Dropdown>().value == 1)
            a.show("Earn $5 per Yellow flower");
        else if (transform.GetComponent<Dropdown>().value == 2)
            a.show("Earn $15 per Blue flower");
        else if (transform.GetComponent<Dropdown>().value == 3)
            a.show("Earn $25 per Catcus");
    }
   
        
}
