using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace RESTAPI;
public enum httpVerb
{
    GET,
    POST,
    PUT,
    DELETE
}

public enum authenticationType
{
    Basic,
    NTLM
}


class RestClient
{
    public string endPoint
    {
        get; set;
    }
    public httpVerb httpMethod
    {
        get; set;
    }
    public authenticationType authType
    {
        get; set;
    }
    public string userName
    {
        get; set;
    }
    public string userPassword
    {
        get; set;
    }
    public string postJSON
    {
        get; set;
    } //New Attribute

    public RestClient()
    {
        endPoint = string.Empty;
    }

    public string makeRequest()
    {
        string strResponseValue = string.Empty;
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(endPoint);
        request.Method = httpMethod.ToString();

        String authHeaer = System.Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes(userName + ":" + userPassword));
        request.Headers.Add("Authorization", "Basic " + authHeaer);


        //********* NEW CODE TO SUPPORT POSTING *********
        if (request.Method == "POST" && postJSON != string.Empty)
        {
            request.ContentType = "application/json"; //Really Important
            using (StreamWriter swJSONPayload = new StreamWriter(request.GetRequestStream()))
            {
                swJSONPayload.Write(postJSON);
                swJSONPayload.Close();
            }
        }

        HttpWebResponse response = null;

        try
        {
            response = (HttpWebResponse)request.GetResponse();
            //Proecess the resppnse stream... (could be JSON, XML or HTML etc..._
            using (Stream responseStream = response.GetResponseStream())
            {
                if (responseStream != null)
                {
                    using (StreamReader reader = new StreamReader(responseStream))
                    {
                        strResponseValue = reader.ReadToEnd();
                    }
                }
            }
        }
        catch (Exception ex)
        {
            strResponseValue = "{\"errorMessages\":[\"" + ex.Message.ToString() + "\"],\"errors\":{}}";
        }
        finally
        {
            if (response != null)
            {
                ((IDisposable)response).Dispose();
            }
        }
        return strResponseValue;
    }//End of makeRequest
}//End of Class

