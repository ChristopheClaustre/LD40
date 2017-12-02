/***************************************************/
/***  INCLUDE               ************************/
/***************************************************/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/***************************************************/
/***  THE CLASS             ************************/
/***************************************************/
public class CarControl : 
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
    private float m_vitesse = 1.0f;
    [SerializeField]
    private float m_maxPositionLeft = 100.0f;
    [SerializeField]
    private float m_maxPositionRight = 100.0f;
    [SerializeField]
    [Range(-1.0f, 1.0f)]
    private float m_direction = 0.0f;

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
        moveCar(m_direction);
    }

    /********  OUR MESSAGES     ************************/

    /********  PUBLIC           ************************/

    /********  PROTECTED        ************************/

    /********  PRIVATE          ************************/

    /*Change the car direction  
    -1 > 0 -> left 
    0      -> straight 
    0 < 1  -> right  
    */
    private void moveCar(float p_direction)
    {
        float newXValue, mouvement;
        mouvement = p_direction * m_vitesse * Time.deltaTime;
        mouvement += 0.5f;
        newXValue = transform.position.x + Mathf.Lerp(-100, 100, mouvement);
        newXValue = Mathf.Clamp(newXValue, -m_maxPositionLeft, m_maxPositionRight);
        transform.position = new Vector3(newXValue, transform.position.y, transform.position.z);
    }

    #endregion
}
