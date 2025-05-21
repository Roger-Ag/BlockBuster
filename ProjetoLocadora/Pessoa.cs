public class Pessoa {
    public string Nome { get; set; }
    public string Cpf { get; set; }

    public Pessoa(string nome, string cpf) {
        Nome = nome;
        Cpf = cpf;
    }

    public override string ToString() {
        return $"{Nome};{Cpf}";
    }

    public static Pessoa FromString(string linha) {
        var partes = linha.Split(';');
        return new Pessoa(partes[0], partes[1]);
    }
}
