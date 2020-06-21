using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Picker : MonoBehaviour
{
    GameObject m_ClickedObject;
    public cameracenter cameracenter;
    public int weapon_level = 1;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(!cameracenter.PlantMode)
        {
            if (Input.GetMouseButtonDown(0))
            {
                FireRaycast();
            }
            else if (Input.GetMouseButtonUp(0))
            {
                RecoverClickedObject();
            }
        }
        

    }


    void FireRaycast()
    {
        Ray ray = cameracenter.camera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            MeshRenderer renderer = hit.collider.GetComponent<MeshRenderer>();
            monster_chicken monster1= hit.collider.GetComponent<monster_chicken>();
            monster_kiwi monster2 = hit.collider.GetComponent<monster_kiwi>();
            monster_langset monster3 = hit.collider.GetComponent<monster_langset>();
            if (monster1 != null)
            {
                monster1.blood -= weapon_level;
                renderer.material.color = Color.red;
                m_ClickedObject = hit.collider.gameObject;
            }
            else if (monster2 != null)
            {
                monster2.blood -= weapon_level;
                renderer.material.color = Color.red;
                m_ClickedObject = hit.collider.gameObject;
            }
            else if (monster3 != null)
            {
                monster3.blood -= weapon_level;
                renderer.material.color = Color.red;
                m_ClickedObject = hit.collider.gameObject;
            }
        }
    }

    void RecoverClickedObject()
    {
        if (m_ClickedObject != null)
        {
            m_ClickedObject.GetComponent<MeshRenderer>().material.color = Color.white;
            m_ClickedObject = null;
        }
    }
}
