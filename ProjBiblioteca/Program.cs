using System;
using System.Collections.Generic;

namespace ProjBiblioteca
{
    class Program
    {
        static void Main(string[] args)
        {
            bool sair = false;
            int opSelecionada;

            Livros livros = new Livros();

            while (!sair)
            {

                Console.WriteLine("\n0. Sair \n1.Adicionar livro \n2.Pesquisar livro (sintético) \n3.Pesquisar livro (analítico) \n4.Adicionar exemplar \n5.Registrar empréstimo \n6.Registrar devolução");
                opSelecionada = int.Parse(Console.ReadLine());


                switch (opSelecionada)
                {
                    case 0:
                        sair = true;
                        break;
                    case 1:
                        addLivro(livros);
                        break;
                    case 2:
                        pesqLivroSint(livros);
                        break;
                    case 3:
                        pesqLivroAna(livros);
                        break;
                    case 4:
                        addExemplar(livros);
                        break;
                    case 5:
                        regEmprestimo(livros);
                        break;
                    case 6:
                        regDevolucao(livros);
                        break;
                    default:
                        Console.WriteLine("Digite uma opção válida.");
                        break;
                }

                void addLivro(Livros livros)
                {
                    Console.WriteLine("Digite o ISBN do livro:");
                    int isbn = int.Parse(Console.ReadLine());

                    Console.WriteLine("Digite o título do livro:");
                    string titulo = Console.ReadLine();

                    Console.WriteLine("Digite o nome do autor:");
                    string autor = Console.ReadLine();

                    Console.WriteLine("Digite o nome da editora:");
                    string editora = Console.ReadLine();

                    livros.adicionar(new Livro(isbn, titulo, autor, editora));
                    Console.WriteLine("Livro adicionado.");
                }

                void pesqLivroSint(Livros livros)
                {
                    Console.WriteLine("Digite o ISBN do livro que deseja procurar:");
                    int isbn = int.Parse(Console.ReadLine());

                    Livro livroEncontrado = livros.pesquisar(new Livro(isbn));

                    if(livroEncontrado.Titulo == null)
                    {
                        Console.WriteLine("Livro não encontrado.");
                    } else
                    {
                        Console.WriteLine($"Titulo: {livroEncontrado.Titulo}\nAutor: {livroEncontrado.Autor}\nEditora: {livroEncontrado.Editora}\nTotal de exemplares: {livroEncontrado.qtdeExemplares()}\nExemplares disponíveis: {livroEncontrado.qtdeDisponiveis()}\nPercentual de disponibilidade: {livroEncontrado.percDisponibilidade()}");
                    }
                }

                void pesqLivroAna(Livros livros)
                {
                    Console.WriteLine("Digite o ISBN do livro que deseja procurar:");
                    int isbn = int.Parse(Console.ReadLine());

                    Livro livroEncontrado = livros.pesquisar(new Livro(isbn));

                    if (livroEncontrado.Titulo == null)
                    {
                        Console.WriteLine("Livro não encontrado.");
                    }
                    else
                    {
                        Console.WriteLine($"Titulo: {livroEncontrado.Titulo}\nAutor: {livroEncontrado.Autor}\nEditora: {livroEncontrado.Editora}\nTotal de exemplares: {livroEncontrado.qtdeExemplares()}\nExemplares disponíveis: {livroEncontrado.qtdeDisponiveis()}\nPercentual de disponibilidade: {livroEncontrado.percDisponibilidade()}");
                        List<Exemplar> exemplares = livroEncontrado.Exemplares;
                        foreach(Exemplar exemplar in exemplares)
                        {
                            Console.WriteLine($"Tombo Exemplar: {exemplar.Tombo}\nQuantidade de empréstimos: {exemplar.qtdeEmprestimo()}");
                        }
                    }
                }

                void addExemplar(Livros livros)
                {
                    Console.WriteLine("Digite o ISBN do livro que deseja adicionar o exemplar:");
                    int isbn = int.Parse(Console.ReadLine());

                    Livro livroEncontrado = livros.pesquisar(new Livro(isbn));

                    if (livroEncontrado.Titulo == null)
                    {
                        Console.WriteLine("Livro não encontrado.");
                    }
                    else
                    {
                        Console.WriteLine("Digite o tombo do exemplar:");
                        int tombo = int.Parse(Console.ReadLine());

                        livroEncontrado.adicionarExemplar(new Exemplar(tombo));
                        Console.WriteLine("Exemplar adicionado");
                    }
                }

                void regEmprestimo(Livros livros)
                {
                    Console.WriteLine("Digite o ISBN do livro:");
                    int isbn = int.Parse(Console.ReadLine());

                    Livro livroEncontrado = livros.pesquisar(new Livro(isbn));

                    if (livroEncontrado.Titulo == null)
                    {
                        Console.WriteLine("Livro não encontrado.");
                    }
                    else
                    {
                        Console.WriteLine("Digite o tombo do exemplar:");
                        int tombo = int.Parse(Console.ReadLine());

                        List<Exemplar> exemplares = livroEncontrado.Exemplares;
                        Exemplar exemplarEncontrado = new Exemplar();
                        foreach (Exemplar exemplar in exemplares)
                        {
                            if(exemplar.Tombo.Equals(tombo))
                            {
                                exemplarEncontrado = exemplar;
                                break;
                            }
                        }
                        if(exemplarEncontrado.Tombo.Equals(null))
                        {
                            Console.WriteLine("Exemplar não encontrado");
                        } else
                        {
                            Console.WriteLine(exemplarEncontrado.emprestar() ? "Exemplar emprestado." : "Não foi possível emprestar");
                        }
                    }
                }

                void regDevolucao(Livros livros)
                {
                    Console.WriteLine("Digite o ISBN do livro:");
                    int isbn = int.Parse(Console.ReadLine());

                    Livro livroEncontrado = livros.pesquisar(new Livro(isbn));

                    if (livroEncontrado.Titulo == null)
                    {
                        Console.WriteLine("Livro não encontrado.");
                    }
                    else
                    {
                        Console.WriteLine("Digite o tombo do exemplar:");
                        int tombo = int.Parse(Console.ReadLine());

                        List<Exemplar> exemplares = livroEncontrado.Exemplares;
                        Exemplar exemplarEncontrado = new Exemplar();
                        foreach (Exemplar exemplar in exemplares)
                        {
                            if (exemplar.Tombo.Equals(tombo))
                            {
                                exemplarEncontrado = exemplar;
                                break;
                            }
                        }
                        if (exemplarEncontrado.Tombo.Equals(null))
                        {
                            Console.WriteLine("Exemplar não encontrado");
                        }
                        else
                        {
                            Console.WriteLine(exemplarEncontrado.devolver() ? "Exemplar devolvido." : "Não foi possível devolver.");
                        }
                    }
                }
            }
        }
    }
}
