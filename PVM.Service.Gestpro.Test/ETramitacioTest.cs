using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using GenFu;
using Microsoft.EntityFrameworkCore;
using Moq;
using PVM.Services.Gestpro.DbContexts;
using PVM.Services.Gestpro.Model;
using PVM.Services.Gestpro.Services.ETramitacioService;

namespace PVM.Service.Gestpro.Test
{
    public class ETramitacioTest
    {


        [Fact]
        public async void GetETramitacios()
        {
            System.Diagnostics.Debugger.Launch();

            //Para hacer Mock en el servicio ETramitacioService
            var mockApplicationDbContext = CreateContext();//new Mock<ApplicationDbContext>();
            //var mockIMapper = new Mock<IMapper>();

            var MapConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingTest());
            });

            var mapper = MapConfig.CreateMapper();


            ETramitacioService EtramitacioServices = new ETramitacioService(mockApplicationDbContext.Object, mapper);

            var listEtramitacio = await EtramitacioServices.GetEtramitaciosAsync();


            Assert.True(listEtramitacio.Data.Any());

        }

        [Fact]
        public async void GetETramitacioByIdAsync()
        {

            var mockApplicationDbContext = CreateContext();

            var MapConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingTest());
            });

            var mapper = MapConfig.CreateMapper();

            ETramitacioService EtramitacioServices = new ETramitacioService(mockApplicationDbContext.Object, mapper);

            //Parametro de Busqueda
            int IdToFind = 1;
            var ETramitacio = await EtramitacioServices.GetEtramitacioById(IdToFind);


            Assert.NotNull(ETramitacio.Data);
            Assert.True(ETramitacio.Data.IdETramitacio == IdToFind);
        }


        private Mock<ApplicationDbContext> CreateContext()
        {
            var dataTest = GetDataTest().AsQueryable();

            var dbSet = new Mock<DbSet<ETramitacio>>();
            dbSet.As<IQueryable<ETramitacio>>().Setup(x => x.Provider).Returns(dataTest.Provider);
            dbSet.As<IQueryable<ETramitacio>>().Setup(x => x.Expression).Returns(dataTest.Expression);
            dbSet.As<IQueryable<ETramitacio>>().Setup(x => x.ElementType).Returns(dataTest.ElementType);
            dbSet.As<IQueryable<ETramitacio>>().Setup(x => x.GetEnumerator()).Returns(dataTest.GetEnumerator());

            dbSet.As<IAsyncEnumerable<ETramitacio>>().Setup(x => x.GetAsyncEnumerator(new System.Threading.CancellationToken()))
                .Returns(new AsyncEnumerator<ETramitacio>(dataTest.GetEnumerator()));

            //Permite habilitar el contexto para busqueda por parametros
            dbSet.As<IQueryable<ETramitacio>>().Setup(x => x.Provider).Returns(new AsyncQueryProvider<ETramitacio>(dataTest.Provider));


            var contexto = new Mock<ApplicationDbContext>();
            contexto.Setup(x => x.ETramitacios).Returns(dbSet.Object);
            return contexto;

        }

        private IEnumerable<ETramitacio> GetDataTest()
        {
            var i = 1;
            A.Configure<ETramitacio>()
                .Fill(x => x.NombreOperacio).AsArticleTitle()
                .Fill(x => x.IdETramitacio, () => { return i++; })
                .Fill(x => x.tzInsDate, () => { return DateTime.Now; });


            var list = A.ListOf<ETramitacio>(20);
            return list;

        }


    }
}
