using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Configuration;
using System.Windows.Forms;
using System.Data.Odbc;
using System.Data;
using System.Data.SqlClient;
//using FirebirdSql.Data.FirebirdClient;

namespace Rd_Imoveis.Controlles.ADO
{
    public class DaoBaseAcessoMysql
    {
        #region "DEIXAR STATICO ACESSO MYSQL"
        private static readonly DaoBaseAcessoMysql InstanciaMySql = new DaoBaseAcessoMysql(); // instancia vai dar erro...

        private DaoBaseAcessoMysql() { }    // caso acessar direto nao mostrara nada.
        #endregion

        #region "INSTANCIAR O MYSQL"
        public static DaoBaseAcessoMysql GetInstancia()    //INSTANCIAR BANCO DE DADOS....
        {
            return InstanciaMySql;
        }
        #endregion

        #region "STRING DE CONEXAO E CONFIGURACAO COM OS DADOS"
        public SqlConnection GetConexaoSql()    // string de conexao com o bando de dados pegando do arquivo config...
        {

                //                    SqlConnection oConn = new SqlConnection();
                //                    oConn.ConnectionString = @"Driver={Microsoft dBase Driver (*.dbf)};SourceType=DBF;SourceDB=c:\dados\;Exclusive=No;  _
                //                                                         Collate=Machine;NULL=NO;DELETED=NO;BACKGROUNDFETCH=NO;";


                //     string conn = @"Driver={Microsoft dBase Driver (*.dbf)};SourceType=DBF;SourceDB=c:\dados\tabela.dbf;Exclusive=No;  _
                //                                               Collate=Machine;NULL=NO;DELETED=NO;BACKGROUNDFETCH=NO;";


            string conn = ConfigurationManager.ConnectionStrings["TabelaAbcfarmaLocal.Properties.Settings.Setting"].ToString();
            //            string conn = ConfigurationManager.ConnectionStrings["TabelaAbcfarmaLocal.Properties.Settings.SettingMdb"].ToString();

            MessageBox.Show(@" Ado: " + conn);

                return new SqlConnection(conn);
        }
        #endregion

    }
}
