using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//usar entity
using System.Data.Entity;
using GerenciandoeAdministramdoNFc.Controllers;

namespace Rd_Imoveis.Models.Usuarios
{
    class Usuarios
    {
        private string key = "xdhBS9ySRLuIQ7bn94MVP9QEiKM84WQXltdCMu6Ogu0="; //Está chave você mesmo é quem escolhe.


        public int ID { get; set; }
        public string Nome { get; set; }

        private Controllers.Criptografia _crip;
       
        private string _senha;
        public string Senhacripto
        {
            get
            {
                return _senha;
            }
            set
            {
                _crip = new Criptografia(CryptProvider.DES);
                _crip.Key = key;
                _senha = _crip.Encrypt(value);
            }
        }

        private string _senhaDescripto;
        public string SenhaDescripto
        {
            get
            {
                //_senha += @" a ";
                return _senhaDescripto;
            }
            set
            {
                _crip = new Criptografia(CryptProvider.DES);
                _crip.Key = key;
                _senhaDescripto = _crip.Decrypt(value);
            }
        }


        
        public string Senhaconfirma { get; set; }
        public string Nivelacesso { get; set; }
        public DateTime DataCadastro { get; set; }


        //public class UsuarioDBContext : DbContext
        //{
        //    public DbSet<Movie> Movies { get; set; }
        //}







    }
}
