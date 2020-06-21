using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmBehave : MonoBehaviour
{
    /*
    MeshRenderer m_MeshRenderer;
    Entity m_Entity;
    public Entity Entity { get { return m_Entity; } }
    // Start is called before the first frame update
    void Start()
    {
        m_MeshRenderer = this.GetComponent<MeshRenderer>();
    }


    private void OnDestroy()
    {
        if (m_Entity != null)
        {
            m_Entity.OnSelected -= HandleOnSelected;
            m_Entity.OnDeselected -= HandleOnDeselected;
            m_Entity.OnTaken -= HandleOnTaken;

        }
    }


    public void UpdateEntity(Entity entity)
    {

        //if (m_Entity != null)
        // {
        // m_Entity.OnSelected -= HandleOnSelected;
        // m_Entity.OnDeselected -= HandleOnDeselected;
        // m_Entity.OnTaken -= HandleOnTaken;
        // m_Entity = null;
        // }

        m_Entity = entity;
        m_Entity.OnSelected += HandleOnSelected;
        m_Entity.OnDeselected += HandleOnDeselected;
        m_Entity.OnTaken += HandleOnTaken;
    }

    private void HandleOnTaken(Entity entity)
    {
        GameObject.Destroy(this.gameObject);
    }

    private void HandleOnDeselected(Entity entity)
    {
        m_MeshRenderer.material.color = Color.white;
    }

    private void HandleOnSelected(Entity entity)
    {

        m_MeshRenderer.material.color = Color.yellow;
    }*/
}
