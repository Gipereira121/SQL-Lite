using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SQLite;
using AppVeterinario.Models;

namespace AppVeterinario.Helpers
{
    public class SQLiteDataBaseHelpers
    {
     // readonly SQLiteConnection connection; conexão tradicional (ativa)
        readonly SQLiteAsyncConnection _conn; //conexão assincrona

        public SQLiteDataBaseHelpers(string path) //metedo construtor (POO)
        {
            _conn = new SQLiteAsyncConnection(path); 
            _conn.CreateTableAsync<Especie>().Wait(); //cria uma tabela 'especie'
        }
        public Task<int> Insert(Especie p) //retorno de uma tarefa de inteiro
        {
            return _conn.InsertAsync(p); //adiciona um parametro (especie)

        }
        public  Task<List<Especie>> Update(Especie p) 
        {
            string sql = "UPDATE Especie SET Nome=? WHERE Codigo=?";
            return _conn.QueryAsync<Especie>(sql, p.Nome, p.Codigo);
        }
        public Task<int> Delete(int p) 
        {
            return _conn.Table<Especie>().DeleteAsync(i => i.Codigo == p); // recurso do sql faz assim

            // string SQL = "DELETE Especie WHERE Codigo=?" // outra alternativa, que eu executo o comando sql (banco de dados)
            //_conn.QueryAsync<Especie>(sql, p);
        }
        public Task<List<Especie>> GetAll() 
        {
            return _conn.Table<Especie>().ToListAsync();
        }
        public Task<List<Especie>> Search(string p) 
        { 
            string sql = "SELECT * FROM Especie WHERE Nome LIKE %'" + p + "'%";
            return _conn.QueryAsync<Especie>(sql);
        }

    }
}
