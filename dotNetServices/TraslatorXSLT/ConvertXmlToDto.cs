using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ProveedoresCore.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace TraslatorXSLT
{
    public class ConvertXmlToDto : IConvertXmlToDto
    {
        public async Task<IList<ProductoDTO>> ConvertToProductList(string xml, string template)
        {
            IList<ProductoDTO> objetoLocal = new List<ProductoDTO>();
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(xml);
                string jsonT = JsonConvert.SerializeXmlNode(doc, Newtonsoft.Json.Formatting.None, true);                
                string FirstString = "[";
                string LastString = "]";
                int Pos1 = jsonT.IndexOf(FirstString) + FirstString.Length;
                int Pos2 = jsonT.IndexOf(LastString);
                string FinalString = "{\r\n\"data\": " + FirstString + jsonT.Substring(Pos1, Pos2 - Pos1) + LastString + "\r\n}";
                var routes_list = JsonConvert.DeserializeObject<Dictionary<string, object>>(FinalString);
                
                foreach (var item in routes_list)
                {
                    try
                    {
                        for (int i = 0; i < ((JArray)item.Value).Count; i++)
                        {
                            string plantilla = template;
                            var jsonValues = JsonConvert.DeserializeObject<Dictionary<string, object>>(((JArray)item.Value)[i].ToString());
                            foreach (var json in jsonValues)
                            {
                                string pattern = @"\b" + json.Key + @"\b";
                                plantilla = Regex.Replace(plantilla, "@" + pattern, json.Value.ToString());
                            }
                            var productoDto = JsonConvert.DeserializeObject<ProductoDTO>(plantilla);
                            objetoLocal.Add(productoDto);
                        }
                    }
                    catch (Exception exc)
                    {
                        throw new Exception("Se produjo un error en la conversión: " + exc.Message);
                    }
                }                
            }
            catch (Exception exc)
            {
                throw exc;
            }
            return await Task.FromResult(objetoLocal);
        }

        public async Task<OrdenesDTO> ConvertToOrdersList(string xml, string template)
        {
            OrdenesDTO objetoLocal = new OrdenesDTO();
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(xml);
                string jsonT = JsonConvert.SerializeXmlNode(doc, Newtonsoft.Json.Formatting.None, true);

                JToken jObject = JToken.Parse(jsonT);                
                
                var templateJson = JsonConvert.DeserializeObject<Dictionary<string, object>>(template);

                string plantilla = template;
                foreach (var item in templateJson)
                {
                    try
                    {
                        JToken result = jObject.SelectToken(item.Value.ToString());
                        JToken temp = result;

                        //jObject.SelectToken("s:Body").SelectToken("PonerOrdenExternaResponse").SelectToken("PonerOrdenExternaResult")["a:numeroOrden"].ToString();
                        
                        if (temp != null && temp.Type == JTokenType.String)
                        {
                            if (!string.IsNullOrEmpty(temp.ToString()))
                            {
                                string pattern = @"\b" + item.Value.ToString() + @"\b";
                                plantilla = Regex.Replace(plantilla, pattern, temp.ToString());
                            }                            
                        }
                        else
                        {
                            jObject = temp != null ? temp : jObject;
                            continue;
                        }                        
                    }
                    catch (Exception exc)
                    {
                        continue;
                    }
                }
                objetoLocal = JsonConvert.DeserializeObject<OrdenesDTO>(plantilla);
            }
            catch (Exception exc)
            {
                throw exc;
            }
            return await Task.FromResult(objetoLocal);
        }
    }
}
