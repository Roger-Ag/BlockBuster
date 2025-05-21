public class Filme : IEntidade {
    public string Titulo { get; set; }
    public string Genero { get; set; }
    public int Ano { get; set; }
    public bool Disponibilidade { get; set; } = true;

    public Filme(string titulo, string genero, int ano) {
        Titulo = titulo;
        Genero = genero;
        Ano = ano;
    }

    public void Exibir() {
        Console.WriteLine($"{Titulo} ({Ano}) - {Genero} - Disponível: {Disponibilidade}");
    }

    public override string ToString() {
        return $"{Titulo};{Genero};{Ano};{Disponibilidade}";
    }

    public static Filme FromString(string linha) {
        var partes = linha.Split(';');
        return new Filme(partes[0], partes[1], int.Parse(partes[2])) {
            Disponibilidade = bool.Parse(partes[3])
        };
    }
}
