/***************************************************/
/***  INCLUDE               ************************/
/***************************************************/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

/***************************************************/
/***  THE CLASS             ************************/
/***************************************************/
public class ONEBubbleTheme :
    MonoBehaviour
{

    #region Property
    /***************************************************/
    /***  PROPERTY              ************************/
    /***************************************************/

    /********  PUBLIC           ************************/

    // Instance
    public static ONEBubbleTheme Instance
    {
        get { return m_instance; }
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

    [System.Serializable]
    public struct Theme
    {
        public string themeName;
        public Sprite themeImage;
        public bool isThemeNormal;
        public bool isThemeFear;
    }
    public List<Theme> m_themes = new List<Theme>();
    private static ONEBubbleTheme m_instance;
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
    }

    // Update is called once per frame
    private void Update()
    {

    }
    /********  OUR MESSAGES     ************************/

    /********  PUBLIC           ************************/

    /********  PROTECTED        ************************/

    /********  PRIVATE          ************************/

    public Theme getRandomNormalBubble()
    {
        List<Theme> normalThemeList = m_themes.FindAll(findNormalTheme);
        if(normalThemeList.Count > 0 )
        {
            return normalThemeList[UnityEngine.Random.Range(0, normalThemeList.Count - 1)];
        }
        else
        {
            throw new Exception();
        }
    }

    public Theme getRandomShoutBubble()
    {
        List<Theme> fearThemeList = m_themes.FindAll(findFearTheme);
        if (fearThemeList.Count > 0)
        {
            return fearThemeList[UnityEngine.Random.Range(0, fearThemeList.Count - 1)];
        }
        else
        {
            throw new Exception();
        }
    }

    private bool findNormalTheme(Theme p_theme)
    {
        return p_theme.isThemeNormal;
    }

    private bool findFearTheme(Theme p_theme)
    {
        return p_theme.isThemeNormal;
    }


    #endregion
}
