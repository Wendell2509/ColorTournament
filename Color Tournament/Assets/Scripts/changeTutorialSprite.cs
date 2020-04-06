using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeTutorialSprite : MonoBehaviour
{
    public GameObject t1;
    public GameObject t2;
    public GameObject t3;
    public GameObject t4;
    private int page = 1;

    // Start is called before the first frame update
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
        if (page == 1)
        {
            t1.SetActive(true);
            t2.SetActive(false);
            t3.SetActive(false);
            t4.SetActive(false);
        } else if (page == 2)
        {
            t1.SetActive(false);
            t2.SetActive(true);
            t3.SetActive(false);
            t4.SetActive(false);
        } else if (page == 3)
        {
            t1.SetActive(false);
            t2.SetActive(false);
            t3.SetActive(true);
            t4.SetActive(false);
        } else if (page == 4)
        {
            t1.SetActive(false);
            t2.SetActive(false);
            t3.SetActive(false);
            t4.SetActive(true);
        }

        print(page);
    }

    public void increasePage()
    {
        if (page < 4)
        {
            page++;
        } else
        {
            page = 1;
        }
    }
}