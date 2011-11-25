using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Linq;

namespace WebDemo.Code
{
    public class ServiceLayer
    {
        
        #region Operaciones Customer
        public List<customer> GetAllCustomers()
        {
            //1.- Se utiliza un bloque using, para instanciar el contexto de acceso a datos, para que no se deje conexiones abiertas a la BD.
            using (PuntoVentaDataContext oContext = new PuntoVentaDataContext())
            {
                //2.- Para trabajar con una tabla es necesario guardar la referencia en un objeto.
                var tableCustomers = oContext.GetTable<customer>();

                //3.- Para hacer una consulta se puede hacer de dos formas, esta es la primera
                //bloque try catch para capturar posibles errores, y no mandar el pantallazo de error a la interfaz
                try
                {
                    var query = from cust in tableCustomers
                                where cust.customer_type == "DCTR"
                                select cust;

                    List<customer> coleccionSalida = new List<customer>();
                    foreach (var item in coleccionSalida)
                    {
                        //llenar salida
                        customer c = new customer();
                        c.customer_id = item.customer_id;
                        c.customer_type = item.customer_type;
                        c.specialty_1 = item.specialty_1;
                        c.specialty_2 = item.specialty_2;
                        c.name_1 = item.name_1;
                        c.name_2 = item.name_2;
                        c.name_3 = item.name_3;
                        c.name_4 = item.name_4;
                        c.email = item.email;
                        c.RFC = item.RFC;
                        c.license = item.license;
                        c.status = item.status;
                        c.status_change_date = item.status_change_date;
                        c.creation_date = item.creation_date;
                        c.creator_territory_id = item.creator_territory_id;
                        c.creator_employee_id = item.creator_employee_id;
                        c.external_id_1 = item.external_id_1;
                        c.external_id_2 = item.external_id_2;
                        c.external_id_3 = item.external_id_3;
                        c.external_id_4 = item.external_id_4;
                        //TODO: Llenar demas propiedades...



                        //guardar en collecion de salida
                        coleccionSalida.Add(c);
                    }

                    //al final de foreach, ya se tiene llena la consulta
                    return coleccionSalida;
                }
                catch
                {
                    return null;
                }

            }
            
        }


        public customer GetCustomerById(int id)
        {
              using (PuntoVentaDataContext oContext = new PuntoVentaDataContext())
            {
               
                var tableCustomers = oContext.GetTable<customer>();
                  try{
                      var consulta = from customer in tableCustomers
                                  where customer.customer_id == id
                                  select customer;

                      return consulta.SingleOrDefault();
                      
                    // return consulta; 
                  }catch{
                         return null;
                      }

            //TODO hacer consulta que filtre por id, la salida es un customer
            
           
        }
        }

        public List<customer> GetCustomersByFilters(string name, string customer_type)
        {
            //TODO: hacer consulta por los dos filtros,
            using (PuntoVentaDataContext oContext = new PuntoVentaDataContext())
            {
                var tableCustomers = oContext.GetTable<customer>();

                try
                {
                    var filtrado_name = from customer in tableCustomers
                                        where customer.name_1 == name & customer.customer_type == customer_type
                                        select customer;

                    List<customer> coleccionfiltrado = new List<customer>();
                    foreach (var item in coleccionfiltrado)
                    {
                        //llenar salida
                        customer c = new customer();
                        c.customer_id = item.customer_id;
                        c.customer_type = item.customer_type;
                        c.specialty_1 = item.specialty_1;
                        c.specialty_2 = item.specialty_2;
                        c.name_1 = item.name_1;
                        c.name_2 = item.name_2;
                        c.name_3 = item.name_3;
                        c.name_4 = item.name_4;
                        c.email = item.email;
                        c.RFC = item.RFC;
                        c.license = item.license;
                        c.status = item.status;
                        c.status_change_date = item.status_change_date;
                        c.creation_date = item.creation_date;
                        c.creator_territory_id = item.creator_territory_id;
                        c.creator_employee_id = item.creator_employee_id;
                        c.external_id_1 = item.external_id_1;
                        c.external_id_2 = item.external_id_2;
                        c.external_id_3 = item.external_id_3;
                        c.external_id_4 = item.external_id_4;

                        coleccionfiltrado.Add(c);
                    }
                    return coleccionfiltrado;
                }
                catch
                {
                    return null;
                }
            }
        }
        public bool UpdateCustomer(int id, string name, string email)
        {
            //TODO: utilizar sintaxis para poder actualizar los dos campos que se pasan como parametro al metodo, con el id indicado. La sintaxis LINQ es simple, esta en el libro de ASP.NET
            using (PuntoVentaDataContext oContext = new PuntoVentaDataContext())
            {
                var tableCustomers = oContext.GetTable<customer>();
                try
                {
                    var actua = (from customer in tableCustomers
                                 where customer.customer_id == id
                                 select customer).Single();
                    actua.name_1 = name;
                    actua.email = email;
                    oContext.SubmitChanges();
                    return true;

                }
                catch
                {
                    return false;
                }
            }
            
        }

        public bool InsertCustomer(string name1, string customer_type, string specialty1, string specialty2)
        {
            //TODO: terminar este metodo para insertar un nuevo cliente. Como la tabla tiene identity, no es necesario agregar un id, ya que la BD lo genera.
            using (PuntoVentaDataContext oContext = new PuntoVentaDataContext())
            {
                customer nuevoCliente = new customer();
                nuevoCliente.name_1 = name1;
                nuevoCliente.customer_type = customer_type;
                nuevoCliente.specialty_1 = specialty1;
                nuevoCliente.specialty_2 = specialty2;
                nuevoCliente.status = "ACTV";
                oContext.customers.InsertOnSubmit(nuevoCliente);
                oContext.SubmitChanges();               

            }
            
            return false;

        }

        #endregion

        #region Opereaciones system_users
        
        public List<system_user> GetAllsystem_user()
        {
           
            using (PuntoVentaDataContext oContext = new PuntoVentaDataContext())
            {

                var tableSystem_user = oContext.GetTable<system_user>();

               
                try
                {
                    var consul = from system_user in tableSystem_user
                                where system_user.status == "ALLW"
                                select system_user;

                    List<system_user> coleccionSalida = new List<system_user>();
                    foreach (var item in coleccionSalida)
                    {
                        
                        system_user s = new system_user();
                        s.system_user_id = item.system_user_id;
                        s.first_name = item.first_name;
                        s.first_last_name = item.first_last_name;
                        s.display_label = item.display_label;
                        s.login_user_name = item.login_user_name;
                        s.employee_id = item.employee_id;
                        s.status = item.status;
                        s.creation_date = item.creation_date;
                        s.qvw_password = item.qvw_password;
                        s.qvw_domain_user = item.qvw_domain_user;
                        
                        coleccionSalida.Add(s);
                    }

                    //al final de foreach, ya se tiene llena la consulta
                    return coleccionSalida;
                }
                catch
                {
                    return null;
                }

            }

        }


        public system_user GetSystem_userById(int id)
        {
            using (PuntoVentaDataContext oContext = new PuntoVentaDataContext())
            {

                var tableSystem_user = oContext.GetTable<system_user>();
                try
                {
                    var consulta = from system_user in tableSystem_user
                                   where system_user.system_user_id == id
                                   select system_user;


                    return consulta.SingleOrDefault();
                }
                catch
                {
                    return null;
                }

                //TODO hacer consulta que filtre por id, la salida es un customer

                
            }
        }

        public List<system_user> GetSystem_usersByFilters(string name, string name2)
        {
            //TODO: hacer consulta por los dos filtros,
            using (PuntoVentaDataContext oContext = new PuntoVentaDataContext())
            {
                var tableSystem_user = oContext.GetTable<system_user>();

                try
                {
                    var consul = from system_user in tableSystem_user
                                 where system_user.first_name==name & system_user.first_last_name==name2
                                 select system_user;

                    List<system_user> coleccionSalida = new List<system_user>();
                    foreach (var item in coleccionSalida)
                    {

                        system_user s = new system_user();
                        s.system_user_id = item.system_user_id;
                        s.first_name = item.first_name;
                        s.first_last_name = item.first_last_name;
                        s.display_label = item.display_label;
                        s.login_user_name = item.login_user_name;
                        s.employee_id = item.employee_id;
                        s.status = item.status;
                        s.creation_date = item.creation_date;
                        s.qvw_password = item.qvw_password;
                        s.qvw_domain_user = item.qvw_domain_user;

                        coleccionSalida.Add(s);
                    }

                    //al final de foreach, ya se tiene llena la consulta
                    return coleccionSalida;
                }
                catch
                {
                    return null;
                }
            }
        }
        public bool UpdateSystem_user(int id, string name, string last_name)
        {
            //TODO: utilizar sintaxis para poder actualizar los dos campos que se pasan como parametro al metodo, con el id indicado. La sintaxis LINQ es simple, esta en el libro de ASP.NET
            using (PuntoVentaDataContext oContext = new PuntoVentaDataContext())
            {
                var tableSystem = oContext.GetTable<system_user>();
                try
                {
                    var actua = (from system_user in tableSystem
                                 where system_user.system_user_id == id
                                 select system_user).Single();
                    actua.first_name = name;
                    actua.first_last_name = last_name;
                    oContext.SubmitChanges();
                    return true;

                }
                catch
                {
                    return false;
                }
            }

        }

        public bool InsertCustomer1(string name1, string last_name, string display_name, string login_user_name)
        {
            //TODO: terminar este metodo para insertar un nuevo cliente. Como la tabla tiene identity, no es necesario agregar un id, ya que la BD lo genera.
            using (PuntoVentaDataContext oContext = new PuntoVentaDataContext())
            {
                system_user nuevoUsuario = new system_user();
                nuevoUsuario.first_name = name1;
                nuevoUsuario.first_last_name = last_name;
                nuevoUsuario.display_label = display_name;
                nuevoUsuario.login_user_name = login_user_name;
                nuevoUsuario.status = "ALLW";
                oContext.system_users.InsertOnSubmit(nuevoUsuario);
                oContext.SubmitChanges();

            }

            return false;

        }


        #endregion
    }
}