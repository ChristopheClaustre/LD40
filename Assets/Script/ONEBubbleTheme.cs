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

    #region Sub-classes/enum
    /***************************************************/
    /***  SUB-CLASSES/ENUM      ************************/
    /***************************************************/

    /********  PUBLIC           ************************/

    public enum typeClothers
    {
        eHat,
        eTop,
        eBottom,
        eNbTypeClothers
    };

    [System.Serializable]
    public struct Theme
    {
        public string themeName;
        public Sprite themeImage;
        public Sprite clothesImage;
        public bool isThemeNormal;
        public bool isThemeFear;
        public typeClothers typeOfClothes;
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

    public Theme getRandomHatTheme()
    {
        List<Theme> hatThemeList = m_themes.FindAll(findHatTheme);
        return hatThemeList[UnityEngine.Random.Range(0, hatThemeList.Count)];
    }

    public Theme getRandomTopTheme()
    {
        List<Theme> topThemeList = m_themes.FindAll(findTopTheme);
        return topThemeList[UnityEngine.Random.Range(0, topThemeList.Count)];
    }

    /********  PROTECTED        ************************/

    /********  PRIVATE          ************************/

    private bool findNormalTheme(Theme p_theme)
    {
        return p_theme.isThemeNormal;
    }

    private bool findFearTheme(Theme p_theme)
    {
        return p_theme.isThemeFear;
    }

    private bool findHatTheme(Theme p_theme)
    {
        return (p_theme.themeName != "Alcool" && p_theme.typeOfClothes == typeClothers.eHat);
    }

    private bool findTopTheme(Theme p_theme)
    {
        return (p_theme.themeName != "Alcool" && p_theme.typeOfClothes == typeClothers.eTop);
    }

    #endregion
}
