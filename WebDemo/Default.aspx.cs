using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using baseq;

namespace WebDemo
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //instanciar objeto de contexto
            baseq.@base db = new baseq.@base();

            var lista = from i in db.GetTable<Inventario2>()
                        //where i.customer_type == "PHAR" && i.customer_id < 20620
                        select new {
                            id = i.Id
                            ,Descripcion=i.Descripcion
                            ,Cantidad = i.Cantidad
                        };

            
            GridView1.DataSource = lista;
            GridView1.DataBind();
            


        }
      
  
    }
}






