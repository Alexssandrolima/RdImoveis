using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//para validar as mensagens
using System.Windows.Forms;

namespace GerenciandoeAdministramdoNFc.Controllers.Validacoes
{
    class ValidarOjetosCpfCnpjIe
    {

        //ClsClientes _dadosClsClientes;

        internal static bool ValidarCnpjObjetoDigitado(string valorCnpj)
        {
            valorCnpj = valorCnpj.Trim();
            valorCnpj = valorCnpj.Replace(".", "").Replace("-", "").Replace("/", "");
            if (valorCnpj == string.Empty)
            {
                MessageBox.Show("Por favor, preencha o campo \"CNPJ\"." + valorCnpj);
                return (false);
            }
            if (valorCnpj == "00000000000000")
            {
                MessageBox.Show("Valor de \"CNPJ\" inválido.");
                return (false);
            }

            if (valorCnpj.Length < 14)
            {
                MessageBox.Show("Por favor, preencha o campo \"CNPJ\" com 14 dígitos.");
                return (false);
            }

            if (valorCnpj.Length > 14)
            {
                MessageBox.Show("Por favor, preencha o campo \"CNPJ\" com 14 dígitos.");
                return (false);
            }
            const string checkOk = "0123456789";
            var checkStr = valorCnpj;
            var allValid = true;
            //int decPoints = 0;
            var allNum = "";
            int i;
            int j;
            for (i = 0; i < checkStr.Length; i++)
            {
                var ch = int.Parse(checkStr.Substring(i, 1));
                for (j = 0; j < checkOk.Length; j++)
                    if (ch == int.Parse(checkOk.Substring(j, 1)))
                        break;
                if (j == checkOk.Length)
                {
                    allValid = false;
                    break;
                }
                allNum += ch;
            }
            if (!allValid)
            {
                MessageBox.Show("Por favor, preencha o campo \"CNPJ\" apenas com dígitos.");
                return (false);
            }

            string cgc = valorCnpj;
            int cgc01 = Convert.ToInt16(cgc.Substring(0, 1));
            int cgc02 = Convert.ToInt16(cgc.Substring(1, 1));
            int cgc03 = Convert.ToInt16(cgc.Substring(2, 1));
            int cgc04 = Convert.ToInt16(cgc.Substring(3, 1));
            int cgc05 = Convert.ToInt16(cgc.Substring(4, 1));
            int cgc06 = Convert.ToInt16(cgc.Substring(5, 1));
            int cgc07 = Convert.ToInt16(cgc.Substring(6, 1));
            int cgc08 = Convert.ToInt16(cgc.Substring(7, 1));
            int cgc09 = Convert.ToInt16(cgc.Substring(8, 1));
            int cgc10 = Convert.ToInt16(cgc.Substring(9, 1));
            int cgc11 = Convert.ToInt16(cgc.Substring(10, 1));
            int cgc12 = Convert.ToInt16(cgc.Substring(11, 1));
            int cgc13 = Convert.ToInt16(cgc.Substring(12, 1));
            int cgc14 = Convert.ToInt16(cgc.Substring(13, 1));
            decimal aux1 = 10 * (cgc01 * 5 + cgc02 * 4 + cgc03 * 3 + cgc04 * 2 + cgc05 * 9 + cgc06 * 8 +
                       cgc07 * 7 + cgc08 * 6 + cgc09 * 5 + cgc10 * 4 + cgc11 * 3 + cgc12 * 2);
            decimal aux2 = aux1 / 11;
            decimal aux3 = Math.Floor(aux2);
            decimal aux4 = aux3 * 11;
            decimal dv1 = (aux1 - aux4);

            if (dv1 == 10)
            {
                dv1 = 0;
            }
            aux1 = 10 * (cgc01 * 6 + cgc02 * 5 + cgc03 * 4 + cgc04 * 3 + cgc05 * 2 + cgc06 * 9 +
                       cgc07 * 8 + cgc08 * 7 + cgc09 * 6 + cgc10 * 5 + cgc11 * 4 + cgc12 * 3 +
                       dv1 * 2);
            aux2 = aux1 / 11;
            aux3 = Math.Floor(aux2);
            aux4 = aux3 * 11;
            decimal dv2 = (aux1 - aux4);

            if (dv2 == 10)
            {
                dv2 = 0;
            }
            if (dv1 != cgc13 || dv2 != cgc14)
            {
                MessageBox.Show(@"Dígito verificador do campo" + "\"CNPJ\"" + @" não confere.");
                return (false);
            }
            return true;
        }

        internal static bool ValidarCpfObjetoDigitado(string valorCpf)
        {
            valorCpf = valorCpf.Trim();
            valorCpf = valorCpf.Replace(".", "").Replace("-", "").Replace("/", "");
            if (valorCpf == "")
            {
                MessageBox.Show(@"Por favor, preencha o campo " + "\"CPF\"" + @".");
                return (false);
            }
            if (valorCpf.Length != 11)
            {
                MessageBox.Show(@"Por favor, preencha o campo " + "\"CPF\"" + @" com 11 dígitos.");
                return (false);
            }
            if (valorCpf == "00000000000")
            {
                MessageBox.Show(@"Valor de " + "\"CPF\" " + @" inválido!");
                return (false);
            }
            decimal soma = 0;
            string cpf = valorCpf;
            int i;
            //int j;
            for (i = 0; i < 9; i++)
            {
                soma += int.Parse(cpf.Substring(i, 1)) * (10 - i);
            }
            decimal resto = 11 - (soma % 11);
            if (resto == 10 || resto == 11)
            {
                resto = 0;
            }
            if (resto != int.Parse(cpf.Substring(9, 1)))
            {
                MessageBox.Show("Valor de \"CPF\" inválido!");
                return (false);
            }
            soma = 0;
            for (i = 0; i < 10; i++)
            {
                soma += int.Parse(cpf.Substring(i, 1)) * (11 - i);
            }
            resto = 11 - (soma % 11);
            if (resto == 10 || resto == 11)
            {
                resto = 0;
            }
            if (resto != int.Parse(cpf.Substring(10, 1)))
            {
                MessageBox.Show("Valor de \"CPF\" inválido!");
                return (false);
            }
            return true;
        }

        internal static bool ValidarIeObjetoDigitado(string valorIe)
        {
            valorIe = valorIe.Trim();
            valorIe = valorIe.Replace(".", "").Replace("-", "").Replace("/", "");
            if (valorIe == "ISENTO")
            {
                // MessageBox.Show("Por favor, preenchido o campo com \"ISENTO\" - NF-c, ou NFC-e ");
                return (true);
            }

            if (valorIe == "123456789")
            {
                MessageBox.Show("Por favor, preencha o campo \"Inscrição Estadual\". \n ou Digite \"ISENTO\" para Emitir Nota fiscal Eletronica - NF-e, ou NFC-e ");
                return (false);
            }

            
            if (valorIe == "isento")
            {
                MessageBox.Show("Por favor, preencha com \"ISENTO\".");
                return (false);
            }
            if (valorIe == "")
            {
                MessageBox.Show("Por favor, preencha o campo \"Inscrição Estadual\". \n ou Digite \"ISENTO\" para Emitir Nota fiscal Eletronica - NF-e, ou NFC-e ");
                return (false);
            }
            //if (ValorIe.Substring(0, 2) != "16")
            //{
            //    MessageBox.Show("Valor de \"Inscrição Estadual\" inválido.");
            //    return (false);
            //}
            if (valorIe.Length < 9)
            {
                MessageBox.Show("Por favor, preencha o campo \"Inscrição Estadual\" com 9 dígitos.");
                return (false);
            }
            if (valorIe.Length > 9)
            {
                MessageBox.Show("Por favor, preencha o campo \"Inscrição Estadual\" com 9 dígitos.");
                return (false);
            }
            const string checkOK = "0123456789";
            var checkStr = valorIe;
            var allValid = true;
            //var decPoints = 0;
            var allNum = "";
            int i;
            int j;
            for (i = 0; i < checkStr.Length; i++)
            {
                var ch = int.Parse(checkStr.Substring(i, 1));
                for (j = 0; j < checkOK.Length; j++)
                    if (ch == int.Parse(checkOK.Substring(j, 1))) break;
                if (j == checkOK.Length)
                {
                    allValid = false;
                    break;
                }
                allNum += ch;
            }
            if (!allValid)
            {
                MessageBox.Show("Por favor, preencha o campo \"Inscrição Estadual\" apenas com dígitos.");
                return (false);
            }
            //Valida o digito da inscrição PB
            int[] cp = new int[9];
            j = 1;
            decimal soma = 0;
            string wCpo = valorIe;
            for (i = 0; i < 9; i++)
            {

                cp[i] = int.Parse(wCpo.Substring(i, 1));
            }
            for (i = 7; i >= 0; i--)
            {
                j = j + 1;
                soma = soma + cp[i] * j;
            }
            decimal resto = soma % 11;
            decimal dv = 0;
            decimal digitoInformado = 0;
            if (resto > 1)
            {
                dv = 11 - resto;
            }
            else
            {
                dv = 0;
            }
            // 161433073
            digitoInformado = int.Parse(wCpo.Substring(8, 1));
            digitoInformado = digitoInformado * 1;
            if (dv != digitoInformado)
            {
                MessageBox.Show(@"Dígito Verificador da Inscrição não confere");
                return (false);
            }
            return true;
        }

    }
}
