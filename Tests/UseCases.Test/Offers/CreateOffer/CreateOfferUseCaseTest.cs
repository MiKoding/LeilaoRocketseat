using Bogus;
using FluentAssertions;
using leilaoRocketseatAPI.Communication.Requests;
using leilaoRocketseatAPI.Contracts;
using leilaoRocketseatAPI.Entities;
using leilaoRocketseatAPI.Services;
using leilaoRocketseatAPI.UseCases.Leiloes.getCurrent;
using leilaoRocketseatAPI.UseCases.Offers.CreateOffer;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace UseCases.Test.Offers.CreateOffer
{
    
    public class CreateOfferUseCaseTest
    {
        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]// executa teste em parametros multiplos
        public void Success(int itemId) //itemId é alterado de acordo com a rodada de testes definidas acima
        {
            //Critério de AAA=
            //Arrange
            var request = new Faker<RequestCreateOfferJSON>().RuleFor(offer => offer.Price, f => f.Random.Decimal(1, 700)).Generate();

            var mock = new Mock<IOfferRepository>();
            var loggedUser = new Mock<ILoggedUser>();
            loggedUser.Setup(i=> i.User()).Returns(new User());

            var useCase = new CreateOfferUseCase(loggedUser.Object,mock.Object);// se eu colocarr mock.Object, dará um erro de falta de detalhes para o Mock

            //Act() =  ação
            var act = () => useCase.Execute(itemId, request);

            //Assert = verificação
           act.Should().NotThrow();

          
        }

        
    }
}
