using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjBiblioteca
{
    class Exemplar
    {
        private int tombo;
        private List<Emprestimo> emprestimos;

        public int Tombo { get => tombo; set => tombo = value; }
        internal List<Emprestimo> Emprestimos { get => emprestimos; set => emprestimos = value; }

        public Exemplar(int tombo)
        {
            this.tombo = tombo;
            this.emprestimos = new List<Emprestimo>();
        }
        public Exemplar() { }

        public bool emprestar()
        {
            bool emprestado = false;
            if(!emprestimos.Any())
            {
                emprestimos.Add(new Emprestimo(new DateTime()));
                emprestado = true;
            } else
            {
                Emprestimo lastItem = emprestimos.Last();
                if (lastItem.DtDevolucao != DateTime.MinValue)
                {
                    emprestimos.Add(new Emprestimo(new DateTime()));
                    emprestado = true;
                }
                else if (lastItem.DtEmprestimo == DateTime.MinValue)
                {
                    lastItem.DtEmprestimo = new DateTime();
                    emprestado = true;
                }
            }
            return emprestado;
        }
        public bool devolver()
        {
            bool devolvido = false;
            Emprestimo lastItem = emprestimos.Last();
            if (lastItem.DtEmprestimo != DateTime.MinValue && lastItem.DtDevolucao == DateTime.MinValue)
            {
                lastItem.DtDevolucao = new DateTime();
                devolvido = true;
            }
            return devolvido;
        }
        public bool disponivel()
        {
            bool disponivel = false;
            if(!!emprestimos.Any())
            {
                disponivel = true;
            } else
            {
                Emprestimo lastItem = emprestimos.Last();
                if (lastItem.DtEmprestimo == DateTime.MinValue || lastItem.DtDevolucao != DateTime.MinValue)
                {
                    disponivel = true;
                }

            }
            return disponivel;
        }
        public int qtdeEmprestimo()
        {
            return emprestimos.Count;
        }
    }
}
