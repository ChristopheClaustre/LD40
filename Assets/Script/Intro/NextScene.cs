/***************************************************/
/***  INCLUDE               ************************/
/***************************************************/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/***************************************************/
/***  THE CLASS             ************************/
/***************************************************/
public class NextScene :
    MonoBehaviour
{
    #region Attributes
    /***************************************************/
    /***  ATTRIBUTES            ************************/
    /***************************************************/

    /********  INSPECTOR        ************************/
    
    /********  PROTECTED        ************************/

    /********  PRIVATE          ************************/

    [SerializeField] private string m_sceneName = "Partie II";
    [SerializeField] private Animator m_animator;
    [SerializeField, Range(0, 2)] private float m_timer = 1;
    private bool m_running = false;
    private bool m_orderSent = false;
    private float m_remainingTime;

    #endregion
    #region Methods
    /***************************************************/
    /***  METHODS               ************************/
    /***************************************************/

    /********  UNITY MESSAGES   ************************/

    // Use this for initialization
    private void Start()
    {
        if (m_animator)
            m_animator.SetBool("next", false);
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetButton("Validate") && ! m_running)
        {
            m_running = true;
            m_orderSent = false;
            m_remainingTime = m_timer;
            if (m_animator)
                m_animator.SetBool("next", true);
        }

        if (m_running)
        {
            if (m_remainingTime > 0)
            {
                m_remainingTime -= Time.deltaTime;
            }
            else if (! m_orderSent)
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene(m_sceneName);
                m_orderSent = true;
            }
        }
    }

    /********  OUR MESSAGES     ************************/

    /********  PUBLIC           ************************/

    /********  PROTECTED        ************************/

    /********  PRIVATE          ************************/

    #endregion
}
