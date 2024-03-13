using System;

namespace SistemaAtendimentoRestaurante
{
    class Program
    {
        static FilaGenerica<int> filaPedidos; // Fila de pedidos
        static FilaGenerica<int> filaPagamentos; // Fila de pagamentos
        static FilaGenerica<int> filaEncomendas; // Fila de encomendas
        static int codigoCliente; // Código do próximo cliente a entrar na fila

        static void Main(string[] args)
        {
            filaPedidos = new FilaGenerica<int>(100); // Inicializa a fila de pedidos
            filaPagamentos = new FilaGenerica<int>(100); // Inicializa a fila de pagamentos
            filaEncomendas = new FilaGenerica<int>(100); // Inicializa a fila de encomendas
            codigoCliente = 1; // Inicializa o código do cliente

            while (true)
            {
                Console.WriteLine("----- Sistema de Atendimento Restaurante Dona Tita -----");
                Console.WriteLine("1 - Inserção de cliente na fila de pedidos");
                Console.WriteLine("2 - Remoção de cliente da fila de pedidos");
                Console.WriteLine("3 - Remoção de cliente da fila de pagamentos");
                Console.WriteLine("4 - Remoção de cliente da fila de encomendas");
                Console.WriteLine("5 - Sair");
                Console.Write("Escolha uma opção: ");
                string opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        InserirClienteFilaPedidos();
                        break;
                    case "2":
                        RemoverClienteFilaPedidos();
                        break;
                    case "3":
                        RemoverClienteFilaPagamentos();
                        break;
                    case "4":
                        RemoverClienteFilaEncomendas();
                        break;
                    case "5":
                        return;
                    default:
                        Console.WriteLine("Opção inválida!");
                        break;
                }

                Console.WriteLine();
            }
        }

        static void InserirClienteFilaPedidos()
        {
            if (!filaPedidos.cheia())
            {
                filaPedidos.enfileirar(codigoCliente);
                Console.WriteLine("Cliente " + codigoCliente + " entrou na fila de pedidos.");
                codigoCliente++;
            }
            else
            {
                Console.WriteLine("Erro: Fila de pedidos cheia!");
            }
        }

        static void RemoverClienteFilaPedidos()
        {
            if (!filaPedidos.vazia())
            {
                int cliente = filaPedidos.desenfileirar();
                Console.WriteLine("Cliente " + cliente + " foi removido da fila de pedidos.");
                filaPagamentos.enfileirar(cliente);
                Console.WriteLine("Cliente " + cliente + " entrou na fila de pagamentos.");
            }
            else
            {
                Console.WriteLine("Erro: Fila de pedidos vazia!");
            }
        }

        static void RemoverClienteFilaPagamentos()
        {
            if (!filaPagamentos.vazia())
            {
                int cliente = filaPagamentos.desenfileirar();
                Console.WriteLine("Cliente " + cliente + " foi removido da fila de pagamentos.");
                filaEncomendas.enfileirar(cliente);
                Console.WriteLine("Cliente " + cliente + " entrou na fila de encomendas.");
            }
            else
            {
                Console.WriteLine("Erro: Fila de pagamentos vazia!");
            }
        }

        static void RemoverClienteFilaEncomendas()
        {
            if (!filaEncomendas.vazia())
            {
                int cliente = filaEncomendas.desenfileirar();
                Console.WriteLine("Cliente " + cliente + " foi removido da fila de encomendas.");
                Console.WriteLine("Encomenda do cliente " + cliente + " entregue.");
            }
            else
            {
                Console.WriteLine("Erro: Fila de encomendas vazia!");
            }
        }
    }
}


