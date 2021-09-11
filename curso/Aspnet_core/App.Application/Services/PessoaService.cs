using App.Domain.Entities;
using App.Domain.Interfaces.Application;
using App.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Application.Services
{
    public class PessoaService : IPessoaService
    {
        private IRepositoryBase<Pessoa> _repository { get; set; }
        public PessoaService(IRepositoryBase<Pessoa> repository)
        {
            _repository = repository;
        }
        public Pessoa BuscaPorId(Guid id)
        {
            var obj = _repository.Query(x => x.Id == id).FirstOrDefault();
            return obj;
        }

        public List<Pessoa> listaPessoas()
        {
            //return _repository.Query(x => 1 == 1).ToList(). //traz uma lista somente com as pessoas
            //nas linhas a seguir traz uma lista das pessoas maias a cidade das mesmas
            return _repository.Query(x => 1 == 1)
                .Select(p => new Pessoa
                {
                    Id = p.Id,
                    Nome = p.Nome,
                    Peso = p.Peso,
                    Cidade = new Cidade
                    {
                        Nome = p.Cidade.Nome,
                        UF = p.Cidade.UF
                    }
                }).ToList();
        }

        public void Salvar(Pessoa obj)
        {
            if (String.IsNullOrEmpty(obj.Nome))
            {
                throw new Exception("Informe o nome");
            }
            _repository.Save(obj);
            _repository.SaveChanges();
        }

        public Pessoa BuscaNome(string nome)
        {
            var obj = _repository.Query(x => x.Nome == nome).FirstOrDefault();
            return obj;
        }

        public void RemoverId(Guid id)
        {
            if (id == Guid.Empty)
            {
                throw new Exception("Informe o Codigo");
            }
            _repository.Delete(id);
            _repository.SaveChanges();
        }
    }
   
}
