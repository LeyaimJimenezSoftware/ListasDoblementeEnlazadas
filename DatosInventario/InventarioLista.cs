using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DatosInventario
{
    class Inventario
    {
       
        
       private Producto primeroInicio = new Producto("","","","");
        private Producto ultimo;
        int cont;
        int pos;
        
        string buscar = "";
        public Inventario()
        {
            primeroInicio = null;
            ultimo = null;
        }

        public void ingressarProducto(Producto nuevo)
        {
            string buscar;
            if (primeroInicio == null)
            {
                primeroInicio = nuevo;
            }
            else
            {
                Producto temporal = primeroInicio;
                ultimo = nuevo;

                while (temporal.siguiente != null)
                {
                    temporal = temporal.siguiente;

                }

                temporal.siguiente = ultimo;

            }
        }



      

        public void agregarInicio(Producto nuevo)
        {
            if (primeroInicio == null)
            {
                primeroInicio = nuevo;
                ultimo = nuevo;
            }
            else
            {
                nuevo.siguiente = primeroInicio;
                primeroInicio.anterior = nuevo;
                primeroInicio = nuevo;

            }

        }
     
        public void agregarUltimo(Producto nuevo)
        {
            if (primeroInicio == null)
            {
                primeroInicio = nuevo;
                ultimo = nuevo;
            }
            else
            {
                ultimo.siguiente = nuevo;
                nuevo.anterior = ultimo;
                ultimo = nuevo;

            }

        }
      
          public void eliminarInicio()
        {
            primeroInicio = primeroInicio.siguiente;
            primeroInicio.anterior = null;
        }

        public void eliminarUltimo()
        {
            ultimo = ultimo.anterior;
            ultimo.siguiente = null;
        }
        //Recursividad

        //if (primeroInicio == null)
        //{
        //    primeroInicio = nuevo;
        //}
        //else
        //{
        //    agregar(primeroInicio, nuevo);
        //}

        //private void agregar(Producto ultimo ,Producto nuevo)
        //{
        //    if(ultimo.siguiente == null)
        //    {
        //        ultimo.siguiente = nuevo;
        //    }
        //    else
        //    {
        //        agregar(ultimo.siguiente, nuevo);
        //    }
        //}

        public void eliminarProducto(string codigo)
        {

            bool encontrado = false;
            Producto temporal = primeroInicio;
            if (temporal.codigo == codigo)
            {
                primeroInicio = temporal.siguiente;
                encontrado = true;
            }
            

            while (temporal != null && encontrado != true)
            {
              

               if (temporal.siguiente.codigo == codigo)
                {


                    temporal.siguiente = temporal.siguiente.siguiente;

                    encontrado = true;
                }
                else
                {
                    temporal = temporal.siguiente;
                }
            }
          
        }

        public Producto buscarProducto(string codigo)
        {
            
            Producto buscado = null;
            bool encontrado = false;
            Producto temporal = primeroInicio;


            while (temporal != null && encontrado !=true)
            {
                if (temporal.codigo == codigo)
                {
                   buscado = temporal;
                    encontrado = true;
                }
                else
                {
                    temporal = temporal.siguiente;
                }
            }
          



            return buscado;
        }

        public void insertarProducto(Producto p, int pos)
        {

            int cont = 0;
            Producto temporal = primeroInicio;
            while (temporal != null)
            {
                temporal = temporal.siguiente;
                if (cont == pos)
                {
                    Producto aux;
                    aux = temporal;
                    temporal = p;
                    temporal.siguiente = aux;


                }
                cont++;

            }

        }

        public override string ToString()
        {
            string str = " ";

            Producto t = primeroInicio;

            while (t != null)
            {
               
                str += t.ToString();
                t = t.siguiente;

            }
            return str;



        }

    }

    }

