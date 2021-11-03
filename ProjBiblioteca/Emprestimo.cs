using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjBiblioteca
{
    class Emprestimo
    {
        private DateTime dtEmprestimo;
        private DateTime dtDevolucao;

        public DateTime DtEmprestimo { get => dtEmprestimo; set => dtEmprestimo = value; }
        public DateTime DtDevolucao { get => dtDevolucao; set => dtDevolucao = value; }

        public Emprestimo(DateTime dtEmprestimo, DateTime dtDevolucao)
        {
            this.DtEmprestimo = dtEmprestimo;
            this.DtDevolucao = dtDevolucao;
        }
        public Emprestimo(DateTime dtEmprestimo)
        {
            this.DtEmprestimo = dtEmprestimo;
        }

        public Emprestimo() { }
    }
}
