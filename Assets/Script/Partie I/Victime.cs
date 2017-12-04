/***************************************************/
/***  INCLUDE               ************************/
/***************************************************/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/***************************************************/
/***  THE CLASS             ************************/
/***************************************************/
public class Victime : 
    MonoBehaviour
{
    #region Property
    /***************************************************/
    /***  PROPERTY              ************************/
    /***************************************************/

    /********  PUBLIC           ************************/


    public float VitesseBubble
    {
        get
        {
            return m_vitesseBubble;
        }

        set
        {
            m_vitesseBubble = value;
        }
    }

    public int MaxDiscution
    {
        get
        {
            return m_maxDiscution;
        }

        set
        {
            m_maxDiscution = value;
        }
    }

    public int MaxBubble
    {
        get
        {
            return m_maxBubble;
        }

        set
        {
            m_maxBubble = value;
        }
    }

    public List<ONEBubbleTheme.Theme> LovedThemes
    {
        get
        {
            return m_lovedThemes;
        }
    }

    public List<ONEBubbleTheme.Theme> OtherThemes
    {
        get
        {
            return m_otherThemes;
        }
    }

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
    private List<ONEBubbleTheme.Theme> m_lovedThemes;
    [SerializeField]
    private List<ONEBubbleTheme.Theme> m_otherThemes;
    [SerializeField]
    private float m_vitesseBubble;
    [SerializeField]
    private int m_maxDiscution;
    [SerializeField]
    private int m_maxBubble;

    private int m_indexCurrentBubble = 0;
    private float m_timerBubble = 0.0f;
    private bool isInDiscution = false;
    private float m_answer = 0.0f;

    public GameObject m_bubble;
    private GameObject m_instanceBubble;


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
        if (isInDiscution)
        {
            if (Time.time > m_timerBubble)
            {
                Destroy(m_instanceBubble);
                m_timerBubble = Time.time + m_vitesseBubble;
                ONEBubbleTheme.Theme theme = getRandomTheme();
                showNormalBubble(theme);
                m_indexCurrentBubble++;
            }
            if(m_indexCurrentBubble >= m_maxBubble)
            {
                isInDiscution = false;
                Debug.Log(m_answer > 0);
                //TODO APPELLER FIN CONVERATION ON GAME MANAGER AVEC RESULTAT (ANSWER>0)

                //Reinitialize answer
                m_answer = 0.0f;
            }
        }
    }

    /********  OUR MESSAGES     ************************/

    /********  PUBLIC           ************************/

    public void startDiscution()
    {
        isInDiscution = true;
    }

    public void addLoveTheme(ONEBubbleTheme.Theme p_theme)
    {
        m_lovedThemes.Add(p_theme);
    }

    public void addOtherTheme(ONEBubbleTheme.Theme p_theme)
    {
        m_otherThemes.Add(p_theme);
    }
    /********  PROTECTED        ************************/

    /********  PRIVATE          ************************/

    private void showNormalBubble(ONEBubbleTheme.Theme p_theme)
    {
        m_instanceBubble = Instantiate(m_bubble, transform);
        if (m_instanceBubble)
        {
            GameObject contain = m_instanceBubble.transform.Find("containe").gameObject;
            contain.GetComponent<SpriteRenderer>().sprite = p_theme.themeImage;
        }
    }

    private ONEBubbleTheme.Theme getRandomTheme()
    {
        int randomIndex = UnityEngine.Random.Range(0, m_lovedThemes.Count + m_otherThemes.Count);

        if(randomIndex < m_lovedThemes.Count)
        {
            m_answer = m_answer + 1;
            return m_lovedThemes[randomIndex];
        }
        else
        {
            m_answer = m_answer - 1;
            return m_otherThemes[randomIndex - m_lovedThemes.Count];
        }
    }


    #endregion
}
