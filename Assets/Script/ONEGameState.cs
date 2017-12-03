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

    // Instance
    public static ONEGameState Instance
    {
        get { return m_instance; }
    }

    // paramètre de la partie
    public int AlcoolState
    {
        get { return m_alcoolState; }
    }
    public int PassengerAlcoolState
    {
        get { return m_passengerAlcoolState; }
    }
    public float PassengerFearState
    {
        get { return m_passengerFearState; }
    }
    public int MaxPassengerFearState
    {
        get { return m_maxPassengerFearState; }
    }
    public float MaxDistance
    {
        get { return m_maxDistance; }
    }
    public float CurrentDistance
    {
        get { return m_currentDistance; }
    }
    public float Vitesse
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
    public float MaxVitesseVoiture
    {
        get { return m_maxVitesseVoiture; }
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

    [SerializeField, Range(0, 10)] private int m_alcoolState = 0; // nombre de verre
    [SerializeField, Range(0, 10)] private int m_passengerAlcoolState = 0; // << dépends de m_alcoolState
    [SerializeField, Range(0, 100)] private float m_passengerFearState = 0;
    [SerializeField, Range(2000, 0)] private float m_maxDistance = 2000; // m
    private float m_currentDistance = 0; // m
    [SerializeField, Range(0, 30)] private float m_vitesse = 10; // m / s
    [SerializeField, Range(0, 10)] private int m_dirtyState = 0;
    [SerializeField, Range(50, 100)] private int m_maxPassengerFearState = 50; // << dépends de m_alcoolState
    [SerializeField, Range(0, 1)] private float m_maxVitesseVoiture = 0.5f; // m / s
    //[SerializeField, Range(0, 1)] private float m_vitesseAugmentationInput = 0.05f; // (% du max) / s
    [Header("Initialization Only :")]
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

        // clear input from last frame
        m_listInput.RemoveAt(0);

        // distance
        m_currentDistance += m_vitesse * Time.deltaTime;
    }

    /********  OUR MESSAGES     ************************/

    /********  PUBLIC           ************************/

    /********  PROTECTED        ************************/

    /********  PRIVATE          ************************/

    #endregion
}
