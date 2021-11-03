using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjBiblioteca
{
    class Livro
    {
        private int isbn;
        private string titulo;
        private string autor;
        private string editora;
        private List<Exemplar> exemplares;

        public int Isbn { get => isbn; set => isbn = value; }
        public string Titulo { get => titulo; set => titulo = value; }
        public string Autor { get => autor; set => autor = value; }
        public string Editora { get => editora; set => editora = value; }
        internal List<Exemplar> Exemplares { get => exemplares; set => exemplares = value; }

        public Livro(int isbn, string titulo, string autor, string editora)
        {
            this.isbn = isbn;
            this.titulo = titulo;
            this.autor = autor;
            this.editora = editora;
            this.exemplares = new List<Exemplar>();
        }
        public Livro(int isbn)
        {
            this.isbn = isbn;
        }
        public Livro() { }

        public void adicionarExemplar(Exemplar exemplar)
        {
            exemplares.Add(exemplar);
        }
        public int qtdeExemplares()
        {
            return exemplares.Count;
        }
        public int qtdeDisponiveis()
        {
            int qtdDisponiveis = 0;
            foreach (Exemplar exemplar in exemplares)
            {
                if (exemplar.disponivel())
                {
                    qtdDisponiveis++;
                }
            }
            return qtdDisponiveis;
        }
        public int qtdeEmprestimos()
        {
            int qtdEmprestimos = 0;
            foreach (Exemplar exemplar in exemplares)
            {
                qtdEmprestimos += exemplar.qtdeEmprestimo();
            }
            return qtdEmprestimos;
        }
        public double percDisponibilidade()
        {
            int exemplares = qtdeExemplares();
            int disponiveis = qtdeDisponiveis();
            if (exemplares <= 0)
            {
                return 0;
            }
            return (disponiveis / exemplares) * 100;
        }
        public override bool Equals(object obj)
        {
            return obj is Livro livro && isbn.Equals(livro.isbn);
        }
    }
}
