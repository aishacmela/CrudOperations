using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudOperations
{
    [SQLite.Table("contact")]

    public class Contact
    {
        [PrimaryKey]
        [AutoIncrement]
        [SQLite.Column("id")]
        public int Id { get; set; }
        [SQLite.Column("contact_name")]
        public string Name { get; set; }
        [SQLite.Column("contact_email")]
        public string Email { get; set; }
        [SQLite.Column("contact phone number")]
        public string PhoneNumber { get; set; }

    }
}
