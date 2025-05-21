using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;


public class Locadora {
    public List<Cliente> Clientes { get; set; } = new List<Cliente>();
    public List<Midia> Midias { get; set; } = new List<Midia>();
    public List<Aluguel> Alugueis { get; set; } = new List<Aluguel>();

    private string clientesFile = "clientes.txt";
    private string midiasFile = "midias.txt";

    public void CadastrarCliente(Cliente cliente) {
        Clientes.Add(cliente);
        File.AppendAllText(clientesFile, cliente.ToString() + Environment.NewLine);
    }

    public void AdicionarMidia(Midia midia) {
        Midias.Add(midia);
        File.AppendAllText(midiasFile, midia.ToString() + Environment.NewLine);
    }

    public void ListarClientes() {
        if (Clientes.Count == 0) Console.WriteLine("Nenhum cliente cadastrado.");
        foreach (var cliente in Clientes)
            Console.WriteLine($"Nome: {cliente.Nome}, CPF: {cliente.Cpf}");
    }

    public void ListarMidias() {
        if (Midias.Count == 0) Console.WriteLine("Nenhuma mídia cadastrada.");
        foreach (var midia in Midias)
            midia.ExibirInfo();
    }

    public void RealizarAluguel(string cpfCliente, string tituloMidia) {
        var cliente = Clientes.FirstOrDefault(c => c.Cpf == cpfCliente);
        var midia = Midias.FirstOrDefault(m => m.Titulo == tituloMidia && m.Disponivel);

        if (cliente != null && midia != null) {
            midia.Disponivel = false;
            var aluguel = new Aluguel(cliente, midia);
            Alugueis.Add(aluguel);
            Console.WriteLine("Aluguel realizado com sucesso!");
        }
        else {
            Console.WriteLine("Cliente ou mídia não encontrado(a), ou mídia indisponível.");
        }
    }

    public void RealizarDevolucao(string cpfCliente, string tituloMidia) {
        var aluguel = Alugueis.FirstOrDefault(a =>
            a.Cliente.Cpf == cpfCliente &&
            a.Midia.Titulo == tituloMidia &&
            a.DataDevolucao == null
        );

        if (aluguel != null) {
            aluguel.Devolver();
        }
        else {
            Console.WriteLine("Aluguel não encontrado ou já devolvido.");
        }
    }

    public void CarregarClientes() {
        if (File.Exists(clientesFile)) {
            var linhas = File.ReadAllLines(clientesFile);
            foreach (var linha in linhas) {
                var partes = linha.Split('|');
                if (partes.Length == 2) {
                    Clientes.Add(new Cliente(partes[0], partes[1]));
                }
            }
        }
    }

    public void CarregarMidias() {
        if (File.Exists(midiasFile)) {
            var linhas = File.ReadAllLines(midiasFile);
            foreach (var linha in linhas) {
                var partes = linha.Split('|');
                if (partes.Length == 5) {
                    string tipo = partes[0];
                    string titulo = partes[1];
                    string genero = partes[2];
                    int ano = int.Parse(partes[3]);
                    bool disponivel = bool.Parse(partes[4]);

                    Midia midia = tipo switch {
                        "DVD" => new DVD(titulo, genero, ano),
                        "CD" => new CD(titulo, genero, ano),
                        "BluRay" => new BluRay(titulo, genero, ano),
                        "Cassete" => new Cassete(titulo, genero, ano),
                        _ => null
                    };

                    if (midia != null) {
                        midia.Disponivel = disponivel;
                        Midias.Add(midia);
                    }
                }
            }
        }
    }

}

