using Newtonsoft.Json.Linq;

namespace UtilitariosTraductor.Selectables
{
    public interface ISelectableToken
    {
        string RootReference { get; }
        JToken Token { get; set; }

        JToken Select(string path);
    }
}
