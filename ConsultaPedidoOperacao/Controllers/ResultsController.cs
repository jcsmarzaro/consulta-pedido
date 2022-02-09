using Microsoft.AspNetCore.Mvc;
using ConsultaPedidoOperacao.ClassesUtil;
using System.IO;
using System.Text;
using System.Web;


namespace ConsultaPedidoOperacao.Controllers
{
    public class Results : Controller
    {

        public async Task<string> ResultAsync(string pedido = "", string formato = "")
        {
            #region Busca Token e Millennium
            //Retorno TokenMillennium = await HttpHelper.Get<Retorno>("http://millennium.selia.com.br:6017/api/login");
            //if (formato == "Json")
            //{
            //    string UrlMillenium = "http://millennium.selia.com.br:6017/api/millenium_eco/pedido_venda/listapedidos?cod_pedidov=NUMPEDIDO&$format=json";
            //    UrlMillenium = UrlMillenium.Replace("NUMPEDIDO", pedido);
            //    String ResultadoJson = await HttpHelper.GetMillennium<String>(UrlMillenium, pedido, formato, TokenMillennium.session);
            //    return ResultadoJson;
            //}
            //else if(formato == "XML"){
            //    string UrlMillenium = "http://millennium.selia.com.br:6017/api/millenium_eco/pedido_venda/listapedidos?cod_pedidov=NUMPEDIDO&$format=xml";
            //    UrlMillenium = UrlMillenium.Replace("NUMPEDIDO", pedido);
            //    String ResultadoJson = await HttpHelper.GetMillennium<String>(UrlMillenium, pedido, formato, TokenMillennium.session);
            //    return ResultadoJson;
            //}
            #endregion

            if (pedido == null) { return "Preencha Pedido"; }
            else if (formato == "") { return "Preencha formato"; }

            Parametros body = new Parametros();

            body.cod_pedidov = pedido;
            body.format = formato;

            string Url = "https://new-integrator.selia.com.br/selia/get-order";

            String resultado = await HttpHelper.Post<Parametros>(Url, body, formato.ToString());

            return resultado;
        }

    }


}
