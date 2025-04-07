using Azure.Core;
using ControleFinanceiro.Domain.Dtos;
using ControleFinanceiro.Domain.Entities;
using ControleFinanceiro.Domain.Interfaces.Repositories;
using ControleFinanceiro.Domain.Interfaces.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ControleFinanceiro.Service.Services
{
    public class GastosService : IGastosService
    {
        private readonly IGastosRepository _repository;
        private readonly IUsuarioRepository _usuarioRepository;

        public GastosService(
            IGastosRepository repository,
            IUsuarioRepository usuarioRepository)
        {
            _repository = repository;
            _usuarioRepository = usuarioRepository;
        }

        public async Task<IEnumerable<GastosResponse>> ObterPorUsuarioAsync(string cpf)
        {
            var usuario = await _usuarioRepository.ObterPorCpfAsync(cpf);
            if (usuario == null) return null;

            return await _repository.ObterPorUsuarioAsync(usuario.Id);
        }

        public async Task<bool> AdicionarAsync(GastosRequest request)
        {
            var usuario = await _usuarioRepository.ObterPorCpfAsync(request.Usuario);
            if (usuario == null) return false;

            var gasto = new Gastos(request.Valor, request.FormaPagamento, request.Instituicao, request.Destinatario, request.Categoria, request.Observacoes, usuario.Id);
            return await _repository.AdicionarAsync(gasto);
        }
    }
}
