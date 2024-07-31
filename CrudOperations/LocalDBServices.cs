using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudOperations
{
    public class LocalDBServices
    {
        //declaring private local string to represent the database name
        private const string DB_NAME = "demo_local_db.db3";

        //ReadOnly Object named connection
        private readonly SQLiteAsyncConnection _connection;

        //instantiate connection object by providing database path as parameter

        public LocalDBServices()
        {
            _connection = new SQLiteAsyncConnection(Path.Combine(FileSystem.AppDataDirectory, DB_NAME));
            _connection.CreateTableAsync<Contact>();
        }

        //methods for ferching contacts
        public async Task<List<Contact>> GetContact()
        {
            return await _connection.Table<Contact>().ToListAsync();
        }
        public async Task Create(Contact contact)
        {
            return await _connection.InsertAllAsync(contact);
        }
    }
}
