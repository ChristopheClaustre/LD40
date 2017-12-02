/***************************************************/
/***  INCLUDE               ************************/
/***************************************************/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/***************************************************/
/***  THE CLASS             ************************/
/***************************************************/
public class Obstacle :
    MonoBehaviour
{

    #region Attributes
    /***************************************************/
    /***  ATTRIBUTES            ************************/
    /***************************************************/

    /********  INSPECTOR        ************************/

    /********  PROTECTED        ************************/

    /********  PRIVATE          ************************/

    [SerializeField]
    private float m_obstacleWidth;
    [SerializeField]
    private float m_fearEffect;
    [SerializeField]
    private bool m_deadlyTrap;

    private BoxCollider m_obstacleCollider;

    #endregion
    #region Methods
    /***************************************************/
    /***  METHODS               ************************/
    /***************************************************/

    /********  UNITY MESSAGES   ************************/

    // Use this for initialization
    private void Start()
    {
        m_obstacleCollider = gameObject.AddComponent<BoxCollider>();
        m_obstacleCollider.size = new Vector3(m_obstacleWidth,1.0f,1.0f);
        m_obstacleCollider.isTrigger = true;
    }

    // Update is called once per frame
    private void Update()
    {
    }

    void OnTriggerEnter(Collider p_touchedCollider)
    {
        if (p_touchedCollider.CompareTag("Player"))
        {
            if (m_deadlyTrap)
            {
                //End game on game stat
            }
            else
            {
                //Increase fear on game stat (use m_fearEffect value)
                Debug.Log(m_fearEffect);
            }
        }
        
    }

    /********  OUR MESSAGES     ************************/

    /********  PUBLIC           ************************/

    /********  PROTECTED        ************************/

    /********  PRIVATE          ************************/

    #endregion
}
