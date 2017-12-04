/***************************************************/
/***  INCLUDE               ************************/
/***************************************************/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/***************************************************/
/***  THE CLASS             ************************/
/***************************************************/
public class BubbleGenerator :
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
    private float m_durationTime;
    [SerializeField]
    private float m_spacingTime;
    [SerializeField]
    private float m_startBubbleAt;

    private bool isShowingBubble = false;
    private float m_waitDurationTime = 0.0f;
    private float m_waitSpacingTime = 0.0f;

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
      generateNormalBubble();
    }
    /********  OUR MESSAGES     ************************/

    /********  PUBLIC           ************************/


    public void generateShoutBubble()
    {
        if (isShowingBubble)
        {
            DestroyObject(m_instanceBubble);
        }
        showFearBubble();
        m_waitDurationTime = Time.time + m_durationTime;
        isShowingBubble = true;
    }

    /********  PROTECTED        ************************/

    /********  PRIVATE          ************************/
    private void generateNormalBubble()
    {
        if (Time.time > m_startBubbleAt)
        {
            if (isShowingBubble)
            {
                if (Time.time > m_waitDurationTime)
                {
                    DestroyObject(m_instanceBubble);
                    isShowingBubble = false;
                    m_waitSpacingTime = Time.time + m_spacingTime;
                }
            }
            else
            {
                if (Time.time > m_waitSpacingTime)
                {
                    m_waitDurationTime = Time.time + m_durationTime;
                    showNormalBubble();
                    isShowingBubble = true;
                }
            }
        }
    }

    private void showNormalBubble()
    {
        m_instanceBubble = Instantiate(m_bubble, transform);
        if (m_instanceBubble)
        {
            GameObject contain = m_instanceBubble.transform.Find("containe").gameObject;
            contain.GetComponent<SpriteRenderer>().sprite = ONEBubbleTheme.Instance.getRandomNormalTheme().themeImage;
        }
    }

    private void showFearBubble()
    {
        m_instanceBubble = Instantiate(m_bubble, transform);
        if (m_instanceBubble)
        {
            GameObject contain = m_instanceBubble.transform.Find("containe").gameObject;
            contain.GetComponent<SpriteRenderer>().sprite = ONEBubbleTheme.Instance.getRandomShoutTheme().themeImage;
        }
    }

    #endregion
}
