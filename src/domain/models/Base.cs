namespace cliente_solution.domain.models;

//uma classe abstrata não pode ser instanciada
//ou seja, não pode ser usada para criar um objeto
//ou seja, isso não é possível
// Base base = new Base(); -> erro de compilação

//então elas são muito boas para cenários onde você precisa de uma implementação padrão, o que é diferente de interfaces

public abstract class Base {
    public int Id { get; set; }
}