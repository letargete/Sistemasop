using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using base1;

namespace WebDemo
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //instanciar objeto de contexto
            base1.base1 db = new base1.base1();

            var lista = from i in db.GetTable<customer>()
                        where i.customer_type == "PHAR" && i.customer_id < 20620
                        select new {
                            ID_clientes = i.customer_id,
                            tipo_cliente=i.customer_type
                        };

            
            GridView1.DataSource = lista;
            GridView1.DataBind();
            


        }
      
  
    }
}






