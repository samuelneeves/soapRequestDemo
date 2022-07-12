using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Xml;

namespace SOAPRequestDemo
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Calling NumberConversion SOAP API... Sending number 500 to be converted to text");
            Console.WriteLine();
            var clientConversion = new RestClient("https://www.dataaccess.com/webservicesserver/NumberConversion.wso");
            var requestConversion = new RestRequest();
            requestConversion.Method = Method.Post;
            requestConversion.AddHeader("Content-Type", "text/xml; charset=utf-8");
            var body = @"<?xml version=""1.0"" encoding=""utf-8""?>" + "\n" +
            @"<soap:Envelope xmlns:soap=""http://schemas.xmlsoap.org/soap/envelope/"">" + "\n" +
            @"  <soap:Body>" + "\n" +
            @"    <NumberToWords xmlns=""http://www.dataaccess.com/webservicesserver/"">" + "\n" +
            @"      <ubiNum>500</ubiNum>" + "\n" +
            @"    </NumberToWords>" + "\n" +
            @"  </soap:Body>" + "\n" +
            @"</soap:Envelope>";
            requestConversion.AddParameter("text/xml", body, ParameterType.RequestBody);
            RestResponse responseConversion = clientConversion.Execute(requestConversion);
            Console.WriteLine(responseConversion.Content);
            Console.WriteLine();
            Console.WriteLine("--------------------------");

            Console.WriteLine("Calling Calculator SOAP API... Dividing 100 by 5");
            Console.WriteLine();
            var clientCalc = new RestClient("http://www.dneonline.com/calculator.asmx");
            var requestCalc = new RestRequest();
            requestCalc.Method = Method.Post;
            requestCalc.AddHeader("Content-Type", "text/xml; charset=utf-8");
            requestCalc.AddHeader("SOAPAction", "http://tempuri.org/Divide");
            var body2 = @"<?xml version=""1.0"" encoding=""utf-8""?>" + "\n" +
            @"<soap:Envelope xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"" xmlns:soap=""http://schemas.xmlsoap.org/soap/envelope/"">" + "\n" +
            @"  <soap:Body>" + "\n" +
            @"    <Divide xmlns=""http://tempuri.org/"">" + "\n" +
            @"      <intA>100</intA>" + "\n" +
            @"      <intB>5</intB>" + "\n" +
            @"    </Divide>" + "\n" +
            @"  </soap:Body>" + "\n" +
            @"</soap:Envelope>";
            requestCalc.AddParameter("text/xml", body2, ParameterType.RequestBody);
            RestResponse responseCalc = clientCalc.Execute(requestCalc);
            Console.WriteLine(responseCalc.Content);
            Console.WriteLine();
            Console.WriteLine("--------------------------");

            Console.WriteLine("Calling Country Info SOAP API... Returning list of countries");
            Console.WriteLine();
            var client = new RestClient("http://webservices.oorsprong.org/websamples.countryinfo/CountryInfoService.wso");
            var requestCountry = new RestRequest();
            requestCountry.Method = Method.Post;
            requestCountry.AddHeader("Content-Type", "text/xml; charset=utf-8");
            var body3 = @"<?xml version=""1.0"" encoding=""utf-8""?>" + "\n" +
            @"<soap12:Envelope xmlns:soap12=""http://www.w3.org/2003/05/soap-envelope"">" + "\n" +
            @"  <soap12:Body>" + "\n" +
            @"    <ListOfCountryNamesByName xmlns=""http://www.oorsprong.org/websamples.countryinfo"">" + "\n" +
            @"    </ListOfCountryNamesByName>" + "\n" +
            @"  </soap12:Body>" + "\n" +
            @"</soap12:Envelope>";
            requestCountry.AddParameter("text/xml", body3, ParameterType.RequestBody);
            RestResponse response = client.Execute(requestCountry);
            Console.WriteLine(response.Content);
            Console.WriteLine();
            Console.WriteLine("--------------------------");
        }
    }
}