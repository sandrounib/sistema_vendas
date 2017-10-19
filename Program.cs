using System;

namespace sistema_vendas
{
    class Program
    {
        static void Main(string[] args)
        {
            
            System.Console.WriteLine("MENU DE OPÇÕES");
            System.Console.WriteLine("==============");
            string opcao ="";
            do{
                System.Console.WriteLine("Digite a opção: ");
                System.Console.WriteLine("1 - Cadastrar Cliente");
                System.Console.WriteLine("2 - Cadastrar Produto");
                System.Console.WriteLine("3 - Cadastrar Venda");
                System.Console.WriteLine("4 - Extrato Clente");
                System.Console.WriteLine("9 - SAIR");

                //recebe opção do cliente
                opcao = Console.ReadLine();
                switch(opcao){
                        case "1":
                        CadastrarCliente();                         
                        string cpf ="";
                       bool cpfValido = ValidarCpf(cpf);
                            break;
                        case "2":
                        CadastrarProduto();
                            break;
                        case "3":
                        RealizarVenda();
                            break;
                        case "4":
                        ExtratoCliente();
                            break;                                                
                }
                
            }while(opcao != "9");
        }
        //Metodo Cadastrar Cliente
        static void CadastrarCliente(){         
    
        }
        //Metodo Cadastrar Produto
        static void CadastrarProduto(){

        }

        //Metodo realizar Venda
        static void RealizarVenda(){

        }

        //Método ExtratoCliente
        static void ExtratoCliente(){

        }
        static bool ValidarCpf(string cpf){
            bool cpfValido = false;
            System.Console.WriteLine("Digite seu CPF: ");
            cpf = Console.ReadLine();
            cpf.Trim();//remover espaços em branco
            cpf = cpf.Replace(".","").Replace("-","");//se tiver .(ponto) ou traços substitua por espaço em branco

            //checar (SE) o (TAMANHO) cpf digitado é # de 11 digitos
            if(cpf.Length != 11){
                System.Console.WriteLine("CPF INVÁLIDO!");          

            }
            else{
                //criação dos vetores da multiplicação
                int[] mult1 = new int[9] {10,9,8,7,6,5,4,3,2};
                int[] mult2 = new int[10] {11,10,9,8,7,6,5,4,3,2};

                //criação das strings tempCpf e digito
                string tempCpf, digito;
                
                //criação das variáveis soma e resto já com valores zerados
                int soma = 0, resto = 0;

                //Armazenar em tempCpf apenas 9 digitos da variavel cpf
                tempCpf = cpf.Substring(0,9);// Começa da posição 0 e pega só 9 digitos do CPF
                
                //Fazer um laço e guardar em soma, a multiplicação os digitos do CPF digitado pelo peso dado ao vetor mult1
                for (int i = 0; i < 9; i++){
                   soma += int.Parse(tempCpf[i].ToString()) * mult1[i];                                            
                }
                //Guardar em resto, o RESTO da divisão de soma / 11
                resto = soma % 11;
                
                // checar SE resto ficou com valor menor que 2 se sim o primeiro digito será 0 (zero)
                if (resto < 2){
                    resto = 0;
                }
                else{
                    resto = 11 - resto;  // se não for; O que tiver em resto subtraia por 11
                }

                //armazenar o primeiro digito que pegamos na variável digito
                digito = resto.ToString();

                //Pegar o segundo digito
                tempCpf = tempCpf + digito;
                
                //Zerar variável soma
                soma = 0;
                //Fazer um laço para multiplicar os digitos do CPF digitado pelo peso dado ao vetor mult2, e armazenar em soma
                for (int i = 0; i < 10; i++){
                    soma += int.Parse(tempCpf[i].ToString()) * mult2[i];
                }
                //Guardar em resto, o RESTO da divisão de soma / 11
                resto = soma % 11;

                 // checar SE resto ficou com valor menor que 2 se sim o primeiro digito será 0 (zero)
                if (resto < 2){
                    resto = 0;
                }
                else{
                    resto = 11 - resto;  // se não for; O que tiver em resto subtraia por 11
                }

                //armazenar em digito o valor de resto
                digito = digito + resto;

                //Checar o cpf e comparar com digito
                if(cpf.EndsWith(digito)== true){
                    System.Console.WriteLine("CPF VÁLIDO!");
                    return cpfValido = true;
                }
                else{
                    System.Console.WriteLine("CPF INVÁLIDO");
                    return cpfValido = false;
                }                
            } 
            return cpfValido;         
            
        }

    }
}
