using System;
using System.IO;

namespace ListaDeCompras
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string path = @"C:\Users\admin\Downloads\C#\ListaDeCompras\";
            string fileName = "lista_de_compras.txt";
            string filePath = path + fileName;

            List<string> shoppingList = new List<string>();

            if (File.Exists(filePath))
            {
                shoppingList.AddRange(File.ReadAllLines(filePath));
            }

            while (true)
            {
                Console.WriteLine("\n<--- Lista de Compras --->");
                Console.WriteLine("\nEscolha uma opção abaixo: ");
                Console.WriteLine("1. Adicionar item");
                Console.WriteLine("2. Remover item");
                Console.WriteLine("3. Listar itens");
                Console.WriteLine("4. Apagar itens da lista atual");
                Console.WriteLine("5. Sair e exportar a lista em um bloco de notas");
                Console.WriteLine("6. Apenas sair");

                switch (Console.ReadLine())
                {
                    case "1":
                        Console.Write("Digite o nome do item a ser adicionado: ");
                        string addItem = Console.ReadLine();

                        if (!string.IsNullOrEmpty(addItem))
                        {
                            shoppingList.Add(addItem);
                            Console.WriteLine($"Item {addItem} adicionado.");
                        }
                        else
                        {
                            Console.WriteLine("Item inválido. O item não pode ser vazio!");
                        }
                        break;

                    case "2":
                        Console.Write("Digite o nome do item a ser removido:");
                        string removeItem = Console.ReadLine();

                        if (shoppingList.Remove(removeItem) == true)
                        {
                            Console.WriteLine($"Item `{removeItem}` removido.");
                        }
                        else
                        {
                            Console.WriteLine($"Item `{removeItem}` não encontrado na lista. Tente digitar exatamente como aparece na lista.");
                        }

                        break;

                    case "3":
                        Console.WriteLine("Itens na lista de compras:");
                        if (shoppingList.Count == 0)
                        {
                            Console.WriteLine("A lista está vazia.");
                        }
                        else
                        {
                            for (int i = 0; i < shoppingList.Count; i++)
                            {
                                Console.WriteLine($"{i + 1}. {shoppingList[i]}");
                            }
                        }
                        break;

                    case "4":
                        shoppingList.Clear();
                        Console.WriteLine("Lista atual apagada.");
                        break;

                    case "5":
                        while (true)
                        {
                            Console.WriteLine("Deseja salvar a lista em um bloco de notas? (s/n)");
                            string saveChoice = Console.ReadLine().ToLower();

                            if (saveChoice == "s")
                            {
                                File.WriteAllLines(filePath, shoppingList);
                                Console.WriteLine("Lista salva com sucesso! Saindo do programa...");
                            }
                            else if (saveChoice == "n")
                            {
                                bool backMenu = false;
                                while (!backMenu)
                                {
                                    Console.WriteLine("1. Sair e encerrar o programa");
                                    Console.WriteLine("2. Voltar ao menu principal");
                                    string exitChoice = Console.ReadLine();

                                    if (exitChoice == "1")
                                    {
                                        Console.WriteLine("Lista não salva. Saindo do programa...");
                                        return;
                                    }
                                    else if (exitChoice == "2")
                                    {
                                        backMenu = true;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Opção inválida. Por favor, responda com '1' ou '2'.");
                                    }
                                }
                            }
                            else
                            {
                                Console.WriteLine("Opção inválida. Por favor, responda com 's' ou 'n'.");
                                continue;
                            }
                            break;
                        }
                        break;

                    case "6":
                        Console.WriteLine("Saindo...");
                        return;
                        
                        
                    default:
                        Console.WriteLine("Opção inválida. Tente novamente.");
                        break;
                }
            }
        }
    }
}