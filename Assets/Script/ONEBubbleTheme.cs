﻿/***************************************************/
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
        public Sprite clothesImage;
        public bool isThemeNormal;
        public bool isThemeFear;

        //public override bool Equals(object obj)
        //{
        //    if (!(obj is Theme))
        //        return false;

        //    Theme mys = (Theme)obj;
        //    return mys.themeName == themeName;
        //}
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

    public int NbrTheme()
    {
        return m_themes.Count;
    }

    public Theme getRandomNormalTheme()
    {
        List<Theme> normalThemeList = m_themes.FindAll(findNormalTheme);
        return normalThemeList[UnityEngine.Random.Range(0, normalThemeList.Count)];

    }

    public Theme getRandomShoutTheme()
    {
        List<Theme> fearThemeList = m_themes.FindAll(findFearTheme);
        return fearThemeList[UnityEngine.Random.Range(0, fearThemeList.Count)];
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
