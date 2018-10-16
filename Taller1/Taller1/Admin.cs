using System;
using System.Collections.Generic;
using System.Text;

namespace Taller1
{
    class Admin
    {
        //Lista de usuarios registrados en el sistema.
        List<Usuario> usuarios = new List<Usuario>();
        List<Publicacion> publicacion = new List<Publicacion>();
        List<Comentario> comentario = new List<Comentario>();

        Boolean op = true;

        int id = 1, numPublicacion = 1, numComentario = 1; 
        string nombre, correo;


        //Metodo para completar los datos de persona/usuario.
        void persona()
        {
            Console.WriteLine("Bienvenido al Sistema, Por favor ingrese algunos datos personales");
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
                Console.WriteLine("\n----------------LISTA DE PUBLICACIONES----------------");
                Console.WriteLine("Número de Publicación: " + publicacion[i].id);
                Console.WriteLine("Publicado el: " + publicacion[i].fecha);
                Console.WriteLine("         " + publicacion[i].desarrollo);
                Console.WriteLine("Por: " + publicacion[i].Editor);

                for (int j = 0; j < comentario.Count; j++)
                {
                    if (comentario[j].idPublicacion == i+1)
                    {
                        Console.WriteLine("Comentario el: " + comentario[j].fecha);
                        Console.WriteLine("         " + comentario[j].desarrollo);
                        Console.WriteLine("Por Invitado: " + comentario[j].invitado);
                    }
                }
            }
        }

        //Menú principal
        public void menu()
        {
            while (op)
            {
                persona();//Llama al metodo que completa los datos de la persona

                Console.WriteLine("\nSeleccione lo que desea hacer: \n1.Editar \n2.Comentar \nOtro.Salir");
                string tipoUsuario = Console.ReadLine();

                if (tipoUsuario.Equals("1"))
                {
                    Boolean tip = true;
                    while (tip)
                    {
                        Console.WriteLine("\nSeleccione lo que desea hacer: \n1.Nueva publicación \n2.Lista de publicaciones \nOtro.Salir");
                        string opcion = Console.ReadLine();
                        if (opcion.Equals("1"))
                        {
                            Console.WriteLine("\nIndique el contenido de la publicacion que desea agregar");
                            string desarrollo = Console.ReadLine();

                            publicacion.Add(new Publicacion { id = numPublicacion, Editor = nombre, fecha = DateTime.Now, desarrollo = desarrollo });
                            Console.WriteLine("Publicacion número " + numPublicacion + " agregada correctamente\n");
                            numPublicacion++;
                        }
                        else
                        {
                            if (opcion.Equals("2"))
                            {
                                imprimir();
                            }
                            else
                            {
                                Console.WriteLine("\nVolverá al menú principal");
                                Console.ReadLine();
                                tip = false;
                            }
                        }
                    }
                }
                else
                {
                    if (tipoUsuario.Equals("2"))
                    {
                        Boolean tip = true;
                        while (tip)
                        {
                            Console.WriteLine("\nSeleccione lo que desea hacer: \n1.Nuevo comentario \n2.Lista de publicaciones \nOtro.Salir");
                            string opcion = Console.ReadLine();
                            if (opcion.Equals("1"))
                            {

                                Console.WriteLine("\nIndique el número publicación:");
                                id = Convert.ToInt32(Console.ReadLine());
                                Boolean exis = true;
                                
                                    for (int i = 0; i < publicacion.Count; i++)
                                    {
                                        if (publicacion[i].id == id)
                                        {
                                            Console.WriteLine("\nIndique el contenido del comentario que desea agregar");
                                            string desarrollo = Console.ReadLine();
                                            comentario.Add(new Comentario { id = numComentario, invitado = nombre, idPublicacion = id, fecha = DateTime.Now, desarrollo = desarrollo });
                                            Console.WriteLine("Comentario número " + numComentario + " agregado correctamente a la publicacion: " + publicacion[i].id + "\n");
                                            numComentario++;
                                            exis = false;
                                        }
                                    }
                                    
                                
                                if (exis)
                                {
                                    Console.WriteLine("\nEl número de publicacion no existe");
                                    Console.ReadLine();
                                }
                            }
                            else
                            {
                                if (opcion.Equals("2"))
                                {
                                    imprimir();
                                }
                                else
                                {
                                    Console.WriteLine("\nVolverá al menú principal");
                                    Console.ReadLine();
                                    tip = false;
                                }
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
