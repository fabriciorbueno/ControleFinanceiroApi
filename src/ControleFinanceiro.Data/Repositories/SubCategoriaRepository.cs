using ControleFinanceiro.Data.Contexts;
using ControleFinanceiro.Domain.Dtos.Request;
using ControleFinanceiro.Domain.Interfaces.Repositories;
using ControleFinanceiro.Domain.Models.Entities;
using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Threading.Tasks;

namespace ControleFinanceiro.Data.Repositories
{
    public class SubCategoriaRepository : IGenericRepository
    {
        public DatabaseContext _databaseContext { get; set; }
        private readonly IConfiguration _configuration;

        public SubCategoriaRepository(
            IConfiguration configuration
            )
        {
            _configuration = configuration;
            _databaseContext = new DatabaseContext(new DbConnectionStringBuilder { ConnectionString = _configuration.GetConnectionString("gastosDb") });
        }

        public async Task<IEnumerable<Entity>> BuscarTodosAsync()
        {
            try
            {
                string query = @"SELECT ID as Id, NOME as Nome, DESCRICAO as Descricao
                                FROM SUB_CATEGORIA";

                using (IDbConnection conn = _databaseContext.GetConnection())
                {
                    return await conn.QueryAsync<Entity>(query, commandType: CommandType.Text);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"InnerException: {ex.InnerException} | Message: {ex.Message}");
            }
        }

        public async Task<bool> InserirAsync(RequestBase categoriaRequest)
        {
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@NOME", categoriaRequest.Nome, DbType.String);
                param.Add("@DESCRICAO", categoriaRequest.Descricao, DbType.String);
                string query;

                query = string.IsNullOrEmpty(categoriaRequest.Descricao)
                    ? @"INSERT INTO SUB_CATEGORIA (NOME)VALUES (@NOME)"
                    : @"INSERT INTO SUB_CATEGORIA (NOME, DESCRICAO) VALUES (@NOME, @DESCRICAO)";

                using (IDbConnection conn = _databaseContext.GetConnection())
                {
                    var response = await conn.ExecuteAsync(query, param, commandType: CommandType.Text);

                    if (response > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"InnerException: {ex.InnerException} | Message: {ex.Message}");
            }
        }
    }
}
