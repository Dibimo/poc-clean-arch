using cliente_solution.domain.models;
using cliente_solution.domain.repository;

namespace cliente_solution.useCases.ClienteUseCases;

public class AtualizarClienteUseCase(ClienteRepository repository)
{
    private readonly ClienteRepository _repository = repository;

    public void Executar(int id, string nome, string documento, string email)
    {
        //no caso do atualizar, precisamos retornar exatamente o objeto que queremos atualizar
        //então precisariamos de um "encontre por id", mas nossa interface de ClienteRepository não possi esse método nesse ponto
        //simples de resolver, basta implementar
        var cliente = _repository.BuscarPorId(id);

        //estamos acostumados a fazer algo mais ou menos assim a partir daqui
        /*
            cliente.Nome = nome;
            cliente.Documento = documento;
            cliente.Email = email;
            _repository.Atualizar(cliente);
        */

        //mas lembram das regras de negócio?
        //para garantir nossa regras de negócio, estamos acostumados a fazer algo assim:
        /*
            ValidarNome(nome);
            ValidarDocumento(documento);
            ValidarEmail(email);

            cliente.Nome = nome;
            cliente.Documento = documento;
            cliente.Email = email;
            _repository.Atualizar(cliente);
        */

        //ou qualquer outra variação parecida.
        //o ponto é: nossa regra de negócio está fora do dominio (nossa classe cliente), então vamos ter problemas para atualizar e dar manutenção.
        //fora que abrirmos margem para que essas funções não sejam chamadas e etc. etc. Problemas é o que não faltam e todos já sabemos disso.

        //então, a forma como a arquitetura limpa propõe é:

        //garanto as regras de negócio
        cliente.AtualizarDocumento(documento);
        cliente.AtualizarEmail(email);
        cliente.AtualizarNome(nome);

        //depois passo para a camada de persistencia
        _repository.Atualizar(cliente);
    }
}
