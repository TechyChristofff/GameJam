using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using System.IO;

public class SlideShot : MonoBehaviour {

    Texture[] textures = null;

    int textLoop = 0;
    string[] allPictures = null;
	// Use this for initialization
	void Start () {
        foreach (string str in Directory.GetFiles(Application.dataPath + "/ScreenCaptures"))
        {
            File.Delete(str);
        }
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if(Input.GetKeyDown(KeyCode.K))
        {
            textures = GetAtPath<Texture>("ScreenCaptures");
        }

        if(textures != null)
        {
            if (textures.Length != 0)
            {
                this.GetComponent<Renderer>().material.SetTexture(textLoop, textures[textLoop]);
                textLoop++;
            }
        }
	}

    public static T[] GetAtPath<T>(string path)
    {
        ArrayList al = new ArrayList();
        string[] fileEntries = Directory.GetFiles(Application.dataPath + "/" + path);

        foreach(string fileName in fileEntries)
        {
            int assetPathindex = fileName.IndexOf("Assets");
            string localPath = fileName.Substring(assetPathindex);

            Object t = AssetDatabase.LoadAssetAtPath(localPath, typeof(T));

            if (t != null)
                al.Add(t);
        }

        T[] result = new T[al.Count];
        for (int i = 0; i < al.Count; i++)
            result[i] = (T)al[i];

        return result;
    }
}
