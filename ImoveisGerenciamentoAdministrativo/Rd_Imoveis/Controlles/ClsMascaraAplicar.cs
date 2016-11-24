using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// usando forms
using System.Windows.Forms;

namespace GerenciandoeAdministramdoNFc.Controllers
{
    class ClsMascaraAplicar
    {
        //ATRIBUTOS--------
        private char _tecla { get; set; }
        private string _palavra{ get; set; }
        private Int32 _fator = 1;
        //METODOS PRIVATE--
        private void RetiraCaractere(char carac,char carac2)
        {   //retirando caractere da string
            string[] campos = _palavra.Split(carac,carac2);
            _palavra = Convert.ToDouble(string.Concat(campos)).ToString(CultureInfo.InvariantCulture);
        }

        
        private void RetiraCaractere(char carac)
        {   //retirando caractere da string
            string[] campos = _palavra.Split(carac);
            _palavra = Convert.ToDouble(string.Concat(campos)).ToString(CultureInfo.InvariantCulture);
        }

        private void AcrescentaZeros(int normal, int backspace)
        {   //acrescentado zeros a string
            while ((_palavra.Length < normal) || ((_palavra.Length < backspace) && (_tecla == (char)Keys.Back)))
            {
                _palavra = "0" + _palavra;
            }
        }
        private void RetornaFator()
        {   //compara se backspace
            if (_tecla == (char)Keys.Back)
                _fator = 3;
        }

        public void LimpaCaracteres(char simbolo, char simbolo2, int min, int max)
        {
            //chama funcao para retirada de caracter e insercao de zeros
            RetiraCaractere(simbolo,simbolo2);
            AcrescentaZeros(min, max);
            RetornaFator();
        }


        public void LimpaNumero(char simbolo, int min, int max)
        {   //chama funcao para retirada de caracter e insercao de zeros
            RetiraCaractere(simbolo);
            AcrescentaZeros(min, max);
            RetornaFator();
        }

        //funcao recebe quantidade de parter do numero, inicio e quantidade de caracteres de cada parte dentro da string, caracter e efetua qualquer tipo de mascara.
        private void MascaraQualquer(Int32 quantidade, string[,] limites)
        {
            string partes = "";
            Int32 contador = 0;
            while (contador < quantidade)
            {
                partes += _palavra.Substring(Convert.ToInt32(limites[contador, 0]), Convert.ToInt32(limites[contador, 1])) + limites[contador, 2];
                contador = contador + 1;
                //partes;
            }
            _palavra = partes;
        }
        //METODODS PUBLICOS----
        public void RecebeTecla(char x)
        {
            _tecla = x;
        }
        public void RecebePalavra(string y)
        {
            _palavra = y;
        }
        //metodo recebe caracter e retorna falso se numero
        public bool MascaraNumero(Int32 maximo)
        {

           // if (!char.IsDigit(e.KeyChar) || !char.IsNumber(e.KeyChar))


            if ((!char.IsDigit(_tecla) || !char.IsNumber(_tecla) || (_palavra.Length < maximo && Convert.ToInt32(_palavra.Substring(0, 1)) != 0)) && (_tecla != (char) Keys.Back))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //aplica a mascara no formato 00000-0000
        //aplica a mascara no formato 000000000
        public string MascaraFone()
        {
            //private Int32 _fator2 = 2;
            LimpaNumero('-', 8, 10);
            string[,] partes = { { "0", "5", "-" }, { "5", Convert.ToString(2 + _fator), "" } }; 
            MascaraQualquer(2, partes);
            return _palavra;
        }

        //aplica a mascara no formato (000)
        //aplica a mascara no formato 000
        //public string MascaraFoneArea()
        //{
        //    //private Int32 _fator2 = 2;
        //    LimpaCaracteres('(',')', 2, 4);
        //    string[,] partes = { { "0", "0", "(" }, { "0", Convert.ToString(1 + _fator), "" }, { "5", "1", ")" } };
        //    MascaraQualquer(3, partes);
        //    return _palavra;
        //}


        //aplica a mascara no formato 00000-000
        //aplica a mascara no formato 00000000
        public string MascaraCep()
        {
            LimpaNumero( '-' , 7, 9);
            string[,] partes = { { "0", "5", "-" }, { "5", Convert.ToString(1 + _fator), "" } };
            MascaraQualquer(2, partes);
            return _palavra;
        }

//        		partescnpj += _cnpj.Substring(0, 2)+".";
//		partescnpj += _cnpj.Substring(2, 3)+".";
//		partescnpj += _cnpj.Substring(5, 3)+"/";
//		partescnpj += _cnpj.Substring(8, 4)+"-";
//		partescnpj += _cnpj.Substring(12, 2);
        //aplica a mascara no formato 00.000.000/0000-00
        //                            012.345.678/9012-34567   
        //aplica a mascara no formato 00000000000000
        public string MascaraCnpj()
        {


            LimpaNumerocnpj('.', '/', '-', 13, 15);
            string[,] partes = { { "0", "2", "." }, { "2", "3", "." }, { "5", "3", "/" }, { "8", "4", "-" }, { "12", Convert.ToString(_fator), "" } };
            MascaraQualquer(5, partes);
            return _palavra;
        }

        private void LimpaNumerocnpj(char simbolo, char simbolo1, char simbolo2, int min, int max)
        {
            RetiraCaractereCnpj(simbolo,simbolo1,simbolo2);
            AcrescentaZeros(min, max);
            RetornaFator();
        }

        private void RetiraCaractereCnpj(char simbolo, char simbolo1, char simbolo2)
        {
            string[] campos = _palavra.Split(simbolo, simbolo1, simbolo2);
            _palavra = Convert.ToDouble(string.Concat(campos)).ToString(CultureInfo.InvariantCulture);
        }

//      partescpf += _cpf.Substring(0, 3)+".";
//		partescpf += _cpf.Substring(3, 3)+".";
//		partescpf += _cpf.Substring(6, 3)+"-";
//		partescpf += _cpf.Substring(9, 2);

        //aplica a mascara no formato 000.000.000-00
        //aplica a mascara no formato 00000000000
        internal string MascaraCpf()
        {
            LimpaNumerocnpj('.', '/', '-', 10, 12);
            string[,] partes = { { "0", "3", "." }, { "3", "3", "." }, { "6", "3", "-" }, { "9", Convert.ToString(_fator), "" } };
            MascaraQualquer(4, partes);
            return _palavra;
        }

//		partes += _palavra.Substring(0, 2)+"/";
//		partes += _palavra.Substring(2, 2)+"/";
//		partes += _palavra.Substring(4, 4);

        //aplica a mascara no formato 00/00/0000
        //aplica a mascara no formato 00000000

        internal string MascaraDtAniversario()
        {
            //private Int32 _fator2 = 2;
            LimpaNumero('/', 7, 9);
            string[,] partes = { { "0", "2", "/" }, { "2", "2", "/" }, { "4", Convert.ToString(2 + _fator), "" } };  // 2 + quantidade de caracteres apos o / ou -
            MascaraQualquer(3, partes);
            return _palavra;
        }


    
    
    
    }
}
