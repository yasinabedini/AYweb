using RestSharp;

namespace AYweb.Application.Senders;

public static class Sms
{
    public static void SnedRegisterSms(string mobile, string code)
    {
        var client = new RestClient("http://188.0.240.110/api/select");
        var request = new RestRequest(Method.POST);
        request.AddHeader("cache-control", "no-cache");
        request.AddHeader("Content-Type", "application/json");
        request.AddParameter("undefined", "{\"op\" : \"pattern\"" +
                   ",\"user\" : \"09106966244\"" +
                   ",\"pass\":  \"Faraz@4421359831\"" +
                   ",\"fromNum\" : \"+98EVENT\"" +
                   $",\"toNum\": \"{mobile}\"" +
                   $",\"patternCode\": \"diyufzcqhhxajo4\"" +
                   ",\"inputData\" : [{\"code\":\"" + code + "\"}]}"
                   , ParameterType.RequestBody);
        IRestResponse response = client.Execute(request);
    }


    public static void SendNewPassword(string mobile, string password)
    {
        var client = new RestClient("http://188.0.240.110/api/select");
        var request = new RestRequest(Method.POST);
        request.AddHeader("cache-control", "no-cache");
        request.AddHeader("Content-Type", "application/json");
        request.AddParameter("undefined", "{\"op\" : \"pattern\"" +
                   ",\"user\" : \"09153329600\"" +
                   ",\"pass\":  \"Faraz@0702617881\"" +
                   ",\"fromNum\" : \"+98EVENT\"" +
                   $",\"toNum\": \"{mobile}\"" +
                   $",\"patternCode\": \"videdlas73zcard\"" +
                   ",\"inputData\" : [{\"code\":\"" + password + "\"}]}"
                   , ParameterType.RequestBody);
        IRestResponse response = client.Execute(request);
    }
    public static void WellCome(string mobile, string username)
    {
        var client = new RestClient("http://188.0.240.110/api/select");
        var request = new RestRequest(Method.POST);
        request.AddHeader("cache-control", "no-cache");
        request.AddHeader("Content-Type", "application/json");
        request.AddParameter("undefined", "{\"op\" : \"pattern\"" +
                   ",\"user\" : \"09106966244\"" +
                   ",\"pass\":  \"Faraz@4421359831\"" +
                   ",\"fromNum\" : \"+98EVENT\"" +
                   $",\"toNum\": \"{mobile}\"" +
                   $",\"patternCode\": \"hvkr7fs8gmcz60v\"" +
                   ",\"inputData\" : [{\"name\":\"" + username + "\"}]}"
                   , ParameterType.RequestBody);
        IRestResponse response = client.Execute(request);
    }
    public static void PayCart(string mobile, string username)
    {
        var client = new RestClient("http://188.0.240.110/api/select");
        var request = new RestRequest(Method.POST);
        request.AddHeader("cache-control", "no-cache");
        request.AddHeader("Content-Type", "application/json");
        request.AddParameter("undefined", "{\"op\" : \"pattern\"" +
                   ",\"user\" : \"09106966244\"" +
                   ",\"pass\":  \"Faraz@4421359831\"" +
                   ",\"fromNum\" : \"+98EVENT\"" +
                   $",\"toNum\": \"{mobile}\"" +
                   $",\"patternCode\": \"d2wf25586uyfgvb\"" +
                   ",\"inputData\" : [{\"name\":\"" + username + "\"}]}"
                   , ParameterType.RequestBody);
        IRestResponse response = client.Execute(request);
    }
    public static void SentCart(string mobile, string username, string trackingCode)
    {
        var client = new RestClient("http://188.0.240.110/api/select");
        var request = new RestRequest(Method.POST);
        request.AddHeader("cache-control", "no-cache");
        request.AddHeader("Content-Type", "application/json");
        request.AddParameter("undefined", "{\"op\" : \"pattern\"" +
                   ",\"user\" : \"09106966244\"" +
                   ",\"pass\":  \"Faraz@4421359831\"" +
                   ",\"fromNum\" : \"+98EVENT\"" +
                   $",\"toNum\": \"{mobile}\"" +
                   $",\"patternCode\": \"dn5tyyx73c6dpug\"" +
                   ",\"inputData\" : [{\"name\":\"" + username + "\",\"code\":\"" + trackingCode + "\"}]}"
                   , ParameterType.RequestBody);
        IRestResponse response = client.Execute(request);
    }
    public static void CounselingRequest(string mobile, string username)
    {
        var client = new RestClient("http://188.0.240.110/api/select");
        var request = new RestRequest(Method.POST);
        request.AddHeader("cache-control", "no-cache");
        request.AddHeader("Content-Type", "application/json");
        request.AddParameter("undefined", "{\"op\" : \"pattern\"" +
                   ",\"user\" : \"09106966244\"" +
                   ",\"pass\":  \"Faraz@4421359831\"" +
                   ",\"fromNum\" : \"+98EVENT\"" +
                   $",\"toNum\": \"{mobile}\"" +
                   $",\"patternCode\": \"1ep2qpzc3q1zxpc\"" +
                   ",\"inputData\" : [{\"name\":\"" + username + "\"}]}"
                   , ParameterType.RequestBody);
        IRestResponse response = client.Execute(request);
    }
}
