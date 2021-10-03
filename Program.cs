using System;
using System.Collections.Generic;

namespace DIO.POO01
{
    class Program
    {
        static List<Conta> listaContas = new List<Conta>(); //List(t), mas com Contas

        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

            while(opcaoUsuario.ToUpper() != "X"){
                switch (opcaoUsuario){
                    case "1":
                        ListarContas();
                        break;
                    case "2":
                        InserirConta();
                        break;
                    case "3":
                        Transferir();
                        break;
                    case "4":
                        Sacar();
                        break;
                    case "5":
                        Depositar();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                opcaoUsuario = ObterOpcaoUsuario();
            }
            Console.WriteLine("Obrigado por utilizar nossos serviços");
        }

        public static void ListarContas()
        {
            Console.WriteLine();
            Console.WriteLine("+========================================================================+");
            Console.WriteLine("|---------------------------Contas Listadas------------------------------|");
            Console.WriteLine("+========================================================================+");

            if(listaContas.Count == 0){
                Console.WriteLine("|------------------------Nenhuma conta cadastrada------------------------|");
                Console.WriteLine("+========================================================================+");
                Console.WriteLine();
                return;
            }

            for(int i = 0; i < listaContas.Count; i++){
                Conta conta = listaContas[i];
                Console.Write("#{0} - ", i);
                Console.WriteLine(conta);
            }

            Console.WriteLine("+========================================================================+");
            Console.WriteLine();
        }

        private static void InserirConta()
        {
            Console.WriteLine();
            Console.WriteLine("+========================================+");
            Console.WriteLine("|-----------Inserir nova conta-----------|");
            Console.WriteLine("+========================================+");
            Console.WriteLine("|---1. Conta física----------------------|");
            Console.WriteLine("|---2. Conta juridica--------------------|");
            Console.WriteLine("+========================================+");
            Console.WriteLine();

            int entradaTipoConta = int.Parse(Console.ReadLine());

            Console.WriteLine();
            Console.WriteLine("+========================================+");
            Console.WriteLine("|---Digite o nome do cliente-------------|");
            Console.WriteLine("+========================================+");
            Console.WriteLine();

            string entradaNome = Console.ReadLine();

            Console.WriteLine();
            Console.WriteLine("+========================================+");
            Console.WriteLine("|---Digite o saldo inicial---------------|");
            Console.WriteLine("+========================================+");
            Console.WriteLine();

            double entradaSaldo = double.Parse(Console.ReadLine());

            Console.WriteLine();
            Console.WriteLine("+========================================+");
            Console.WriteLine("|---Digite o crédito---------------------|");
            Console.WriteLine("+========================================+");
            Console.WriteLine();

            double entradaCredito = double.Parse(Console.ReadLine());

            Conta novaConta = new Conta(tipoConta: (TipoConta)entradaTipoConta,
                                                    saldo: entradaSaldo,
                                                    credito: entradaCredito,
                                                    nome: entradaNome); //Criando um novo objeto
            
            listaContas.Add(novaConta); //Está adicionando mais contas na lista da linha 8
        }

        private static void Transferir()
        {
            Console.WriteLine();
            Console.WriteLine("+========================================+");
            Console.WriteLine("|---Digite o número da conta de origem---|");
            Console.WriteLine("+========================================+");
            Console.WriteLine();

            int indiceContaOrigem = int.Parse(Console.ReadLine());

            Console.WriteLine();
            Console.WriteLine("+========================================+");
            Console.WriteLine("|---Digite o número da conta de destino--|");
            Console.WriteLine("+========================================+");
            Console.WriteLine();

            int indiceContaDestino = int.Parse(Console.ReadLine());

            Console.WriteLine();
            Console.WriteLine("+========================================+");
            Console.WriteLine("|---Digite o valor a ser transferido-----|");
            Console.WriteLine("+========================================+");
            Console.WriteLine();

            double valorTransferencia = double.Parse(Console.ReadLine());
            listaContas[indiceContaOrigem].Transferir(valorTransferencia, listaContas[indiceContaDestino]);
        }

        private static void Sacar()
        {
            Console.WriteLine();
            Console.WriteLine("+========================================+");
            Console.WriteLine("|---Digite o número da conta-------------|");
            Console.WriteLine("+========================================+");
            Console.WriteLine();

            int indiceConta = int.Parse(Console.ReadLine());

            Console.WriteLine();
            Console.WriteLine("+========================================+");
            Console.WriteLine("|---Digite o valor a ser sacado----------|");
            Console.WriteLine("+========================================+");
            Console.WriteLine();

            double valorSaque = double.Parse(Console.ReadLine());
            Console.WriteLine();
            listaContas[indiceConta].Sacar(valorSaque); //.Sacar retorna o Sacar do Conta.cs
        }

        private static void Depositar()
        {
            Console.WriteLine();
            Console.WriteLine("+========================================+");
            Console.WriteLine("|---Digite o número da conta-------------|");
            Console.WriteLine("+========================================+");
            Console.WriteLine();

            int indiceConta = int.Parse(Console.ReadLine());

            Console.WriteLine();
            Console.WriteLine("+========================================+");
            Console.WriteLine("|---Digite o valor a ser depositado------|");
            Console.WriteLine("+========================================+");
            Console.WriteLine();

            double valorDeposito = double.Parse(Console.ReadLine());
            Console.WriteLine();
            listaContas[indiceConta].Depositar(valorDeposito);
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("+========================================+");
            Console.WriteLine("|-----DIO Bank - A seu dispor senhor-----|");
            Console.WriteLine("|--------Informe a opção desejada--------|");
            Console.WriteLine("+========================================+");
            Console.WriteLine("|---1. Listar contas---------------------|");
            Console.WriteLine("|---2. Inserir nova conta----------------|");
            Console.WriteLine("|---3. Transferir------------------------|");
            Console.WriteLine("|---4. Sacar-----------------------------|");
            Console.WriteLine("|---5. Depositar-------------------------|");
            Console.WriteLine("|---C. Limpar tela-----------------------|");
            Console.WriteLine("|---X. Sair------------------------------|");
            Console.WriteLine("+========================================+");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            //Console.WriteLine();
            return opcaoUsuario;
        }
    }
}