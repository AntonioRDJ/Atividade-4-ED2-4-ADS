using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjBiblioteca
{
    class Livros
    {
        private List<Livro> acervo;

        public Livros()
        {
            acervo = new List<Livro>();
        }

        public void adicionar(Livro livro)
        {
            acervo.Add(livro);
        }
        public Livro pesquisar(Livro livro)
        {
            Livro livroAchado = new Livro();
            for(int i = 0; i < acervo.Count; i++)
            {
                if(acervo[i].Equals(livro))
                {
                    livroAchado = acervo[i];
                    break;
                }
            }
            return livroAchado;
        }
    }
}
