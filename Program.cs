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
        //Metodo Cadastrar Cliente
        static void CadastrarCliente(){  
            string nomeCli, emailCli;
            string opcao ="";
            System.Console.WriteLine("Cadastro do Cliente ");
            System.Console.WriteLine("Entre com [1] Pessoa Física  [2] Pessoa Juridica");                        
            opcao = Console.ReadLine();
            switch (opcao){
                case "1":                
                    System.Console.WriteLine("Opção digitada :" + opcao);
                    System.Console.WriteLine("Validação do CPF");
                    string cpf ="";
                    bool cpfValido = ValidarCpf(cpf);
                break;  
                                       
                case "2":
                    System.Console.WriteLine("Opção digitada :" + opcao);
                    System.Console.WriteLine("Validação do CNPJ");
                    string cnpj ="";
                    bool cnpjValido = ValidaCnpj(cnpj);
                break;                                   
                      
                
            }while(opcao != "1" && opcao !="2"); 
            
            string[] Dados = new string [2];
            string [] variable = new string[] {"nomeCompleto","email"};

            for (int i=0 ; i < Dados.Length ; i ++)
            {
                Console.WriteLine("Digite o seu " + variable[i]);
                Dados[i] = Console.ReadLine();
            }            
            for(int i = 0 ; i < Dados.Length ; i ++)
            {
                Console.WriteLine(variable[i] + ": " + Dados[i]);
            } 

             bool arquivoExiste = File.Exists("CadCliente.txt");

            StreamWriter sw = new StreamWriter (@"C:\Users\FIC\Desktop\sistema_vendas\CadCliente.txt");                       

                for (int i = 0; i < Dados.Length; i ++)
                {

                    sw.Write(Dados[i] + ";");

                } 

                sw.WriteLine();                          
                sw.Close();                               


            Console.WriteLine("");
            DateTime data_hora;
            data_hora = DateTime.Now;
            data_hora.ToLongDateString();
            Console.WriteLine("Cadastro concluido com sucesso! ");
            System.Console.WriteLine(data_hora);                      


        }
        //Metodo Cadastrar Produto
        static void CadastrarProduto()
        {   
            string[] perguntas =  File.ReadAllLines(@"C:\Users\FIC\Desktop\sistema_vendas\CadProduto.txt");            

            string[] respostas = new string [perguntas.Length];       

            for (int i = 0; i < perguntas.Length; i ++)

            {

                Console.WriteLine("Digite o(a): " + perguntas[i]);

                respostas[i] = Console.ReadLine();            

            }       

            bool arquivoExiste = File.Exists("DadosProd.csv");

            StreamWriter sw = new StreamWriter (@"C:\Users\FIC\Desktop\sistema_vendas\DadosProd.csv");                       

                for (int i = 0; i < perguntas.Length; i ++)
                {

                    sw.Write(perguntas[i] + ":");

                } 

                sw.WriteLine();           

                for (int i = 0; i < respostas.Length; i ++)

                {

                    if (arquivoExiste)

                    {
                        sw.Write(respostas[i] + " " );
                    }                   

                } 
                sw.WriteLine();             

                sw.Close();   
                                
        }

        static void Menu(){
            System.Console.WriteLine("MENU DE OPÇÕES");
            System.Console.WriteLine("==============");
            string opcao ="";
            do{
                System.Console.WriteLine("Digite a opção: ");
                System.Console.WriteLine("1 - Cadastrar Cliente");
                System.Console.WriteLine("2 - Cadastrar Produto");
                System.Console.WriteLine("3 - Realizar Venda");
                System.Console.WriteLine("4 - Extrato Clente");
                System.Console.WriteLine("9 - SAIR");

                //recebe opção do cliente
                opcao = Console.ReadLine();
                switch(opcao){
                        case "1":
                            CadastrarCliente();                            
                            //string cnpj ="";                                                   
                            //bool cnpjValido = ValidaCnpj(cnpj);                                                                                                        
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

        //Metodo realizar Venda
        static void RealizarVenda(){
            string cpf ="";
            string cnpj ="";
            string value ="";            
            string[] linhas = File.ReadAllLines(@"C:\Users\FIC\Desktop\sistema_vendas\CadCliente.txt"); 
            string[] linhasProd = File.ReadAllLines(@"C:\Users\FIC\Desktop\sistema_vendas\CadProduto.txt");            
            System.Console.WriteLine("Realizar Venda");
            System.Console.WriteLine("Pesquisa do CPF ou CNPJ");
            System.Console.WriteLine("Digite uma Opção: ");
            System.Console.WriteLine("[1] Pesquisar CPF [2] Pesquisar CNPJ");
            value = Console.ReadLine();
            if(value == "1"){
               cpf = Console.ReadLine();
               bool cpfValido = ValidarCpf(cpf); 
               bool cpfEncontrado = false; 
               string dadosCliente = "";          
               if(cpfValido == true){  
                   System.Console.WriteLine("Exibir dados do cliente.");                     
                   foreach (string linha in linhas){
                   if(linha.Contains(cpf) == true){
                        cpfEncontrado = true;
                        dadosCliente = linha;
                        break;
                   }  

                   }
                   if(cpfEncontrado == true){
                       System.Console.WriteLine(dadosCliente);
                       
                   }else{
                       System.Console.WriteLine("Cliente não existe");
                       CadastrarCliente();

                   }

                   System.Console.WriteLine("Cadastre o cliente");                  
                   CadastrarCliente();
                   Menu();

               }else{
                   System.Console.WriteLine("CPF INVÁLIDO! Digite um CPF Valido");
                   ValidarCpf(cpf);
               }
            }
            else if (value == "2"){
                bool cnpjValido = ValidaCnpj(cnpj);
                if(cnpjValido == true){

                }else{
                    System.Console.WriteLine("CNPJ INVÁLIDO! Digite um CPF Valido");
                }
            }             
             
        }

        //Método ExtratoCliente
        static void ExtratoCliente(){

        }
        static bool ValidarCpf(string cpf){
            bool cpfValido = false;            
            System.Console.WriteLine("Digite o CPF do Cliente: ");
            cpf = Console.ReadLine();
            cpf.Trim();//remover espaços em branco
            cpf = cpf.Replace(".","").Replace("-","");//se tiver .(ponto) ou traços substitua por espaço em branco


            //checar (SE) o (TAMANHO) cpf digitado é # de 11 digitos
            if(cpf.Length != 11){
                System.Console.WriteLine("CPF INVÁLIDO!"); 
                return false;         

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
                    return true;
                }
                else{
                    System.Console.WriteLine("CPF INVÁLIDO");
                    return false;
                }                
            }                      
            
        }
        //Função para validar CNPJ
        static bool ValidaCnpj(string cnpj){
            bool cnpjValido = false;
            System.Console.WriteLine("Digite o CNPJ do Cliente: ");
            cnpj = Console.ReadLine();
            cnpj.Trim();//remover espaços em branco
            cnpj = cnpj.Replace(".","").Replace("-","");//se tiver .(ponto) ou traços substitua por espaço em branco

            //checar (SE) o (TAMANHO) cpf digitado é # de 11 digitos
            if(cnpj.Length != 14){
                System.Console.WriteLine("CNPJ INVÁLIDO!");          

            }
            else{
                //criação dos vetores da multiplicação
                int[] mult1 = new int[12] {5,4,3,2,9,8,7,6,5,4,3,2};
                int[] mult2 = new int[13] {6,5,4,3,2,9,8,7,6,5,4,3,2};

                //criação das strings tempCpf e digito
                string tempCnpj, digito;
                
                //criação das variáveis soma e resto já com valores zerados
                int soma = 0, resto = 0;

                //Armazenar em tempCpf apenas 9 digitos da variavel cpf
                tempCnpj = cnpj.Substring(0,12);// Começa da posição 0 e pega só 9 digitos do CPF
                
                //Fazer um laço e guardar em soma, a multiplicação os digitos do CPF digitado pelo peso dado ao vetor mult1
                for (int i = 0; i < 12; i++){
                   soma += int.Parse(tempCnpj[i].ToString()) * mult1[i];                                            
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
                tempCnpj = tempCnpj + digito;
                
                //Zerar variável soma
                soma = 0;
                //Fazer um laço para multiplicar os digitos do CPF digitado pelo peso dado ao vetor mult2, e armazenar em soma
                for (int i = 0; i < 13; i++){
                    soma += int.Parse(tempCnpj[i].ToString()) * mult2[i];
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
                if(cnpj.EndsWith(digito)== true){
                    System.Console.WriteLine("CNPJ VÁLIDO!");
                    return cnpjValido = true;
                }
                else{
                    System.Console.WriteLine("CNPJ INVÁLIDO");
                    return cnpjValido = false;
                }                
            }
            return cnpjValido;
        }

    }
}
