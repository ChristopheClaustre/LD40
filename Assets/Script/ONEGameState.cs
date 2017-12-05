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
    [SerializeField, Range(50, 100)] private int m_maxPassengerFearState = 50; // << dépends de m_alcoolState
    [SerializeField, Range(2, 8)] private float m_vitesseDescenteFear = 5;
    [SerializeField, Range(0, 10)] private float m_maxVitesseVoiture = 1; // m / s
    [SerializeField, Range(0, 1)] private float m_leftRoadDescenteFearFactor = 0.5f; // Si voiture sur voie de gauche
    [SerializeField, Range(0, 1)] private float m_outOfRoadDescenteFearFactor = 0.0f;// Si voiture sur trottoire
    [Header("Initialization Only :")]
    [SerializeField, Range(0.0f, 1.0f)] private float m_lags = 0;
    private List<float> m_listInput = new List<float>();
    private float m_fearFactorRoadLane;
    
    [Header("Difficulty")]
    [SerializeField] private DecorsGenerator m_generatorToAccelerate;

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

        m_passengerAlcoolState = m_alcoolState;
        m_maxPassengerFearState = 50 + Mathf.RoundToInt(50 * (m_passengerAlcoolState / 10.0f));
    }

    // Use this for initialization
    private void Start()
    {
        m_lags = 0 + (1 * m_alcoolState / 10.0f);

        m_listInput.Add(0);
        for (int i = 0; i < Mathf.RoundToInt(m_lags / Time.deltaTime) ; ++i) // << CACA !!!!!!!
        {
            m_listInput.Add(0);
        }

        ApplyAlcoolEffect();
    }

    // Update is called once per frame
    private void Update()
    {
        ApplyAlcoolEffect();

        UpdateThings();

        AccelerateGenerator();

        if (m_passengerFearState > m_maxPassengerFearState)
        {
            // DEFEAT
            GetComponent<Animator>().enabled = true;
        }
        else if (m_currentDistance > m_maxDistance)
        {
            // VICTORY
            GetComponent<Animator>().enabled = true;
        }
    }

    /********  OUR MESSAGES     ************************/

    /********  PUBLIC           ************************/

    public void AddFear(float p_increment)
    {
        m_passengerFearState += p_increment;
    }

    public void changeRoadFearFactor(uint roadLane)
    {
        if(roadLane == 2)
        {
            m_fearFactorRoadLane = m_outOfRoadDescenteFearFactor;
        }
        else if (roadLane == 1)
        {
            m_fearFactorRoadLane = m_leftRoadDescenteFearFactor;
        }
        else
        {
            m_fearFactorRoadLane = 1.0f;
        }
    }
    /********  PROTECTED        ************************/

    /********  PRIVATE          ************************/

    private void ApplyAlcoolEffect()
    {
        Camera.main.fieldOfView = 80 + 20 * (m_alcoolState / 10.0f);
    }

    private void UpdateThings()
    {
        // add new input
        m_listInput.Add(Input.GetAxis("Move car"));

        // clear input from last frame
        m_listInput.RemoveAt(0);

        // distance
        m_currentDistance += m_vitesse * Time.deltaTime;

        // fear
        m_passengerFearState = Mathf.Max(0, m_passengerFearState - (m_vitesseDescenteFear * m_fearFactorRoadLane * Time.deltaTime));
    }

    private void AccelerateGenerator()
    {
        if (!m_generatorToAccelerate)
            return;

        m_generatorToAccelerate.DifficultyCoeff = m_currentDistance / m_maxDistance;
    }

    #endregion
}
