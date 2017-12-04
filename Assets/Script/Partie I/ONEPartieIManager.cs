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

    public enum EnumEtape
    {
        eInit,
        eBonjour,
        eMonologue,
        eReponse,
        eRalage,
        eAurevoir,
        ePartieII,
        eNbEtape
    };

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

    [SerializeField] private Round m_currentRound;
    [SerializeField] private int m_numeroDeRound = 0; // << ébriété ??
    [SerializeField] private EnumEtape m_etape = EnumEtape.eBonjour;
    [SerializeField] private float m_dureeTransistion = 1;
    private float m_timer = 0;

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
        switch (m_etape)
        {
            case EnumEtape.eBonjour:
                m_timer -= Time.deltaTime;
                if (m_timer <= 0)
                {
                    
                }
                break;
            case EnumEtape.eMonologue:
                if (false) // fin monologue
                {
                    // afficher UI
                    //m_etape = EnumEtape.eReponse;
                }
                break;
            case EnumEtape.eReponse:
                if (Input.GetButton("Choose"))
                {
                    // cacher UI
                    m_currentRound.m_remainingQuestions--;

                    if (true == Input.GetAxis("Choose") > 0) // is Good Answer
                    {

                    }
                    else // Bad Answer
                    {
                        m_currentRound.m_remainingStrikes--;
                        m_timer = m_dureeTransistion;
                        // lancer ralage
                        m_etape = EnumEtape.eRalage;
                    }
                }
                //else if (m_currentRound.m_r)
                {

                }
                break;
            case EnumEtape.eAurevoir:
                break;
            case EnumEtape.ePartieII:
                break;
            default:
                break;
        }
        if (Input.GetAxis("Choose") > Mathf.Epsilon) // << Agree
        {
            if (m_etape == EnumEtape.eReponse)
            {
                if (true) // Good Answer
                {

                }
            }
        }
        else if (Input.GetAxis("Choose") < Mathf.Epsilon) // << Disagree
        {

        }
    }

    /********  OUR MESSAGES     ************************/

    /********  PUBLIC           ************************/

    public void NextStep()
    {
        switch (m_etape)
        {
            case EnumEtape.eBonjour:
                m_currentRound = GenerateRound(m_numeroDeRound);
                // TODO parle victime !!!
                m_etape = EnumEtape.eMonologue;
                break;
            case EnumEtape.eMonologue:
                // TODO afficher UI
                m_etape = EnumEtape.eReponse;
                break;
            case EnumEtape.eReponse:
                // TODO cacher UI
                if (m_currentRound.m_remainingQuestions == 0)
                {
                    // TODO casse toi victime !!!
                    m_etape = EnumEtape.eAurevoir;
                }
                else
                {
                    m_currentRound.m_remainingQuestions--;
                    m_etape = EnumEtape.eMonologue;
                }
                break;
            case EnumEtape.eAurevoir:
                break;
            case EnumEtape.ePartieII:
                break;
            default:
                break;
        }
    }

    /********  PROTECTED        ************************/

    /********  PRIVATE          ************************/

    private Round GenerateRound(int p_difficulty)
    {
        return new Round()
        {
            m_numberOfQuestions = 3,
            m_numberOfStrikes = 3
        };
        // TODO générer aléatoirement ?
        // TODO générer en fonction de la vitesse
    }

    #endregion
}
