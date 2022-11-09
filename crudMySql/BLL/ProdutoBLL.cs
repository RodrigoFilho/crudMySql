﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using crudMySql.DTO;
using DAL;

namespace crudMySql.BLL
{
    class ProdutoBLL
    {
        Conexao objDAL = new Conexao();
        string tabela = "tbl_produto";
        public void InserirProduto(ProdutoDTO objProdutoDTO)
        {
            string sql = String.Format($@"insert into {tabela} values(null,
                        '{objProdutoDTO.Descricao}',
                        '{objProdutoDTO.Preco.ToString().Replace(',', '.')}',
                        '{objProdutoDTO.Quantidade}',
                        '{objProdutoDTO.Peso}',
                        '{objProdutoDTO.Tbl_categoria_id}',
                        '{objProdutoDTO.Tbl_fornecedor_id}'");
            objDAL.ExecutarComando(sql);
        }
        public void ExcluirProduto(ProdutoDTO objDTO)
        {
            string sql = $"delete from {tabela} where id = {objDTO.Id}";
            objDAL.ExecutarComando(sql);
        }
        public DataTable ListarProdutos(string condicao)
        {
            string pesquisa = $"select * from {tabela} where {condicao};";
            return objDAL.ExecutarConsulta(pesquisa);
        }
    }
}