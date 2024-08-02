using ControleFinanceiro.Data.Contexts;
using ControleFinanceiro.Domain.Dtos.Request;
using ControleFinanceiro.Domain.Dtos.Response;
using ControleFinanceiro.Domain.Interfaces.Repositories;
using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Threading.Tasks;

namespace ControleFinanceiro.Data.Repositories
{
    public class PrincipalRepository : IPrincipalRepository
    {
        public DatabaseContext _databaseContext { get; set; }
        private readonly IConfiguration _configuration;

        public PrincipalRepository(
            IConfiguration configuration
            )
        {
            _configuration = configuration;
            _databaseContext = new DatabaseContext(new DbConnectionStringBuilder { ConnectionString = _configuration.GetConnectionString("gastosDb") });
        }

        public async Task<IEnumerable<PrincipalResponse>> BuscarTodosAsync()
        {
            try
            {
                string query = @"SELECT
                                P.ID as Id,
                                P.VALOR as Valor,
                                P.DESCRICAO as Descricao,
                                C.NOME as Categoria,
                                TP.NOME as TipoPagamento,
                                B.NOME as Banco,
                                L.NOME as Local,
                                D.NOME as Destinatario,
                                SC.NOME as SubCategoria,
                                PDD.NOME as Prioridade

                                FROM PRINCIPAL P
                                INNER JOIN CATEGORIA C ON P.ID_CATEGORIA = C.ID
                                INNER JOIN TIPO_PAGAMENTO TP ON P.ID_CATEGORIA = TP.ID
                                INNER JOIN BANCO B ON P.ID_CATEGORIA = B.ID
                                INNER JOIN LOCAL L ON P.ID_CATEGORIA = L.ID
                                INNER JOIN DESTINATARIO D ON P.ID_CATEGORIA = D.ID
                                INNER JOIN SUB_CATEGORIA SC ON P.ID_CATEGORIA = SC.ID
                                INNER JOIN PRIORIDADE PDD ON P.ID_CATEGORIA = PDD.ID";

                using (IDbConnection conn = _databaseContext.GetConnection())
                {
                    return await conn.QueryAsync<PrincipalResponse>(query, commandType: CommandType.Text);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"InnerException: {ex.InnerException} | Message: {ex.Message}");
            }
        }

        public async Task<bool> InserirAsync(PrincipalRequest request)
        {
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@VALOR", request.Valor);
                param.Add("@DATA", request.Data, DbType.Date);
                param.Add("@DESCRICAO", request.Descricao, DbType.String);
                param.Add("@ID_CATEGORIA", request.IdCategoria, DbType.Int64);
                param.Add("@ID_TIPO_PAGAMENTO", request.IdTipoPagamento, DbType.Int64);
                param.Add("@ID_BANCO", request.IdBanco, DbType.Int64);
                param.Add("@ID_LOCAL", request.IdLocal, DbType.Int64);
                param.Add("@ID_DESTINATARIO", request.IdDestinatario, DbType.Int64);
                param.Add("@ID_SUB_CATEGORIA", request.IdSubCategoria, DbType.Int64);
                param.Add("@ID_PRIORIDADE", request.IdPrioridade, DbType.Int64);

                string query = @"INSERT INTO [dbo].[PRINCIPAL]
                                   ([VALOR]
                                   ,[DATA]
                                   ,[DESCRICAO]
                                   ,[ID_CATEGORIA]
                                   ,[ID_TIPO_PAGAMENTO]
                                   ,[ID_BANCO]
                                   ,[ID_LOCAL]
                                   ,[ID_DESTINATARIO]
                                   ,[ID_SUB_CATEGORIA]
                                   ,[ID_PRIORIDADE])
                                
                                    VALUES
                                        (@VALOR,
                                        @DATA,
                                        @DESCRICAO,
                                        @ID_CATEGORIA,
                                        @ID_TIPO_PAGAMENTO,
                                        @ID_BANCO,
                                        @ID_LOCAL,
                                        @ID_DESTINATARIO,
                                        @ID_SUB_CATEGORIA,
                                        @ID_PRIORIDADE)";

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
