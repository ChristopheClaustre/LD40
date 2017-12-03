/***************************************************/
/***  INCLUDE               ************************/
/***************************************************/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/***************************************************/
/***  THE CLASS             ************************/
/***************************************************/
public class ONEGameState :
    MonoBehaviour
{
    #region Sub-classes/enum
    /***************************************************/
    /***  SUB-CLASSES/ENUM      ************************/
    /***************************************************/

    /********  PUBLIC           ************************/

    /********  PROTECTED        ************************/

    /********  PRIVATE          ************************/

    #endregion
    #region Property
    /***************************************************/
    /***  PROPERTY              ************************/
    /***************************************************/

    /********  PUBLIC           ************************/

    public int AlcoolState
    {
        get { return m_alcoolState; }
    }
    public int PassengerAlcoolState
    {
        get { return m_passengerAlcoolState; }
    }
    public int PassengerFearState
    {
        get { return m_passengerFearState; }
    }
    public int MaxPassengerFearState
    {
        get { return m_maxPassengerFearState; }
    }
    public float RemainingDistance
    {
        get { return m_remainingDistance; }
    }
    public int Vitesse
    {
        get { return m_vitesse; }
    }
    public int DirtyState
    {
        get { return m_dirtyState; }
    }
    public float Lags
    {
        get { return m_lags; }
    }
    public float CurrentFrameInput
    {
        get { return m_listInput[0]; }
    }
    public static ONEGameState Instance
    {
        get { return m_instance; }
    }

    /********  PROTECTED        ************************/

    #endregion
    #region Constants
    /***************************************************/
    /***  CONSTANTS             ************************/
    /***************************************************/

    /********  PUBLIC           ************************/

    /********  PROTECTED        ************************/

    /********  PRIVATE          ************************/

    #endregion
    #region Attributes
    /***************************************************/
    /***  ATTRIBUTES            ************************/
    /***************************************************/

    /********  PROTECTED        ************************/

    /********  PRIVATE          ************************/

    [SerializeField, Range(0, 10)] private int m_alcoolState = 0;
    [SerializeField, Range(0, 10)] private int m_passengerAlcoolState = 0;
    [SerializeField, Range(100, 0)] private int m_passengerFearState = 0;
    [SerializeField, Range(2000, 0)] private float m_remainingDistance = 2000;
    [SerializeField, Range(0, 10)] private int m_vitesse = 0;
    [SerializeField, Range(0, 10)] private int m_dirtyState = 0;
    [Header("Initialization Only :")]
    [SerializeField, Range(50, 100)] private int m_maxPassengerFearState = 50;
    [SerializeField, Range(0.0f, 1.0f)] private float m_lags = 0;
    private List<float> m_listInput = new List<float>();

    private static ONEGameState m_instance;

    #endregion
    #region Methods
    /***************************************************/
    /***  METHODS               ************************/
    /***************************************************/

    /********  UNITY MESSAGES   ************************/

    private void Awake()
    {
        m_instance = this;
    }

    // Use this for initialization
    private void Start()
    {
        for (int i = 0; i < Mathf.RoundToInt(m_lags / Time.deltaTime) ; ++i) // << CACA !!!!!!!
        {
            m_listInput.Add(0);
        }
    }

    // Update is called once per frame
    private void Update()
    {
        // add new input
        m_listInput.Add(Input.GetAxis("Move car"));
        m_listInput.RemoveAt(0);

        // distance
        m_remainingDistance -= m_vitesse * Time.deltaTime;
    }

    /********  OUR MESSAGES     ************************/

    /********  PUBLIC           ************************/

    /********  PROTECTED        ************************/

    /********  PRIVATE          ************************/

    #endregion
}
