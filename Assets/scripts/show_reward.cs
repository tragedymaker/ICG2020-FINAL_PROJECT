using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class show_reward : MonoBehaviour
{

    public void show(string a)
    {
        GetComponent<Text>().text =a;
    }
}
