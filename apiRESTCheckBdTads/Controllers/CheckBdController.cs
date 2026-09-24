using System.Web.Http;
using apiRESTCheckBdTads.Models;
using Newtonsoft.Json.Linq;

namespace apiRESTCheckBdTads.Controllers
{
    public class CheckBdController : ApiController
    {
        [HttpGet]
        [Route("tads/checkbd/checkbdmysql")]
        public clsApiStatus checkBdMysql()
        {
            // -------------------------------------
            clsApiStatus objRespuesta = new clsApiStatus();
            JObject jsonResp = new JObject();
            // -------------------------------------
            // Ejecución del método de conexión
            clsCheckBd objCheckBd = new clsCheckBd();
            objCheckBd.checkBd();
            // -------------------------------------
            // Validar resultado de la ejecución
            objRespuesta.statusExec = (objCheckBd.ban == 1);
            objRespuesta.ban = objCheckBd.ban;
            objRespuesta.msg = objCheckBd.statusMsg;
            jsonResp.Add("msgData", objCheckBd.statusMsg);
            objRespuesta.datos = jsonResp;
            // -------------------------------------
            return objRespuesta;
        }
    }
}