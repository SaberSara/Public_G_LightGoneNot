using UnityEngine;
using System.Collections;
//Using XML 
using System.Xml;
//Using Lists
using System.Collections.Generic;

public class LevelHandler : MonoBehaviour {
    XmlDocument levelDoc;
    XmlNodeList levelist;
    List<string> levelArray;


    // Use this for initialization
    void Start()
    {

        levelArray = new List<string>();
        levelDoc = new XmlDocument();

        TextAsset xmlfile = Resources.Load("levels", typeof(TextAsset)) as TextAsset;
        levelDoc.LoadXml(xmlfile.text);
        levelist = levelDoc.GetElementsByTagName("level");
        foreach (XmlNode leveldata in levelist)
        {
            XmlNodeList levelinfo = leveldata.ChildNodes;
            foreach (XmlNode data in levelinfo)
            {
                if (data.Name == "setup")
                {
                    levelArray.Add(data.InnerText);
                }
            }

        }

        this.gameObject.GetComponent<Engine>().init(levelArray.Count);

    }

    public void loadLevel(int nr)
    {

        GameObject.Find("Canvas").GetComponent<Menu>().setLevelText(nr.ToString());

        string[] levString = levelArray[nr - 1].Split(',');
        foreach (string brick in levString)
        {
            GameObject.Find(brick).GetComponent<LightSwitch>().change();
        }



    }

    // Update is called once per frame
    void Update()
    {

    }
}

