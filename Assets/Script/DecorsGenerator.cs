/***************************************************/
/***  INCLUDE               ************************/
/***************************************************/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/***************************************************/
/***  THE CLASS             ************************/
/***************************************************/
public class DecorsGenerator :
    MonoBehaviour
{
    #region Attributes
    /***************************************************/
    /***  ATTRIBUTES            ************************/
    /***************************************************/

    /********  INSPECTOR        ************************/

    /********  PROTECTED        ************************/

    /********  PRIVATE          ************************/

    [SerializeField] private Rect m_zoneApparition;
    [SerializeField] private Rect m_zoneDeplacement;
    [SerializeField] private float m_vitesse = 1.0f;
    [SerializeField] private List<GameObject> m_decors = new List<GameObject>();
    [SerializeField] private Vector2 m_Ecart;
    [SerializeField] private List<GameObject> m_generatedDecors = new List<GameObject>();

    #endregion
    #region Methods
    /***************************************************/
    /***  METHODS               ************************/
    /***************************************************/

    /********  UNITY MESSAGES   ************************/

    // Use this for initialization
    private void Start()
    {
        if (!m_zoneDeplacement.Contains(m_zoneApparition.min)
            || !m_zoneDeplacement.Contains(m_zoneApparition.max))
        {
            Debug.Log("'Zone Apparition' doit être contenu dans 'Zone Deplacement'");
        }
    }

    // Update is called once per frame
    private void Update()
    {
        MoveDecors();
    }

    private void FixedUpdate()
    {
        GenerateDecors();
        CleanDecors();
    }

    /********  OUR MESSAGES     ************************/

    /********  PUBLIC           ************************/

    /********  PROTECTED        ************************/

    /********  PRIVATE          ************************/
    
    private Vector3 GeneratePosition()
    {
        return new Vector3()
        {
            x = Random.Range(m_zoneApparition.x, m_zoneApparition.xMax),
            y = 0,
            z = Random.Range(m_zoneApparition.y, m_zoneApparition.yMax)
        };
    }

    private void GenerateDecors()
    {
        float realEcart = Random.Range(m_Ecart.x, m_Ecart.y);
        Vector3 nouvellePosition = GeneratePosition();
        if (m_generatedDecors.TrueForAll(d => Vector3.Distance(d.transform.position, nouvellePosition) > realEcart))
            GenerateOneDecors(nouvellePosition);
    }

    private void GenerateOneDecors(Vector3 p_nouvellePosition)
    {
        if (m_decors.Count == 0)
            return;

        GameObject nouveau = Instantiate(m_decors[Random.Range(0, m_decors.Count - 1)], this.transform);
        nouveau.transform.position = p_nouvellePosition;
        m_generatedDecors.Add(nouveau);
    }

    private void MoveDecors()
    {
        foreach (GameObject decors in m_generatedDecors)
        {
            Vector3 position = decors.transform.position;
            position.z += m_vitesse;
            decors.transform.position = Vector3.Lerp(decors.transform.position, position, Time.deltaTime);
        }
    }

    private void CleanDecors()
    {
        int i = 0;
        while (i < m_generatedDecors.Count)
        {
            GameObject decors = m_generatedDecors[i];

            Vector2 vector = new Vector2()
            {
                x = decors.transform.position.x,
                y = decors.transform.position.z
            };
            if (!m_zoneDeplacement.Contains(vector))
            {
                m_generatedDecors.Remove(decors);
                Destroy(decors);
            }
            else
            {
                ++i;
            }
        }
    }

    #endregion
}
