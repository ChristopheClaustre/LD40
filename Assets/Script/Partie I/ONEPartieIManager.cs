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

    public bool IsPlayerPlayed
    {
        get
        {
            return isPlayerPlayed;
        }

        set
        {
            isPlayerPlayed = value;
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

    public bool IsPlayerWin
    {
        get
        {
            return isPlayerWin;
        }

        set
        {
            isPlayerWin = value;
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

    [SerializeField] private Round m_currentRound = new Round();
    [SerializeField] private int m_numeroDeRound = 0; // << ébriété ??

    private bool isPlayerPlayed = false;
    private bool m_goodResponse;
    private bool m_playerResponse;
    private bool isPlayerWin = false;

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
        if(isPlayerPlayed)
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
            isPlayerWin = true;
        }
        else
        {
            isPlayerWin = false;
        }
    }

    /********  OUR MESSAGES     ************************/

    /********  PUBLIC           ************************/

    public void generateVictime()
    {
        currentVictime = m_victimeGenerator.generateVictime();
        //Generate a victime reset round variable
        isPlayerPlayed = false;
        isPlayerWin = false;
        m_currentRound = new Round();
    }

    public void startAConversation()
    {
        currentVictime.startDiscution();
    }

    public void goPartie2()
    {
        //Active scene partie II (with parameters ?)
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
        isPlayerPlayed = true;
    }

    public bool isTheGoodAnswer()
    {
        return (m_goodResponse == m_playerResponse);
    }

    /********  PROTECTED        ************************/

    /********  PRIVATE          ************************/


    #endregion
}
