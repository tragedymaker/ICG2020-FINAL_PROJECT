using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class show_money : MonoBehaviour
{
    [SerializeField] planter planter;
    // Update is called once per frame
    public void Update()
    {
        GetComponent<Text>().text = "" + planter.money;
    }
}
