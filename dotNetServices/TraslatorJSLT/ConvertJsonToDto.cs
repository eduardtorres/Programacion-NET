using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ProveedoresCore.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TraslatorJSLT
{
    public class ConvertJsonToDto : IConvertJsonToDto
    {       
        public async Task<IList<ProductoDTO>> ConvertToProductList(Dictionary<string, object> routes_list, string template)
        {
            IList<ProductoDTO> objetoLocal = new List<ProductoDTO>();
            try
            {
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
    }
}
