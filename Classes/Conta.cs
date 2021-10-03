using System; //Necessário para utilizar as funções de Console

namespace DIO.POO01
{
    public class Conta
    {
        private TipoConta TipoConta{get;set;} //O TipoConta(verde) é um Enum da classe TipoConta(verde), que diz quais valores um atributo(azul) pode receber
        private double Saldo{get;set;}
        private double Credito{get;set;}
        private string Nome{get;set;}

        public Conta(TipoConta tipoConta, double saldo, double credito, string nome) //Declaração de variáveis
        { //O atributo maiúsculo recebe o minúsculo, porque um é privado e o outro é público, logo eles são diferentes, mesmo parecendo iguais
            this.TipoConta = tipoConta;
            this.Saldo = saldo;
            this.Credito = credito;
            this.Nome = nome;
        }

        public bool Sacar(double valorSaque) //Declaração de variáveis
        {
            //Validação de saldo suficiente
            if(this.Saldo - valorSaque < (this.Credito * -1)){
                Console.WriteLine("Saldo insuficiente!");
                return false;
            }
            
            this.Saldo -= valorSaque; //X -= Y significa X = X - Y
            Console.WriteLine("Saldo atual da conta de {0} é {1}", this.Nome, this.Saldo);
            return true;
        }

        public void Depositar(double valorDeposito) //Declaração de variáveis
        {
            this.Saldo += valorDeposito;
            Console.WriteLine("Saldo atual da conta de {0} é {1}", this.Nome, this.Saldo);
        }

        public void Transferir(double valorTransferencia, Conta contaDestino) //Declaração de variáveis
        {
            if(this.Sacar(valorTransferencia)){
                contaDestino.Depositar(valorTransferencia);
            }
        }

        public override string ToString()
        {
            string retorno = "";
            retorno += "TipoConta " + this.TipoConta + " | ";
            retorno += "Nome " + this.Nome + " | ";
            retorno += "Saldo " + this.Saldo + " | ";
            retorno += "Credito " + this.Credito;
            return retorno;
        }
    }
}