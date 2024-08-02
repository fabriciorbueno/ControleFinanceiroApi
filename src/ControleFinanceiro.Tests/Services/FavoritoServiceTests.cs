//using AutoMapper;
//using ControleFinanceiro.Domain.Dtos;
//using ControleFinanceiro.Domain.Enums;
//using ControleFinanceiro.Domain.Interfaces.Repositories;
//using ControleFinanceiro.Domain.Interfaces.Services;
//using ControleFinanceiro.Domain.Models;
//using ControleFinanceiro.Domain.Profiles;
//using ControleFinanceiro.Service.Services;
//using Bogus;
//using Moq;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Net.Http;
//using System.Threading.Tasks;
//using Xunit;

//namespace ControleFinanceiro.Tests.Services
//{
//    public class FavoritoServiceTests
//    {
//        private readonly Mock<IBaseRepository<Favorito>> _favoritoRepository = new();
//        private readonly List<Favorito> favoritosResponse;
//        private readonly FavoritoRequest favoritoIncluirRequest;
//        private readonly IMapper _mapper;
//        private IFavoritoService _favoritoService;
//        private readonly Mock<IHttpClientFactory> _httpClient = new();

//        public FavoritoServiceTests()
//        {
//            // Config Map
//            var mockMapper = new MapperConfiguration(cfg =>
//            {
//                cfg.AddProfile(typeof(FavorecidoProfile));
//            });
//            var mapper = mockMapper.CreateMapper();

//            // Dados
//            var tipoTransferencia = new Faker().PickRandom<TipoTransferencia>();

//            var favoritosFaker = new Faker<Favorito>("pt_BR")
//                .CustomInstantiator(f => new Favorito
//                {
//                    Apelido = f.Person.UserName,
//                    Ativo = f.Random.Bool(),
//                    CodigoBanco = f.Finance.Account(3),
//                    CpfCnpjDestinatario = f.Finance.Account(11),
//                    CpfCnpjRemetente = f.Finance.Account(11),
//                    NomeBanco = f.Finance.Random.Words(),
//                    NumeroAgencia = f.Finance.Account(5),
//                    NumeroConta = f.Finance.Account(8),
//                    TipoTransferencia = tipoTransferencia,
//                    Id = f.Random.Number(1, 100)
//                });

//            favoritosResponse = favoritosFaker.Generate(10);

//            favoritoIncluirRequest = new Faker<FavoritoRequest>("pt_BR")
//                .CustomInstantiator(f => new FavoritoRequest
//                {
//                    Apelido = f.Person.UserName,
//                    CodigoBanco = f.Finance.Account(3),
//                    CpfCnpjDestinatario = f.Finance.Account(11),
//                    CpfCnpjRemetente = f.Finance.Account(11),
//                    NomeBanco = f.Finance.Random.Words(),
//                    NumeroAgencia = f.Finance.Account(5),
//                    NumeroConta = f.Finance.Account(8),
//                    TipoTransferencia = tipoTransferencia
//                });

//            _mapper = mapper;
//        }

//        [Fact]
//        public async Task Consultar_Favorito_Async_Success()
//        {
//            var favoritoExistente = favoritosResponse.FirstOrDefault(x => x.Ativo);
//            var cpf = favoritoExistente.CpfCnpjRemetente;

//            _favoritoRepository.Setup(x => x.BuscarAsync(x => x.CpfCnpjRemetente == cpf && x.Ativo)).ReturnsAsync(favoritosResponse);
//            _favoritoService = new FavoritoService(_favoritoRepository.Object, _mapper, _httpClient.Object);

//            var success = await _favoritoService.ConsultarAsync(cpf);

//            Assert.True(success != null);
//        }

//        [Fact]
//        public async Task Consultar_Favorito_Async_Fail()
//        {
//            var favoritoExistente = favoritosResponse.FirstOrDefault(x => !x.Ativo);
//            var cpf = favoritoExistente.CpfCnpjRemetente;

//            _favoritoRepository.Setup(x => x.BuscarAsync(x => x.CpfCnpjRemetente == cpf && x.Ativo)).ReturnsAsync((List<Favorito>)null);
//            _favoritoService = new FavoritoService(_favoritoRepository.Object, _mapper, _httpClient.Object);

//            var success = await _favoritoService.ConsultarAsync(favoritoExistente.CpfCnpjRemetente);

//            Assert.False(success != null);
//        }

//        [Fact]
//        public async Task ConsultarTodos_Favorito_Async_Success()
//        {
//            _favoritoRepository.Setup(x => x.BuscarAsync(x => x.Ativo)).ReturnsAsync(favoritosResponse);
//            _favoritoService = new FavoritoService(_favoritoRepository.Object, _mapper, _httpClient.Object);

//            var success = await _favoritoService.ConsultarTodosAsync();

//            Assert.True(success.Any());
//        }

//        [Fact]
//        public async Task ConsultarTodos_Favorito_Async_Fail()
//        {
//            var favoritoExistente = favoritosResponse.FirstOrDefault(x => !x.Ativo);
//            var cpf = favoritoExistente.CpfCnpjRemetente;

//            _favoritoRepository.Setup(x => x.BuscarAsync(x => x.CpfCnpjRemetente == cpf && x.Ativo)).ReturnsAsync((List<Favorito>)null);
//            _favoritoService = new FavoritoService(_favoritoRepository.Object, _mapper, _httpClient.Object);

//            var success = await _favoritoService.ConsultarTodosAsync();

//            Assert.False(success.Any());
//        }

//        [Fact]
//        public async Task Incluir_Favorito_Async_Success()
//        {
//            _favoritoRepository.Setup(x =>
//                x.BuscarAsync(x =>
//                    x.CpfCnpjRemetente == favoritoIncluirRequest.CpfCnpjRemetente &&
//                    x.CpfCnpjDestinatario == favoritoIncluirRequest.CpfCnpjDestinatario &&
//                    x.TipoTransferencia == favoritoIncluirRequest.TipoTransferencia &&
//                    x.NumeroConta == favoritoIncluirRequest.NumeroConta &&
//                    x.NumeroAgencia == favoritoIncluirRequest.NumeroAgencia &&
//                    x.CodigoBanco == favoritoIncluirRequest.CodigoBanco))
//                .ReturnsAsync(new List<Favorito>());

//            var favoritoNovo = _mapper.Map<Favorito>(favoritoIncluirRequest);
//            var mockMapper = new Mock<IMapper>();

//            mockMapper.Setup(x => x.Map<Favorito>(It.IsAny<FavoritoRequest>()))
//                .Returns(favoritoNovo);

//            _favoritoService = new FavoritoService(_favoritoRepository.Object, mockMapper.Object, _httpClient.Object);
//            _favoritoRepository.Setup(x => x.SalvarAsync(favoritoNovo)).ReturnsAsync(1m);

//            var success = await _favoritoService.IncluirAsync(favoritoIncluirRequest);

//            Assert.True(success);
//        }

//        [Fact]
//        public async Task Incluir_Favorito_Async_Fail()
//        {
//            _favoritoRepository.Setup(x =>
//                x.BuscarAsync(x =>
//                    x.CpfCnpjRemetente == favoritoIncluirRequest.CpfCnpjRemetente &&
//                    x.CpfCnpjDestinatario == favoritoIncluirRequest.CpfCnpjDestinatario &&
//                    x.TipoTransferencia == favoritoIncluirRequest.TipoTransferencia &&
//                    x.NumeroConta == favoritoIncluirRequest.NumeroConta &&
//                    x.NumeroAgencia == favoritoIncluirRequest.NumeroAgencia &&
//                    x.CodigoBanco == favoritoIncluirRequest.CodigoBanco))
//                .ReturnsAsync(new List<Favorito>());

//            var favoritoNovo = _mapper.Map<Favorito>(favoritoIncluirRequest);
//            var mockMapper = new Mock<IMapper>();

//            mockMapper.Setup(x => x.Map<Favorito>(It.IsAny<FavoritoRequest>()))
//                .Returns(favoritoNovo);

//            _favoritoService = new FavoritoService(_favoritoRepository.Object, mockMapper.Object, _httpClient.Object);
//            _favoritoRepository.Setup(x => x.SalvarAsync(favoritoNovo)).ReturnsAsync(0m);

//            var success = await _favoritoService.IncluirAsync(favoritoIncluirRequest);

//            Assert.False(success);
//        }

//        [Theory]
//        [InlineData(1)]
//        public async Task Alterar_Favorito_Async_Success(int id)
//        {
//            _favoritoRepository.Setup(x => x.BuscarAsync(id))
//                .ReturnsAsync(favoritosResponse.FirstOrDefault());

//            var favoritoExistente = _mapper.Map<Favorito>(favoritoIncluirRequest);
//            var mockMapper = new Mock<IMapper>();

//            mockMapper.Setup(x => x.Map<Favorito>(It.IsAny<FavoritoRequest>()))
//                .Returns(favoritoExistente);

//            _favoritoService = new FavoritoService(_favoritoRepository.Object, mockMapper.Object, _httpClient.Object);
//            _favoritoRepository.Setup(x => x.AtualizarAsync(favoritoExistente)).ReturnsAsync(true);

//            var success = await _favoritoService.AlterarAsync(id, favoritoIncluirRequest);

//            Assert.True(success);
//        }

//        [Theory]
//        [InlineData(1)]
//        public async Task Alterar_Favorito_Async_Fail(int id)
//        {
//            _favoritoRepository.Setup(x => x.BuscarAsync(id))
//                .ReturnsAsync((Favorito)null);

//            var favoritoExistente = _mapper.Map<Favorito>(favoritoIncluirRequest);
//            var mockMapper = new Mock<IMapper>();

//            mockMapper.Setup(x => x.Map<Favorito>(It.IsAny<FavoritoRequest>()))
//                .Returns(favoritoExistente);

//            _favoritoService = new FavoritoService(_favoritoRepository.Object, mockMapper.Object, _httpClient.Object);
//            _favoritoRepository.Setup(x => x.AtualizarAsync(favoritoExistente)).ReturnsAsync(true);

//            var success = await _favoritoService.AlterarAsync(id, favoritoIncluirRequest);

//            Assert.False(success);
//        }

//        [Theory]
//        [InlineData(1, "123456789")]
//        public async Task Deletar_Favorito_Async_Success(int id, string documento)
//        {
//            var favorito = favoritosResponse.FirstOrDefault();
//            favorito.Id = id;
//            favorito.CpfCnpjDestinatario = documento;

//            _favoritoRepository.Setup(x => x.BuscarAsync(id)).ReturnsAsync(favorito);

//            var favoritoExistente = _mapper.Map<Favorito>(favoritoIncluirRequest);
//            var mockMapper = new Mock<IMapper>();

//            mockMapper.Setup(x => x.Map<Favorito>(It.IsAny<FavoritoRequest>()))
//                .Returns(favoritoExistente);

//            _favoritoService = new FavoritoService(_favoritoRepository.Object, mockMapper.Object, _httpClient.Object);
//            _favoritoRepository.Setup(x => x.AtualizarAsync(favoritoExistente)).ReturnsAsync(false);

//            var success = await _favoritoService.ExcluirAsync(id, documento);

//            Assert.False(success);
//        }

//        [Theory]
//        [InlineData(1, "123456789")]
//        public void Deletar_Favorito_Async_Fail(int id, string documento)
//        {
//            var favorito = favoritosResponse.FirstOrDefault();
//            favorito.Id = id;

//            _favoritoRepository.Setup(x => x.BuscarAsync(id)).ReturnsAsync(favorito);

//            var favoritoExistente = _mapper.Map<Favorito>(favoritoIncluirRequest);
//            var mockMapper = new Mock<IMapper>();

//            mockMapper.Setup(x => x.Map<Favorito>(It.IsAny<FavoritoRequest>()))
//                .Returns(favoritoExistente);

//            _favoritoService = new FavoritoService(_favoritoRepository.Object, mockMapper.Object, _httpClient.Object);
//            _favoritoRepository.Setup(x => x.AtualizarAsync(favoritoExistente)).ReturnsAsync(true);

//            Assert.Throws<AggregateException>(() => _favoritoService.ExcluirAsync(id, documento).Result);
//        }
//    }
//}
