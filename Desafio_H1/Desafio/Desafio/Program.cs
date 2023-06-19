﻿
using Desafio;

bool sair = false;

        IntegracaoProdutoAPI integracaoProdutoAPI =
                     new IntegracaoProdutoAPI("http://localhost:3000/produtos");

        while (!sair)
        {
            Console.WriteLine("Menu Principal");
            Console.WriteLine("1 – Cadastrar Produto");
            Console.WriteLine("2 – Atualizar Produto");
            Console.WriteLine("3 – Remover Produto");
            Console.WriteLine("4 – Listar Produtos");
            Console.WriteLine("5 – Exportar para CSV");
            Console.WriteLine("6 – Sair");

            Console.Write("Escolha uma opção: ");
            string opcao = Console.ReadLine();

            switch (opcao)
            {
                case "1":
                    Console.WriteLine("Opção selecionada: Cadastrar Produto");
                    Cad_Produto novoProduto = new Cad_Produto();
                    novoProduto.nome = Console.ReadLine();
                    Console.WriteLine("Digite a descrição:");
                    novoProduto.descricao = Console.ReadLine();
                    Console.WriteLine("Digite o preço:");
                    novoProduto.preco = Console.ReadLine();


                   await integracaoProdutoAPI.CadastrarProduto(novoProduto);



                    break;

                case "2":
                    Console.WriteLine("Opção selecionada: Atualizar Produto");
                    // Lógica para atualizar o produto
//                    await integracaoProdutoAPI.CadastrarProduto(novoProduto);


                    break;

                case "3":
                    Console.WriteLine("Opção selecionada: Remover Produto");
                    // Lógica para remover o produto
                    break;

                case "4":
                    Console.WriteLine("Opção selecionada: Listar Produtos");
                    List<Cad_Produto> listagemProdutos = new List<Cad_Produto>();

                    // Lógica para listar os produtos
                    break;

                case "5":
                    Console.WriteLine("Opção selecionada: Exportar para CSV");
                    List<Cad_Produto> listaProdutosExportar = new List<Cad_Produto>();

                    // Lógica para exportar os produtos para um arquivo CSV
                    break;

                case "6":
                    Console.WriteLine("Opção selecionada: Sair");
                    sair = true;
                    break;

                default:
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    break;
            }

            Console.WriteLine();
        }
  
