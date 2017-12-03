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
    private float m_fearEffect = 30;
    [SerializeField]
    private bool m_deadlyTrap;

    #endregion
    #region Methods
    /***************************************************/
    /***  METHODS               ************************/
    /***************************************************/

    /********  UNITY MESSAGES   ************************/

    // Use this for initialization
    private void Start()
    {

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
                ONEGameState.Instance.AddFear(m_fearEffect);
            }
        }
    }
    

    /********  OUR MESSAGES     ************************/

    /********  PUBLIC           ************************/

    /********  PROTECTED        ************************/

    /********  PRIVATE          ************************/
    #endregion
}
