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

    /*[SerializeField]
    private float m_vitesse = 1.0f;*/
    [SerializeField]
    private float m_maxPositionLeft = 100.0f;
    [SerializeField]
    private float m_maxPositionRight = 100.0f;
    /*[SerializeField]
    [Range(-1.0f, 1.0f)]
    private float m_direction = 0.0f;*/

    private bool m_isOnRight = false;
    private bool m_isOnLeft = false;
    private uint m_positionOnRoad;

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
        MoveCar(ONEGameState.Instance.CurrentFrameInput);
        m_positionOnRoad = computePositionOnRoad();
        ONEGameState.Instance.changeRoadFearFactor(m_positionOnRoad);
    }

    void OnTriggerStay(Collider p_touchedCollider)
    {
        if (p_touchedCollider.CompareTag("rightLane"))
        {
                m_isOnRight = true;
        }
        if (p_touchedCollider.CompareTag("leftLane"))
        {
                m_isOnLeft = true;
        }
    }

    void OnTriggerExit(Collider p_leavedCollider)
    {
        if (p_leavedCollider.CompareTag("rightLane"))
        {
            m_isOnRight = false;
        }
        if (p_leavedCollider.CompareTag("leftLane"))
        {
            m_isOnLeft = false;
        }
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
    private void MoveCar(float p_coeff)
    {
        float mouvement = p_coeff * ONEGameState.Instance.MaxVitesseVoiture * Time.deltaTime;

        Vector3 position = transform.position;
        position.x = Mathf.Clamp(transform.position.x + mouvement, -m_maxPositionLeft, m_maxPositionRight);

        transform.position = position;
    }

    private uint computePositionOnRoad()
    {
        if (m_isOnRight)
        {
            return 0;
        }
        else if (m_isOnLeft)
        {
            return 1;
        }
        else
        {
            return 2;
        }
    }

    #endregion
}
