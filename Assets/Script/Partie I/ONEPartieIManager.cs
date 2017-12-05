/***************************************************/
/***  INCLUDE               ************************/
/***************************************************/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/***************************************************/
/***  THE CLASS             ************************/
/***************************************************/
public class ONEPartieIManager :
    MonoBehaviour
{
    #region Sub-classes/enum
    /***************************************************/
    /***  SUB-CLASSES/ENUM      ************************/
    /***************************************************/

    /********  PUBLIC           ************************/

    [System.Serializable]
    public class Round
    {
        [SerializeField] public int m_numberOfStrikes = 3;
        public int m_remainingStrikes = 3;
        [SerializeField] public int m_numberOfQuestions = 3;
        public int m_remainingQuestions = 3;
    }

    /********  PROTECTED        ************************/

    /********  PRIVATE          ************************/

    #endregion
    #region Property
    /***************************************************/
    /***  PROPERTY              ************************/
    /***************************************************/

    /********  PUBLIC           ************************/

    // Instance
    public static ONEPartieIManager Instance
    {
        get { return m_instance; }
    }

    public bool HasPlayerPlayed
    {
        get
        {
            return m_hasPlayerPlayed;
        }

        set
        {
            m_hasPlayerPlayed = value;
        }
    }

    public bool GoodResponse
    {
        get
        {
            return m_goodResponse;
        }

        set
        {
            this.m_goodResponse = value;
        }
    }

    public bool HasPlayerWon
    {
        get
        {
            return m_hasPlayerWon;
        }

        set
        {
            m_hasPlayerWon = value;
        }
    }

    public Round CurrentRound
    {
        get
        {
            return m_currentRound;
        }

        set
        {
            m_currentRound = value;
        }
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

    /********  INSPECTOR        ************************/

    /********  PROTECTED        ************************/

    /********  PRIVATE          ************************/

    [SerializeField] private List<Round> m_rounds = new List<Round>();
    [SerializeField] private Round m_currentRound = new Round();
    [SerializeField] private int m_numeroDeRound = 0; // << ébriété ??
    
    private bool m_hasPlayerPlayed = false;
    private bool m_goodResponse;
    private bool m_playerResponse;
    private bool m_hasPlayerWon = false;

    public VictimeGenerator m_victimeGenerator;
    public VerresManager m_verreManager;

    Victime currentVictime;
    private static ONEPartieIManager m_instance;
    

    #endregion
    #region Methods
    /***************************************************/
    /***  METHODS               ************************/
    /***************************************************/

    /********  UNITY MESSAGES   ************************/

    // Use this for initialization
    private void Start()
    {
        m_instance = this;
    }

    // Update is called once per frame
    private void Update()
    {
        if (m_hasPlayerPlayed)
        {
            if(m_goodResponse != m_playerResponse)
            {
                m_currentRound.m_remainingStrikes--;
            }
            m_currentRound.m_remainingQuestions--;
            m_numeroDeRound++;
        }

        if(m_currentRound.m_remainingStrikes > 0 && m_currentRound.m_remainingQuestions == 0)
        {
            m_hasPlayerWon = true;
        }
        else
        {
            m_hasPlayerWon = false;
        }
    }

    /********  OUR MESSAGES     ************************/

    /********  PUBLIC           ************************/

    public void generateVictime()
    {
        currentVictime = m_victimeGenerator.generateVictime();
        //Generate a victime reset round variable
        m_hasPlayerPlayed = false;
        m_hasPlayerWon = false;
        //m_currentRound = new Round();
        m_currentRound = m_rounds[Mathf.Min(m_numeroDeRound, m_rounds.Count - 1)];
        m_currentRound.m_remainingStrikes = m_currentRound.m_numberOfStrikes;
        m_currentRound.m_remainingQuestions = m_currentRound.m_numberOfQuestions;
    }

    public void startAConversation()
    {
        currentVictime.startDiscution();
    }

    public void goPartie2()
    {
        //Active scene partie II (with parameters ?) << TODO
    }

    public void victimeLeave()
    {
        m_numeroDeRound++;
        m_verreManager.addVerre();
    }

    public void sendAnswer(bool p_answer)
    {
        m_goodResponse = p_answer;
    }

    public void playerAnswer(bool p_answer)
    {
        m_playerResponse = p_answer;
        m_hasPlayerPlayed = true;
    }

    public bool isTheGoodAnswer()
    {
        return (m_goodResponse == m_playerResponse);
    }

    /********  PROTECTED        ************************/

    /********  PRIVATE          ************************/

    #endregion
}
