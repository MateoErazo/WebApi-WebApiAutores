﻿namespace WebApiAutores.Entidades
{
    public class Autor
    {
        public int ID { get; set; }
        public string Nombre { get; set; }

        public int Edad { get; set; }

        public List<Libro> Libros { get; set; } 
    }
}
