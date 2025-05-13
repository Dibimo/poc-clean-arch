using cliente_solution.useCases.ClienteUseCases;
using cliente_solution.useCases.Exceptions;
using cliente_solution_test.repositories;

namespace cliente_solution_test.useCases;

public class AtualizarClienteUseCaseTest
{
    [Fact]
    public void AtualizarCliente_ClienteNaoExiste_DeveLancarException()
    {
        //arrange
        var repository = new ClienteRepositoryFakeImp();
        var useCase = new AtualizarClienteUseCase(repository);

        //act & assert
        Assert.Throws<EntidadeNaoExistente>(() => useCase.Executar(999, "nome", "documento", "email"));
    }
}