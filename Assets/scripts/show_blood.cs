using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class show_blood : MonoBehaviour
{
    [SerializeField] planter planter;
    void Update ()
    {
        if (planter.last_farm)
            GetComponent<Text>().text = "" + planter.last_farm.blood_tmp;
    }

}
