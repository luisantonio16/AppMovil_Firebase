using SQLite;
using System;
using System.Collections.Generic;
using System.Text;


namespace App2.Models
{
    public  class UserModels
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public string Nombre { get; set; }
        public string Contraseña { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
    }
}
