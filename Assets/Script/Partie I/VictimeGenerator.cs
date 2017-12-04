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

    private int m_nbLovedTheme = 1;
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
        if (ONEBubbleTheme.Instance.NbrTheme() < m_nbLovedTheme)
        {
            Debug.LogWarning("Pas assez de theme pour eviter les incoherences");
            m_nbLovedTheme = ONEBubbleTheme.Instance.NbrTheme() - 1;
        }
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

        //TODO Ajouter appel a l'habillage de la victime ICI

        return newVictime;
    }

    /********  PROTECTED        ************************/

    /********  PRIVATE          ************************/

    private void generateLoveList()
    {
        newVictime.addLoveTheme(ONEBubbleTheme.Instance.getRandomHatTheme());
        //newVictime.addLoveTheme(ONEBubbleTheme.Instance.getRandomTopTheme());
        //newVictime.addLoveTheme(ONEBubbleTheme.Instance.getRandomBottomTheme());
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
