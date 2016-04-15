using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace zapweb.Models
{
    public class CondominioRules : zapweb.Lib.Mvc.BusinessLogic
    {

        public Condominio Adicionar(Condominio condominio)
        {
            if (!zapweb.Lib.Session.GetInstance().Account.Permissao.Has("ADD_CONDOMINIO"))
            {
                this.MessageError = "USUARIO_SEM_PERMISSAO";
                return null;
            }

            EnderecoRepositorio.Insert(condominio.Endereco);

            ContatoRepositorio.Insert(condominio.Sindico);
            ContatoRepositorio.Insert(condominio.Zelador);
            
            CondominioRepositorio.Insert(condominio);

            return condominio;
        }

        public bool Update(Condominio condominio) {            
            if (!zapweb.Lib.Session.GetInstance().Account.Permissao.Has("UPDATE_CONDOMINIO"))
            {
                this.MessageError = "USUARIO_SEM_PERMISSAO";
                return false;
            }

            var currentCondominio = CondominioRepositorio.FetchOne(condominio.Id);            
            var unidade = UnidadeRepositorio.FetchOne(currentCondominio.UnidadeId);
            var unidadeDoCurrent = UnidadeRepositorio.FetchOne(zapweb.Lib.Session.GetInstance().Account.Usuario.Unidade.Id);

            if (!unidade.IsInTreeView(unidadeDoCurrent))
            {
                this.MessageError = "USUARIO_SEM_PERMISSAO";
                return false;
            }
            
            ContatoRepositorio.Update(condominio.Sindico);
            ContatoRepositorio.Update(condominio.Zelador);
            EnderecoRepositorio.Update(condominio.Endereco);

            CondominioRepositorio.Update(condominio);

            return true;
        }

        public Condominio Get(int Id)
        {
            if (!zapweb.Lib.Session.GetInstance().Account.Permissao.Has("UPDATE_CONDOMINIO"))
            {
                this.MessageError = "USUARIO_SEM_PERMISSAO";
                return null;
            }

            var unidadeDoCurrent = UnidadeRepositorio.FetchOne(zapweb.Lib.Session.GetInstance().Account.Usuario.Unidade.Id);
            var condominio = CondominioRepositorio.FetchOne(Id);
            condominio.Unidade = UnidadeRepositorio.FetchOne(condominio.UnidadeId);
            condominio.Endereco = EnderecoRepositorio.FetchOne(condominio.EnderecoId);
            condominio.Sindico = ContatoRepositorio.FetchOne(condominio.SindicoId);
            condominio.Zelador = ContatoRepositorio.FetchOne(condominio.ZeladorId);
            condominio.Administradora = AdministradoraRepositorio.FetchOne(condominio.AdministradoraId);
            
            if (!condominio.Unidade.IsInTreeView(unidadeDoCurrent))
            {
                this.MessageError = "USUARIO_SEM_PERMISSAO";
                return null;
            }

            return condominio;

        }

        public List<Condominio> Search(CondominioSearch param)
        {
            var unidade = UnidadeRepositorio.FetchOne(zapweb.Lib.Session.GetInstance().Account.Usuario.Unidade.Id);

            return CondominioRepositorio.Fetch(param, unidade);
        }

        public List<Condominio> Imprimir(string ids)
        {            
            var list = ids.Split(',');
            var intList = new List<int>();

            foreach (var item in list)
            {
                intList.Add(int.Parse(item));
            }

            var condominios = CondominioRepositorio.Fetch(intList);
            foreach (var condominio in condominios)
            {
                condominio.Unidade = UnidadeRepositorio.FetchOne(condominio.UnidadeId);
                condominio.Endereco = EnderecoRepositorio.FetchOne(condominio.EnderecoId);
                condominio.Sindico = ContatoRepositorio.FetchOne(condominio.SindicoId);
                condominio.Zelador = ContatoRepositorio.FetchOne(condominio.ZeladorId);
                condominio.Administradora = AdministradoraRepositorio.FetchOne(condominio.AdministradoraId);
            }

            return condominios;
        }

    }
}