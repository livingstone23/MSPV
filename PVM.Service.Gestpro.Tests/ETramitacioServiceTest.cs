using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using GenFu;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;


namespace PVM.Service.Gestpro.Tests
{

    //[TestFixture]
    //public class ETramitacioServiceTest
    //{

    //    private ETramitacioDto eTramitacio_One;
    //    private ETramitacioDto eTramitacio_Two;
    //    private DbContextOptions<ApplicationDbContext> options;

    //    public ETramitacioServiceTest()
    //    {
    //        eTramitacio_One = new ETramitacioDto()
    //        {
    //            IdETramitacio = 100,
    //            NombreOperacio = "0200093858050008",
    //            DataCreacio = DateTime.Now,
    //            NomAsociacio = "AEL",
    //            ModelContracte = "l-FZ",
    //            NomDocument = "CONTRATO DE ARRENDAMIENTO FINANCIERO BIENES MUEBLES",
    //            Estat = 0,
    //            TipusOperacio = "C"
    //        };

    //        eTramitacio_One = new ETramitacioDto()
    //        {
    //            IdETramitacio = 101,
    //            NombreOperacio = "0200093858050009",
    //            DataCreacio = DateTime.Now,
    //            NomAsociacio = "AEL",
    //            ModelContracte = "l-FZ",
    //            NomDocument = "CONTRATO DE ARRENDAMIENTO FINANCIERO BIENES MUEBLES",
    //            Estat = 36,
    //            TipusOperacio = "C"
    //        };
    //    }



    //    //private IEnumerable<ETramitacioDto> GetDataTest()
    //    //{
    //    //    A.Configure<ETramitacioDto>()
    //    //        .Fill(x=>x.NombreOperacio).AsArticleTitle()
    //    //        .Fill(x => x.NomAsociacio).AsArticleTitle()
    //    //        .Fill(x => x.ModelContracte).AsArticleTitle()
    //    //        .Fill(x => x.NomDocument).AsArticleTitle();

    //    //    var listData = A.ListOf<ETramitacioDto>(20);
    //    //    listData[0].IdETramitacio = 100;
    //    //    return listData;
    //    //}


    //    //private Mock<ApplicationDbContext> CreateContext()
    //    //{
    //    //    var dataTest = GetDataTest().AsQueryable();

    //    //    var dbSet = new Mock<DbSet<ETramitacio>>();
    //    //    dbSet.As<IQueryable<ETramitacio>>().Setup(x => x.Provider).Returns(dataTest.Provider);
    //    //    dbSet.As<IQueryable<ETramitacio>>().Setup(x => x.Expression).Returns(dataTest.Expression);
    //    //    dbSet.As<IQueryable<ETramitacio>>().Setup(x => x.ElementType).Returns(dataTest.ElementType);
    //    //    dbSet.As<IQueryable<ETramitacio>>().Setup(x => x.GetEnumerator()).Returns((Delegate)dataTest.GetEnumerator());


    //    //}

    //    //[Fact]
    //    //public void GetEtramitacios()
    //    //{

    //    //    var MockContext = new Mock<ApplicationDbContext>();
    //    //    var MockMapper = new Mock<IMapper>();

    //    //    ETramitacioService ETramitacio = new ETramitacioService(MockContext.Object, MockMapper.Object);




    //    //}

    //    [SetUp]
    //    public void Setup()
    //    {
    //        options = new DbContextOptionsBuilder<ApplicationDbContext>()
    //            .UseInMemoryDatabase(databaseName: "temp_GESTPRO").Options;
    //    }

    //    [Test]
    //    public void GetAll_Etramitacio_FromDatabase()
    //    {
    //        //Arrange
    //        var expectedResult = new List<ETramitacioDto>{eTramitacio_One, eTramitacio_Two};
    //        var MockMapper = new Mock<IMapper>();
    //        using (var context = new ApplicationDbContext(options))
    //        {
    //            context.Database.EnsureDeleted();
    //            var repository = new ETramitacioService(context, MockMapper.Object);
    //            //repository.
    //            repository.AddEtramitacio(eTramitacio_One);
    //            repository.AddEtramitacio(eTramitacio_Two);
    //        }


    //        //Act
    //        List<ETramitacioDto> actualList;
    //        using (var context = new ApplicationDbContext(options))
    //        {
    //            var repository = new ETramitacioService(context, MockMapper.Object);
    //            var result = repository.GetEtramitaciosAsync();
    //            actualList = result.Result.Data.ToList();
    //        }

    //        //assert
    //        CollectionAssert.AreEqual(expectedResult, actualList, new EtramitacioCompare());

    //    }

    //    private class EtramitacioCompare : IComparer
    //    {
    //        public int Compare(object x, object y)
    //        {
    //            var eTramitacioOne = (ETramitacioDto)x;
    //            var eTramitacioTwo = (ETramitacioDto)y;
    //            if (eTramitacioOne.IdETramitacio != eTramitacioTwo.IdETramitacio)
    //            {
    //                return 1;
    //            }
    //            else
    //            {
    //                return 0;
    //            }
    //        }
    //    }


    //}
}
