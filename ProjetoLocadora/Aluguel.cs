using System;

public class Aluguel {
    public Cliente Cliente { get; set; }
    public Midia Midia { get; set; }
    public DateTime DataAluguel { get; set; }
    public DateTime? DataDevolucao { get; set; }

    public Aluguel(Cliente cliente, Midia midia) {
        Cliente = cliente;
        Midia = midia;
        DataAluguel = DateTime.Now;
    }

    public void Devolver() {
        DataDevolucao = DateTime.Now;
        Midia.Disponivel = true;
        Console.WriteLine("Devolução realizada com sucesso!");
    }
}
