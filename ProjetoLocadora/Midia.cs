using System;

public abstract class Midia {
    public string Titulo { get; set; }
    public string Genero { get; set; }
    public int Ano { get; set; }
    public bool Disponivel { get; set; } = true;

    public Midia(string titulo, string genero, int ano) {
        Titulo = titulo;
        Genero = genero;
        Ano = ano;
    }

    public virtual void ExibirInfo() {
        Console.WriteLine($"Tipo: {this.GetType().Name} | Título: {Titulo} | Gênero: {Genero} | Ano: {Ano} | Disponível: {Disponivel}");
    }


    public override string ToString() {
        return $"{GetType().Name}|{Titulo}|{Genero}|{Ano}|{Disponivel}";
    }
}

public class DVD : Midia {
    public DVD(string titulo, string genero, int ano) : base(titulo, genero, ano) { }
}

public class CD : Midia {
    public CD(string titulo, string genero, int ano) : base(titulo, genero, ano) { }
}

public class BluRay : Midia {
    public BluRay(string titulo, string genero, int ano) : base(titulo, genero, ano) { }
}

public class Cassete : Midia {
    public Cassete(string titulo, string genero, int ano) : base(titulo, genero, ano) { }
}

