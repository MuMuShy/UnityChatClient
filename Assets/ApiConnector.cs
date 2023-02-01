using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class ApiConnector : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(MakeRequest("http://localhost:5000/ask", "¶Ù§A¦n¶Ü?"));
    }

    private IEnumerator MakeRequest(string url, string postData)
    {
        Debug.Log("post:" + postData);
        WWWForm form = new WWWForm();
        form.AddField("question", postData);

        using (UnityWebRequest www = UnityWebRequest.Post(url, form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log("Form upload complete!");
                Debug.Log(www.downloadHandler.text);
            }
        }

        
    }
}
