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
                System.Console.WriteLine("1 - Cadastrar Clente");
                System.Console.WriteLine("2 - Cadastrar Produto");
                System.Console.WriteLine("3 - Cadastrar Venda");
                System.Console.WriteLine("4 - Extrato Clente");
                System.Console.WriteLine("9 - SAIR");

                //recebe opção do cliente
                opcao = Console.ReadLine();
                switch(opcao){
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
        //Metodo Cadastrar Cliente
        static void CadastrarCliente(){
            string nomeCompletoCliente;
            string emailCliente;
            string opcao

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

    }
}
