using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using UtilitariosTraductor.JUST;

namespace UtilitariosTraductor.JSLT
{
    public class JslTransformClass
    {
        public static void Transformar(string jsonFile )
        {
            /*string inputJson = File.ReadAllText("ValidationInput.json");//read input from JSON file.;
            string schemaJsonX = File.ReadAllText("SchemaX.json");//read first schema from JSON file.;
            string schemaJsonY = File.ReadAllText("SchemaY.json");//read second input from JSON file.;

            JsonValidator validator = new JsonValidator(inputJson);//create instance 
                                                                   //of JsonValidator using the input.;
            validator.AddSchema("x", schemaJsonX);//Add first schema with prefix 'x'.;
            validator.AddSchema("y", schemaJsonY);//Add second schema with prefix 'y'.;

            validator.Validate();*/

            string input = File.ReadAllText("Input.json");
            string transformer = File.ReadAllText("DataTransformer.xml");
            string transformedString = DataTransformer.Transform(transformer, input);
            JsonTransformer jsonT = new JsonTransformer();
            string transformedString2 = jsonT.Transform(transformer, input);
        }
    }
}
