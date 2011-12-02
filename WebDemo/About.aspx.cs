using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using baseq;


namespace WebDemo
{
    public partial class About : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
       

        protected void Button1_Click(object sender, EventArgs e)
        {
            baseq.@base bas = new baseq.@base();
            if (txtName1.Text == "" || TextBox1.Text == "")
            {
                txtName1.Text = "debe contener el producto";
                TextBox1.Text = "debe contener una cantidad";
            }
            else{
               try{
            
                Inventario2 inv = new Inventario2()
                {

                    Descripcion = txtName1.Text
                    ,
                    Cantidad = Convert.ToInt16(TextBox1.Text)
                };
                bas.Inventario2s.InsertOnSubmit(inv);
                bas.SubmitChanges();

                txtName1.Text = "";
                TextBox1.Text = "";
                 } catch  {

                     TextBox1.Text = "debe ser un numero";
                }
            }

        }
    }
}
