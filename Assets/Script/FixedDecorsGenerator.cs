/***************************************************/
/***  INCLUDE               ************************/
/***************************************************/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/***************************************************/
/***  THE CLASS             ************************/
/***************************************************/
public class FixedDecorsGenerator :
    MonoBehaviour
{
    #region Property
    /***************************************************/
    /***  PROPERTY              ************************/
    /***************************************************/

    /********  PUBLIC           ************************/

    /********  PROTECTED        ************************/

    protected Vector3 PointDisparition
    {
        get
        {
            if (m_hotspotDisparition)
                return m_hotspotDisparition.transform.position;

            return Vector3.zero;
        }
    }
    protected Vector3 PointApparition
    {
        get
        {
            if (m_hotspotApparition)
                return m_hotspotApparition.transform.position;

            return Vector3.zero;
        }
    }

    #endregion
    #region Attributes
    /***************************************************/
    /***  ATTRIBUTES            ************************/
    /***************************************************/

    /********  INSPECTOR        ************************/

    /********  PROTECTED        ************************/

    /********  PRIVATE          ************************/

    [SerializeField] private GameObject m_hotspotApparition;
    [SerializeField] private GameObject m_hotspotDisparition;
    [SerializeField] private float m_vitesse = 1.0f;
    [SerializeField] private bool m_useMyVitesse = false;
    [SerializeField] private List<GameObject> m_fixedDecors = new List<GameObject>();
    [SerializeField] private float m_longeurFixedDecors = 10;
    [SerializeField] private List<GameObject> m_generatedFixedDecors = new List<GameObject>();

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
        MoveDecors();
    }

    private void FixedUpdate()
    {
        Sort();

        GenerateDecors();
        CleanDecors();
    }

    /********  OUR MESSAGES     ************************/

    /********  PUBLIC           ************************/

    /********  PROTECTED        ************************/

    /********  PRIVATE          ************************/

    private void Sort()
    {
        m_generatedFixedDecors.Sort(
            (d, d2) => Mathf.RoundToInt((d.transform.position.z - PointApparition.z) - (d2.transform.position.z - PointApparition.z))
            );
    }

    private void GenerateDecors()
    {
        if (m_fixedDecors.Count == 0)
            return;

        if (m_generatedFixedDecors.Count == 0 || m_generatedFixedDecors[0].transform.position.z - PointApparition.z > m_longeurFixedDecors)
        {
            Vector3 vector = new Vector3()
            {
                x = PointApparition.x,
                y = PointApparition.y,
                z = m_generatedFixedDecors[0].transform.position.z - m_longeurFixedDecors
            };
            GenerateOneDecors(vector);
        }
    }

    private void GenerateOneDecors(Vector3 p_nouvellePosition)
    {
        GameObject nouveau = Instantiate(m_fixedDecors[Random.Range(0, m_fixedDecors.Count - 1)], transform);
        nouveau.transform.position = p_nouvellePosition;
        m_generatedFixedDecors.Add(nouveau);
    }

    private void MoveDecors()
    {
        foreach (GameObject decors in m_generatedFixedDecors)
        {
            float vitesse = (m_useMyVitesse) ? m_vitesse : ONEGameState.Instance.Vitesse;
            decors.transform.position += new Vector3(0, 0, vitesse * Time.deltaTime);
        }
    }

    private void CleanDecors()
    {
        int i = 0;
        while (i < m_generatedFixedDecors.Count)
        {
            GameObject decors = m_generatedFixedDecors[i];
            if (Vector3.Distance(decors.transform.position, PointApparition) > Vector3.Distance(PointDisparition, PointApparition))
            {
                m_generatedFixedDecors.Remove(decors);
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
