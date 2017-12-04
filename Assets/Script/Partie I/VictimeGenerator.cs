/***************************************************/
/***  INCLUDE               ************************/
/***************************************************/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/***************************************************/
/***  THE CLASS             ************************/
/***************************************************/
public class VictimeGenerator :
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
    private int m_maxRound = 3;
    [SerializeField]
    private int m_maxSentence = 5;
    [SerializeField]
    private int m_nbOtherTheme = 5;
    [SerializeField]
    private float m_vitesseBubble = 3.0f;
    
    public GameObject m_generetedVictime;
    private GameObject m_instanceVictime;
    Victime newVictime;

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
       
    }

   

    /********  OUR MESSAGES     ************************/

    /********  PUBLIC           ************************/

    public Victime generateVictime()
    {

        //Destroy last instance if existe
        Destroy(m_instanceVictime);
        //Craet new instance
        m_instanceVictime = Instantiate(m_generetedVictime, transform);
        newVictime = m_instanceVictime.GetComponent<Victime>();
        generateLoveList();
        generateOtherList();
        newVictime.VitesseBubble = m_vitesseBubble;
        newVictime.MaxDiscution = m_maxRound;
        newVictime.MaxBubble = m_maxSentence;
        //newVictime.transform.Find("Hat").gameObject.GetComponent<SpriteRenderer>().sprite = newVictime.m_hat.clothesImage;
        //newVictime.transform.Find("Top").gameObject.GetComponent<SpriteRenderer>().sprite = newVictime.m_top.clothesImage;

        return newVictime;
    }

    /********  PROTECTED        ************************/

    /********  PRIVATE          ************************/

    private void generateLoveList()
    {
        newVictime.addHatTheme(ONEBubbleTheme.Instance.getRandomHatTheme());
        //TODO uncomment next line when theme with top clothers exist
        //newVictime.addTopTheme(ONEBubbleTheme.Instance.getRandomTopTheme());
    }

    private void generateOtherList()
    {
        int i = 0;
        while(i < m_nbOtherTheme)
        {
            ONEBubbleTheme.Theme seletedTheme = ONEBubbleTheme.Instance.getRandomNormalTheme();
            if(!newVictime.LovedThemes.Exists(x => x.themeName == seletedTheme.themeName))
            {
                newVictime.addOtherTheme(seletedTheme);
                i++;
            }
        }
    }


    #endregion
}
