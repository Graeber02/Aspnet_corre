﻿using App.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Interfaces.Application
{
    public interface IPessoaService
    {
        Pessoa BuscaPorId(Guid id);
        List<Pessoa> listaPessoas();
        void Salvar(Pessoa Obj);
        Pessoa BuscaNome(string Nome);
        void RemoverId(Guid id);
    }
}
