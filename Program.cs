
using System;
using System.Collections.Generic;


namespace CadastroClientes
{
    class Program
    {

        static List<Cliente> clientes = new List<Cliente>();

        static void Main(string[] args)
        {
            bool executando = true;

            /* Uma variável executando é criada e definida como true para manter um loop infinito até que usuário escolha sair */
            while (executando)
            {
                /* Um menu de opções é exibido para usuário */
                Console.WriteLine("Selecione uma opção: ");
                Console.WriteLine("1 - Adicionar cliente");
                Console.WriteLine("2 - Visulizar clientes");
                Console.WriteLine("3 - Editar cliente ");
                Console.WriteLine("4 - Excluir cliente ");
                Console.WriteLine("5 - Sair");

                int opcao = Convert.ToInt32(Console.ReadLine());
                
                /* A escolha do usuário é tratada por um switch case, que chama dos métodos */
                switch (opcao)
                {
                    case 1:
                        AdicionarCliente();
                        break;
                    case 2:
                        VisualizarCliente();
                        break;
                    case 3:
                        EditarCliente();
                        break;
                    case 4:
                        ExcluirCliente();
                        break;
                    case 5:
                        executando = false;
                        break;
                    default:
                        Console.WriteLine("Opção inválida");
                        break;
                }
            }

        }
        
        /* Solicita ao usuário o nome e o e-mail do cliente */
        static void AdicionarCliente()
        {
            Console.WriteLine("Digite o nome do cliente: ");
            string nome = Console.ReadLine() ?? string.Empty;

            Console.WriteLine("Digite o e-email do cliente: ");
            string email = Console.ReadLine() ?? string.Empty;

            Cliente cliente = new Cliente(nome, email);
            clientes.Add(cliente);

            Console.WriteLine("Cliente adicionado com sucesso.");
        }

        /* Exibi todos  os cliente cadastrado  */
        static void VisualizarCliente()
        {   
            /* Percorre todos os dados com Foreach */
            foreach(Cliente cliente in clientes)
            {
                Console.WriteLine($"Nome: {cliente.Nome}");
                Console.WriteLine($"E-mail: {cliente.Email}");
                Console.WriteLine("-----------------");
            }
        }

        static void EditarCliente() 
        {
            Console.WriteLine("Digite o nome do cliente que deseja editar: ");
            string nome = Console.ReadLine() ?? string.Empty;

            Cliente? cliente = clientes.Find(c => c.Nome == nome)!;

            if (cliente != null)
            {
                Console.WriteLine("Digite o novo nome do cliente");
                string novoNome = Console.ReadLine() ?? string.Empty;

                Console.WriteLine("Digite o novo email do cliente");
                string novoEmail = Console.ReadLine() ?? string.Empty;

                cliente.Nome = novoNome;
                cliente.Email = novoEmail;

                Console.WriteLine("Cliente editado com sucesso.");
            }
            else
            {
                Console.WriteLine("Cliente nao encontrado.");
            }
        }

        static void ExcluirCliente()
        {
            Console.WriteLine("Digite o nome do cliente que deseja excluir: ");
            string nome = Console.ReadLine() ?? string.Empty;

            Cliente cliente = clientes.Find(c => c.Nome == nome)!;

            if(cliente != null)
            {
                clientes.Remove(cliente);
                Console.WriteLine("Cliente excluido com sucesso.");
            }
            else
            {
                Console.WriteLine("Cliente nao encotrado.");
            }
        }
    }
  class Cliente
  {
    public string Nome { get; set; }
    public string Email { get; set; }
        public Cliente(string nome, string email)
    {
        Nome = nome;
        Email = email;
    }
  }
}
