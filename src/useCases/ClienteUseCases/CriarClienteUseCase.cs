using cliente_solution.domain.models;
using cliente_solution.domain.repository;

namespace cliente_solution.useCases.ClienteUseCases;

//agora vamos fazer os use cases da nossa aplicação.
//não é incorreto pensar neles como os "comandos" que permitimos que sejam executados no nosso dominio.

//para seguirmos um padrão, todos os use cases serão nomeados no padrão:
//  Verbo ("Criar") + Nome da entidade ("Cliente") + Sufixo ("UseCase")
//E todos eles terão um método Executar() que recebe os parametros necessários
//(sim, pode ser criado uma interface de use case para forçar que todos eles tenham o método, mas para fins didáticos, vou deixar sem)

public class CriarClienteUseCase (ClienteRepository repository)
{
    private readonly ClienteRepository _repository = repository;

    public void Executar(string nome, string documento, string email)
    {
        //lembrando que para criar um cliente eu preciso de um nome, documento e email
        //ou seja, fazer:
        // var novoCliente = new Cliente(); -> erro de compilação
        //não vai fucionar

        //ou seja, para que a linha de baixo seja possível de ser feita, preciso que a função receba esses parâmetros
        var cliente = new Cliente(nome, documento, email);
        _repository.Adicionar(cliente);
    }
}