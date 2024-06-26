using emoralesS5.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace emoralesS5.Utils
{
    public class PersonaRepositorio
    {
        string dbPath;
        private SQLiteConnection conn;

        public string StatusMessage { get; set; }

        private void init()
        {
            if (conn is not null)
                return;
            conn = new (dbPath);
            conn.CreateTable<Personas>();
        }

        public PersonaRepositorio (string Path)
        {
            dbPath = Path;
            
        }

        public void AddNewPersona(string nombre)
        {
            int result =0;
            try
            {
                init();
                if (string.IsNullOrEmpty(nombre))
                    throw new Exception("El nombre es requerido");

                Personas person = new() { Nombre = nombre };
                result = conn.Insert(person);
                StatusMessage = string.Format("Dato añadido correctamente", result, nombre);
            }
            catch (Exception EX)
            {

                StatusMessage = string.Format("Error al insertar el nombre", EX.Message);
            }
            
        }

        public List<Personas> GetAllPeople()
        {
            try
            {
                init();
                return conn.Table<Personas>().ToList();

            }
            catch (Exception ex)
            {

                StatusMessage = string.Format("Error al mostrar", ex.Message); 
            }
            return new List<Personas>();
        }

    }
}
