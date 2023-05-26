using GenFu;
using MDT.Model;
using MDT.Model.Gateway;
using Moq;
using System.Collections.Generic;
using Xunit;


namespace MDT.UseCase.Test
{
    public class HomeUseCaseTest
    {
        public Mock<IEmpleadoRepository> mockEmpleadoRepository = new Mock<IEmpleadoRepository>();

        public HomeUseCase homeUseCase
        {
            get
            {
                return new HomeUseCase(mockEmpleadoRepository.Object);

            }
        }

        [Fact]
        public void GetListaEmpleados()
        {
            //Arrange
            var Empleados = GetFakeEmpleados();
            mockEmpleadoRepository.Setup(repositorio => repositorio.ObtenerListaEmpleados()).Returns(Empleados);

            //Act
            var resultados = homeUseCase.ObtenerListaEmpleados().GetAwaiter().GetResult();

            //Assert
            Assert.Equal(5, resultados.Count);

        }

        private List<Empleado> GetFakeEmpleados()
        {

            List<Empleado> empleados = new List<Empleado>();
            var i = 1;

            var items = A.ListOf<int>(5);

            items.ForEach(x =>
            {
                Empleado item = new Empleado(
                    i.ToString(),
                        "Nombre ",
                        "Apellido ");
                empleados.Add(item);
                i++;
            });

            return empleados;

        }




    }
}