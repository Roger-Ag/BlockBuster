using System;

public class Program {
    public static void Main(string[] args) {
        Locadora locadora = new Locadora();
        locadora.CarregarClientes();
        locadora.CarregarMidias();


        while (true) {
            Console.WriteLine("\n==== LOCADORA ====");
            Console.WriteLine("1 - Cadastrar Cliente");
            Console.WriteLine("2 - Cadastrar Mídia");
            Console.WriteLine("3 - Listar Clientes");
            Console.WriteLine("4 - Listar Mídias");
            Console.WriteLine("5 - Realizar Aluguel");
            Console.WriteLine("6 - Realizar Devolução");
            Console.WriteLine("7 - Sair");
            Console.Write("Escolha uma opção: ");

            string opcao = Console.ReadLine();

            try {
                switch (opcao) {
                    case "1":
                        Console.Write("Nome: ");
                        string nome = Console.ReadLine();
                        Console.Write("CPF: ");
                        string cpf = Console.ReadLine();
                        locadora.CadastrarCliente(new Cliente(nome, cpf));
                        break;

                    case "2":
                        Console.Write("Título: ");
                        string titulo = Console.ReadLine();
                        Console.Write("Gênero: ");
                        string genero = Console.ReadLine();
                        Console.Write("Ano: ");
                        int ano = int.Parse(Console.ReadLine());

                        Console.WriteLine("Tipo de Mídia: 1-DVD | 2-CD | 3-BluRay | 4-Cassete");
                        string tipo = Console.ReadLine();

                        Midia midia = tipo switch {
                            "1" => new DVD(titulo, genero, ano),
                            "2" => new CD(titulo, genero, ano),
                            "3" => new BluRay(titulo, genero, ano),
                            "4" => new Cassete(titulo, genero, ano),
                            _ => throw new Exception("Tipo inválido")
                        };

                        locadora.AdicionarMidia(midia);
                        break;

                    case "3":
                        locadora.ListarClientes();
                        break;

                    case "4":
                        locadora.ListarMidias();
                        break;

                    case "5":
                        Console.Write("CPF do cliente: ");
                        string cpfAluguel = Console.ReadLine();
                        Console.Write("Título da mídia: ");
                        string tituloAluguel = Console.ReadLine();
                        locadora.RealizarAluguel(cpfAluguel, tituloAluguel);
                        break;

                    case "6":
                        Console.Write("CPF do cliente: ");
                        string cpfDevolucao = Console.ReadLine();
                        Console.Write("Título da mídia: ");
                        string tituloDevolucao = Console.ReadLine();
                        locadora.RealizarDevolucao(cpfDevolucao, tituloDevolucao);
                        break;

                    case "7":
                        Console.WriteLine("Saindo...");
                        return;

                    default:
                        Console.WriteLine("Opção inválida.");
                        break;
                }
            }
            catch (Exception ex) {
                Console.WriteLine($"Erro: {ex.Message}");
            }
        }
    }
}
