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
    [SerializeField] private float m_largeurZoneApparition = 5;
    [SerializeField] private float m_longueurZoneApparition = 3;
    [SerializeField] private GameObject m_hotspotDisparition;
    [SerializeField] private float m_vitesse = 1.0f;
    [SerializeField] private bool m_useMyVitesse = false;
    [SerializeField] private List<GameObject> m_decors = new List<GameObject>();
    [SerializeField] private float m_ecartMin = 10;
    [SerializeField] private float m_ecartMax = 14;
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
        Sort();
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

    private void Sort()
    {
        m_generatedDecors.Sort(
            (d, d2) => Mathf.RoundToInt((d.transform.position.z - PointApparition.z) - (d2.transform.position.z - PointApparition.z))
            );
    }

    private void GenerateDecors()
    {
        if (m_decors.Count == 0)
            return;

        float ecart = Random.Range(m_ecartMin, m_ecartMax);
        if (m_generatedDecors.Count == 0 || m_generatedDecors[0].transform.position.z - PointApparition.z > ecart)
        {
            Vector3 vector = new Vector3()
            {
                x = PointApparition.x + Random.Range(-m_largeurZoneApparition / 2, m_largeurZoneApparition / 2),
                y = PointApparition.y,
                z = PointApparition.z + Random.Range(-m_longueurZoneApparition / 2, m_longueurZoneApparition / 2)
            };
            GenerateOneDecors(vector);
        }
    }

    private void GenerateOneDecors(Vector3 p_nouvellePosition)
    {
        GameObject nouveau = Instantiate(m_decors[Random.Range(0, m_decors.Count - 1)], transform);
        nouveau.transform.position = p_nouvellePosition;
        m_generatedDecors.Insert(0, nouveau);
    }

    private void MoveDecors()
    {
        foreach (GameObject decors in m_generatedDecors)
        {
            float vitesse = (m_useMyVitesse)? m_vitesse : ONEGameState.Instance.Vitesse;
            decors.transform.position += new Vector3(0, 0, vitesse * Time.deltaTime);
        }
    }

    private void CleanDecors()
    {
        int i = 0;
        while (i < m_generatedDecors.Count)
        {
            GameObject decors = m_generatedDecors[i];
            if (Vector3.Distance(decors.transform.position, PointApparition) > Vector3.Distance(PointDisparition, PointApparition))
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
