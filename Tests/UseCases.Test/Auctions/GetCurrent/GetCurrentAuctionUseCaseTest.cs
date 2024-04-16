using Bogus;
using FluentAssertions;
using leilaoRocketseatAPI.Contracts;
using leilaoRocketseatAPI.Entities;
using leilaoRocketseatAPI.Enums;
using leilaoRocketseatAPI.UseCases.Leiloes.getCurrent;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace UseCases.Test.Auctions.GetCurrent
{
    public class GetCurrentAuctionUseCaseTest
    {
        //Depedencias usadas nessa etapa: FluentAssertion,Mock, Bogus(Gerador de variáveis e valores para entidades, verificar a documentação para mais)
        [Fact]
        public void Success()
        {
            //Critério de AAA=
            //Arrange
            var entity = new Faker<Auction>().RuleFor(auction => auction.Id, f => f.Random.Number(1,700))
                .RuleFor(auction=>auction.Name, f=>f.Lorem.Word())
                .RuleFor(auction=>auction.Starts, f=>f.Date.Past())
                .RuleFor(auction=>auction.Ends, f=>f.Date.Future())
                .RuleFor(auction=>auction.Items, (f,auction)=>new List<Item> //auction é o que foi gerado acima
                {
                    new Item
                    {
                        Id = f.Random.Number(1,700),
                        Name = f.Commerce.ProductName(),
                        Brand = f.Commerce.Department(),
                        BasePrice = f.Random.Decimal(10,700),
                        Condition = f.PickRandom<Condition>(),
                        AuctionId = auction.Id
                    }
                }).Generate();

            var mock = new Mock<IAuctionRepository>();
            mock.Setup(i => i.GetCurrent()).Returns(entity); //usado para ensinar o mock e evitar o erro abaixo, new Auction() -> var entity

            var useCase = new GetCurrentAuctionUseCase(mock.Object);// se eu colocarr mock.Object, dará um erro de falta de detalhes para o Mock
            
            //Act() =  ação
            var auction = useCase.Execute();
            
            //Assert = verificação
            //Assert.NotNull(auction);//proprimanete do .net

            auction.Should().NotBeNull(); //usando assertions
            auction.Id.Should().Be(entity.Id);
            auction.Name.Should().Be(entity.Name);
        }
    }
}
