using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaAtendimentoRestaurante
{
    class FilaGenerica<T>
    {
        static FilaGenerica<int> filaPedidos;
        static FilaGenerica<int> filaPagamentos;
        static FilaGenerica<int> filaEncomendas;
        static int codigoCliente;

        private T[] vet;
        private int inicio;
        private int fim;

        public FilaGenerica(int tam)
        {
            vet = new T[tam + 1];
            inicio = fim = 0;
        }

        public void enfileirar(T i)
        {
            vet[fim] = i;
            fim = (fim + 1) % vet.Length;
        }

        public T desenfileirar()
        {
            T item;
            item = vet[inicio];
            inicio = (inicio + 1) % vet.Length;
            return item;
        }

        public bool vazia()
        {
            return inicio == fim;
        }

        public bool cheia()
        {
            return ((fim + 1) % vet.Length) == inicio;
        }
    }
}
