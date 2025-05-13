namespace cliente_solution.useCases.Exceptions;

public class EntidadeNaoExistente : Exception
{
    public EntidadeNaoExistente(string objetoDeBusca, int id) : base($"Não existe {objetoDeBusca} com o id {id}") { }
}