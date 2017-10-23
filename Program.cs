using System;
using System.IO;

namespace sistema_vendas
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu();   
            
        }
        static void Menu(){
            System.Console.WriteLine("SISTEMA DE VENDAS");
            System.Console.WriteLine("-----------------");
            string opcao ="";
            
            do{
                // Informa opções ao cliente
                    
                System.Console.WriteLine("1  -Cadastrar Cliente");
                System.Console.WriteLine("2  -Cadastrar Produto");
                System.Console.WriteLine("3  -Realizar sVendas");
                System.Console.WriteLine("5  -Extrato Cliente");
                System.Console.WriteLine("9  -Sair");
                //Recebe opção do Usuário
                opcao = Console.ReadLine();
                switch (opcao){
                    case "1":
                        CadastrarCliente();
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


            //Cadastrar novo Cliente
            static void CadastrarCliente(){                
                string cpf="";
                string cnpj="";
                string[] dados = new string[3];             
                
                System.Console.WriteLine("Digite o nome completo do cliente:");
                string nomeCli = Console.ReadLine();
                
                System.Console.WriteLine("Digite o email do cliente");
                string emailCli = Console.ReadLine();                            

                System.Console.WriteLine("Digite a opção:");
                System.Console.WriteLine("Opção [1] : Pessoa Fisica");
                System.Console.WriteLine("Opção [2] : Pessoa Juridica");

                string opcao = Console.ReadLine();
                //Validação do CPF
                switch (opcao){
                    case "1":
                        bool cpfValido = false;                        
                        do{
                            System.Console.WriteLine("Digite o CPF: ");
                            cpf = Console.ReadLine();
                            cpfValido = validaCpf(cpf);
                            if (cpfValido == false){
                                System.Console.WriteLine("Cpf Inválido!");
                            }                          
                        }while(cpfValido != true);                                           
                        System.Console.WriteLine("Gravar dados Pessoa Física");  
                        DadosPf(nomeCli,emailCli,cpf);
                        break;                                           
                    
                    case "2":
                        //Validação do CNPJ
                        bool cnpjValido = false;                        
                        do{
                            System.Console.WriteLine("Digite o Cnpj");
                            cnpj = Console.ReadLine();
                            cnpjValido = validaCnpj(cnpj);
                            if (cnpjValido == false){
                                System.Console.WriteLine("Cnpj Invalido!");
                            }                            
                        } while (cnpjValido != true);                          
                        System.Console.WriteLine("Gravar dados Pessoa Juridica.");
                        DadosPj(nomeCli,emailCli,cnpj);
                    break;                   
                }

            }

            //Cadastrar novo Produto
            static void CadastrarProduto(){
                string codProd = "";
                string nomeProd = "";
                string descriProd = "";
                string precoProd = "";

                System.Console.WriteLine("Digite o código do produto:");
                codProd = Console.ReadLine();
                
                System.Console.WriteLine("Digite o nome do produto: ");
                nomeProd = Console.ReadLine();

                System.Console.WriteLine("Digite a descrição do produto: ");
                descriProd =  Console.ReadLine();

                System.Console.WriteLine("Digtei o preço do produto: ");
                precoProd = Console.ReadLine();
                
                //Gravar dadosProd
                DadosProd(codProd,nomeProd,descriProd,precoProd); 
            }

            //Realizar Venda
            static void RealizarVenda(){
                string cpf = "";
                string cnpj = "";
                string opcao = "";
                //string value = "";

                System.Console.WriteLine("Realizar venda. ");
                System.Console.WriteLine("Pesquisar CPF ou CNPJ");
                System.Console.WriteLine("Digite [1] Pesquisar CPF : [2] Pesquisar CNPJ");
                opcao = Console.ReadLine();               
                switch (opcao){
                    //valida cpf inválido
                    case "1":
                        bool cpfValido = false;                        
                        do{                            
                            System.Console.WriteLine("Digite o CPF: ");
                            cpf = Console.ReadLine();
                            cpfValido = validaCpf(cpf);
                            if (cpfValido == false){
                                System.Console.WriteLine("Cpf Inválido!");
                                Menu();
                            }                          
                        }while(cpfValido != true);
                        if (cpfValido == true){
                            //DadosPf();
                        }
                        break;  
                    
                    case "2" :
                    //Validação cnpj inválido
                        bool cnpjValido = false;                        
                        do{                            
                            System.Console.WriteLine("Digite o CNPJ: ");
                            cnpj = Console.ReadLine();
                            cnpjValido = validaCnpj(cnpj);
                            if (cnpjValido == false){
                                System.Console.WriteLine("Cnpj Invalido!");
                                Menu();
                            }                            
                        } while (cnpjValido != true);                          
                    break;
                    //Exibir dados cliente
                    
                }                   
            }

            //Extrato Cliente
            static void ExtratoCliente(){
                
            }

            //Método para VALIDAR CPF
           static bool validaCpf(string cpf){               
               //criação dos vetores da multiplicação
               int[] mult1 = new int[9]{10,9,8,7,6,5,4,3,2};
               int[] mult2 = new int[10]{11,10,9,8,7,6,5,4,3,2};

               string tempCpf = "";
               string digito = "";

               int soma = 0;
               int resto = 0;

               //armazenar em tempCpf apenas os números antes do digito
               tempCpf = cpf.Substring(0,9);
               //guardar em soma o resultado da multiplicação dos digitos do cpf com o peso dado ao vetor mult1
                for (int i = 0; i < 9; i++){
                    soma += int.Parse(tempCpf[i].ToString()) * mult1[i];
                }
                //guardar em resto o RESTO da divisão do que tem em soma / 11 caracteres
                resto = soma % 11;
                //checar se resto ficou com valor menor que 2, se sim o primeiro digito do cpf será 0(zero)
                if (resto < 2){
                    resto = 0;
                }
                else{
                    resto = 11 - resto; // se não for, o que estiver em resto subtraia por 11
                }
                //armazenar em digito o 1º digito que pegamos
                digito = resto.ToString();                

                //Pegar o segundo digito
                tempCpf = tempCpf + digito;

                //zerar a variável soma novamente
                 soma = 0;

                //guardar em soma o resultado da multiplicação dos digitos do cpf com o peso dado ao vetor mult2
                for (int i = 0; i <10; i++){
                    soma += int.Parse(tempCpf[i].ToString()) * mult2[i];
                }
                //Guardar em resto, o RESTO da divisão de soma / 11 caracteres
                resto = soma % 11;

                //checar se resto ficou com valor menor que 2, se sim o segundo digito do cpf será 0(zero)
                if (resto < 2){
                    resto = 0;
                }
                else{
                    resto = 11 - resto; // se não for, o que estiver em resto subtraia por 11
                }
                //armazenar em digito o 2º digito que pegamos
                digito = resto.ToString();

                //checar o cpf e comparar com digito
                if (cpf.EndsWith(digito)==true){
                    System.Console.WriteLine("Cpf Válido!");

                    return true;
                } 
                return false;       

            }  

             //Método para VALIDAR CNPJ
           static bool validaCnpj(string cnpj){
              // bool cnpjValido = false;
               //criação dos vetores da multiplicação
               int[] mult1 = new int[12]{5,4,3,2,9,8,7,6,5,4,3,2};
               int[] mult2 = new int[13]{6,5,4,3,2,9,8,7,6,5,4,3,2};

               string tempCnpj = "";
               string digito = "";

               int soma = 0;
               int resto = 0;

               //armazenar em tempCnpj apenas os números antes do digito
               tempCnpj = cnpj.Substring(0,12);
               //guardar em soma o resultado da multiplicação dos digitos do cpf com o peso dado ao vetor mult1
                for (int i = 0; i < 12; i++){
                    soma += int.Parse(tempCnpj[i].ToString()) * mult1[i];
                }
                //guardar em resto o RESTO da divisão do que tem em soma / 11 caracteres
                resto = soma % 11;
                //checar se resto ficou com valor menor que 2, se sim o primeiro digito do cpf será 0(zero)
                if (resto < 2){
                    resto = 0;
                }
                else{
                    resto = 11 - resto; // se não for, o que estiver em resto subtraia por 11
                }
                //armazenar em digito o 1º digito que pegamos
                digito = resto.ToString();                

                //Pegar o segundo digito
                tempCnpj = tempCnpj + digito;

                //zerar a variável soma novamente
                 soma = 0;

                //guardar em soma o resultado da multiplicação dos digitos do cpf com o peso dado ao vetor mult2
                for (int i = 0; i <13; i++){
                    soma += int.Parse(tempCnpj[i].ToString()) * mult2[i];
                }
                //Guardar em resto, o RESTO da divisão de soma / 11 caracteres
                resto = soma % 11;

                //checar se resto ficou com valor menor que 2, se sim o segundo digito do cpf será 0(zero)
                if (resto < 2){
                    resto = 0;
                }
                else{
                    resto = 11 - resto; // se não for, o que estiver em resto subtraia por 11
                }
                //armazenar em digito o 2º digito que pegamos
                digito = resto.ToString();

                //checar o cpf e comparar com digito
                if (cnpj.EndsWith(digito)==true){
                    System.Console.WriteLine("Cnpj Válido!");

                    return true;
                } 
                return false;       

            }   

            //Grava dados PF
            static void DadosPf(string nomeCli,string emailCli,string cpf){
            //string dadoTemp = "";
            string[]dado = new string[]{nomeCli,emailCli,cpf};            
                bool arquivoExiste = File.Exists("cadClientePF.txt");
                StreamWriter sw = new StreamWriter (@"C:\Users\Sandro Reis\Desktop\sistema_vendas\cadClientePF.txt");                                              
                for (int i = 0; i < dado.Length; i++)
                {
                    sw.Write(dado[i] + ";");                                
                      
                               
                 }                   
                sw.Close(); 
                DateTime data_hora;
                data_hora = DateTime.Now;
                data_hora.ToLongDateString();
                Console.WriteLine("Cadastro PF realizado com sucesso! ");
                System.Console.WriteLine(data_hora);
            }     

            //Grava dados PJ
            static void DadosPj(string nomeCli,string emailCli,string cnpj){
            string[]dado = new string[]{nomeCli,emailCli,cnpj};            
            bool arquivoExiste = File.Exists("cadClientePJ.txt");
            StreamWriter sw = new StreamWriter (@"C:\Users\Sandro Reis\Desktop\sistema_vendas\cadClientePJ.txt");                                  
            for (int i = 0; i < dado.Length; i++)
            {
                sw.Write(dado[i] + ";");
                
            } 
            DateTime data_hora;
            data_hora = DateTime.Now;
            data_hora.ToLongDateString();
            Console.WriteLine("Cadastro PJ com sucesso! ");
            System.Console.WriteLine(data_hora);   
            sw.Close();
                           
            }  

            //função gravar dados produto
            static void DadosProd(string codProd,string nomeProd,string descriProd,string precoProd){
            string[]dado = new string[]{codProd,nomeProd,descriProd,precoProd};                        
            bool arquivoExiste = File.Exists("cadProduto2.txt");
            if(arquivoExiste == true){
                StreamWriter sw = new StreamWriter (@"C:\Users\Sandro Reis\Desktop\vendas\cadProduto.txt");                                  
                for (int i = 0; i < dado.Length; i++)
                {
                    sw.Write(dado[i] + ";");               
                                
                 }                  
                 sw.Close();
            }
            else{
                System.Console.WriteLine("Arquivo não encontrado!");
                Menu();
            }
            
        }
        

    }
}
