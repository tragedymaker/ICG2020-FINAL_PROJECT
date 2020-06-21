using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    
    [SerializeField] planter planter;
    [SerializeField] Text m_MessageText;
    [SerializeField] GameObject m_Actions;
    [SerializeField] Dropdown m_Dropdown;
    [SerializeField] centertree centertree;
    [SerializeField] Picker picker;
    [SerializeField] Dropdown spend_dropdown;
    [SerializeField] show_reward a;
    // Start is called before the first frame update
    public void plant()
    {
        planter.Plant(m_Dropdown.value-1);
    }
    public void setActionVicible(bool visible)
    {
        m_Actions.SetActive(visible);
    }

    public void spend()
    {

        if(spend_dropdown.value==1)
        {
            if (planter.money >= 100)
            {
                centertree.irrigate();
                planter.money -= 100;
            }
            else
                sendmessage(0);
        }
        else if(spend_dropdown.value == 2)
        {
            if (planter.money >= (picker.weapon_level) * 200)
            {
                planter.money -= (picker.weapon_level) * 200;
                picker.weapon_level += 1;
            }
            else
                sendmessage(0);
        }
        else if (spend_dropdown.value == 3)
        {
            if (!planter.last_farm)
                sendmessage(1);
            else if (planter.money < 50)
                sendmessage(0);
            else
            {
                planter.money -= 50;
                planter.last_farm.blood += 5;
            }
        }
    }

    void sendmessage(int i)
    {
        if (i == 0)
            a.show("U don't have enough money.");
        else
            a.show("Plz select a ground first");
        //U don't have enough money.
    }
}
