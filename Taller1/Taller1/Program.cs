using System;
using System.Collections.Generic;

namespace Taller1
{
    class Program
    {


        static void Main(string[] args)
        {
            //Lista de usuarios registrados en el sistema.
            List<Usuario> usuarios = new List<Usuario>();
            List<Publicacion> publicacion = new List<Publicacion>();
            List<Comentario> comentario = new List<Comentario>();

            Boolean op = true;

            int id=1, numPublicacion=1, numComentario=1; ;
            string nombre, correo;
            

            //Metodo para completar los datos de persona/usuario.
            void persona()
            {
                id++;
                Console.WriteLine("Nombre");
                nombre = Console.ReadLine();
                Console.WriteLine("Correo");
                correo = Console.ReadLine();

                //Agrega los datos del usuario a la lista de usuarios.
                usuarios.Add(new Usuario { id = id, nombre = nombre, correo = correo });
            }

            //Metodo para imprimir la lista de publicaciones
            void imprimir()
            {

                for (int i = 0; i < publicacion.Count; i++)
                {

                    Console.WriteLine("----------------LISTA DE PUBLICACIONES----------------");
                    Console.WriteLine("Publicado el: "+publicacion[i].fecha);
                    Console.WriteLine("         " + publicacion[i].desarrollo);
                    Console.WriteLine("Por: " + publicacion[i].Editor);

                    for (int j = 0; j < comentario.Count; j++)
                    {
                        if(comentario[j].idPublicacion==i)
                        Console.WriteLine("----------------LISTA DE COMENTARIOS----------------");
                        Console.WriteLine("Comentario el: " + comentario[i].fecha);
                        Console.WriteLine("         " + comentario[i].desarrollo);
                        Console.WriteLine("Por Invitado: " + comentario[i].invitado);
                    }
                }


            }


            //Menú principal
            while (op)
            {

                Console.WriteLine("Seleccione lo que desea hacer: \n1.Editar \n2.Comentar \n3.Salir");
                string tipoUsuario = Console.ReadLine();

                if (tipoUsuario.Equals("1"))
                {

                    persona();//Llama al metodo que completa los datos de la persona

                    Console.WriteLine("Seleccione lo que desea hacer: \n1.Nueva publicación \n2.Lista de publicaciones \n3.Salir");
                    string opcion = Console.ReadLine();
                    if (opcion.Equals("1"))
                    {
                        Console.WriteLine("Indique el contenido de la publicacion que desea agregar");
                        string desarrollo = Console.ReadLine();

                        publicacion.Add(new Publicacion { id = numPublicacion, Editor = nombre, fecha = DateTime.Now, desarrollo=desarrollo });
                        numPublicacion++;
                    }
                    else
                    {
                        if (opcion.Equals("2"))
                        {
                            
                        }
                        else
                        {
                            Console.WriteLine("Volverá al menú principal");
                            Console.ReadLine();
                        }
                    }
                }
                else
                {
                    if (tipoUsuario.Equals("2"))
                    {
                        Console.WriteLine("Seleccione lo que desea hacer: \n1.Nuevo comentario \n2.Lista de publicaciones \n3.Salir");
                        string opcion = Console.ReadLine();
                        if (opcion.Equals("1"))
                        {

                            persona();//Llama al metodo que completa los datos de la persona

                            Console.WriteLine("Indique el número publicación:");
                            id = Convert.ToInt32(Console.ReadLine());

                            for (int i = 0; i < publicacion.Count; i++)
                            {
                                if (publicacion[i].id == id)
                                {
                                    Console.WriteLine("Indique el contenido del comentario que desea agregar");
                                    string desarrollo = Console.ReadLine();
                                    comentario.Add(new Comentario { id = numComentario, invitado = nombre, idPublicacion = id, fecha = DateTime.Now, desarrollo = desarrollo });
                                    numComentario++;
                                }
                                else
                                {
                                    Console.WriteLine("El número de publicacion no existe");
                                    Console.ReadLine();
                                }
                            }

                        }
                        else
                        {
                            if (opcion.Equals("2"))
                            {

                            }
                            else
                            {
                                Console.WriteLine("Volverá al menú principal");
                                Console.ReadLine();
                            }
                        }
                    }
                    else
                    {
                        op = false;
                        Console.WriteLine("Gracias por usar el programa");
                        Console.ReadLine();
                    }
                }

            }
        }
    }
}
