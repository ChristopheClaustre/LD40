/***************************************************/
/***  INCLUDE               ************************/
/***************************************************/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/***************************************************/
/***  THE CLASS             ************************/
/***************************************************/
public class VerresManager :
    MonoBehaviour
{
    #region Property
    /***************************************************/
    /***  PROPERTY              ************************/
    /***************************************************/

    /********  PUBLIC           ************************/

    /********  PROTECTED        ************************/

    #endregion


    #region Attributes
    /***************************************************/
    /***  ATTRIBUTES            ************************/
    /***************************************************/

    /********  INSPECTOR        ************************/

    /********  PROTECTED        ************************/

    /********  PRIVATE          ************************/
    [SerializeField]
    private int m_nbVerreActif = 0;

    private List<GameObject> m_listVerres = new List<GameObject>();


    #endregion
    #region Methods
    /***************************************************/
    /***  METHODS               ************************/
    /***************************************************/

    /********  UNITY MESSAGES   ************************/

    // Use this for initialization
    private void Start()
    {
        foreach (Transform child in transform)
        {
            m_listVerres.Add(child.gameObject);
        }
        resetVerre();
    }

    // Update is called once per frame
    private void Update()
    {
    }

    /********  OUR MESSAGES     ************************/

    /********  PUBLIC           ************************/

    public void addVerre()
    {
        if (m_nbVerreActif < m_listVerres.Count)
        {
            m_listVerres[m_nbVerreActif].SetActive(true);
            m_nbVerreActif++;
        }
    }

    public void resetVerre()
    {
        m_nbVerreActif = 0;
        foreach(GameObject verre in m_listVerres)
        {
            verre.SetActive(false);
        }
    }

    /********  PROTECTED        ************************/

    /********  PRIVATE          ************************/

    #endregion
}
