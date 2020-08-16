using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EntityFrameworkBasic.Data;
using EntityFrameworkBasic.Models.Entities;
using EntityFrameworkBasic.Services;

namespace EntityFrameworkBasic
{
    class Program
    {
        static async Task Main(string[] args)
        {

            try
            {
                using(AppDbContext dbContext = new AppDbContext())
                {
                    #region Instantiate Services

                        ProductService productService = new ProductService(dbContext);
                        CategoryService categoryService = new CategoryService(dbContext);
                        
                    #endregion

                    #region Create

                        Category category1 = new Category("Jogos");
                        Product product1 = new Product(new Guid(), "Prod Teste", "Descrição teste", 9.99m, DateTime.Now, category1);

                        //await categoryService.InsertAsync(category1);
                        await productService.InsertAsync(product1);

                    #endregion

                    #region Update

                        Product productToUpdate = dbContext.Product.FirstOrDefault(x => x.Name == "Prod Teste");

                        if(productToUpdate != null)
                        {
                            System.Console.WriteLine("Digite o novo preço para o produto ["+productToUpdate.Name+"]:");
                            decimal newPrice = Decimal.Parse(Console.ReadLine());
                            newPrice = Math.Round(newPrice, 2);

                            productToUpdate.Price = newPrice;
                            await productService.UpdateAsync(productToUpdate);
                        }
                        else
                        {
                            System.Console.WriteLine("Nenhum produto encontrado com os criterios informados");
                            throw new NullReferenceException("Product not found");
                        }

                        
                        
                    #endregion

                    #region Delete

                        Product productToDelete = dbContext.Product.FirstOrDefault(x => x.Name == "Prod Teste");

                        if(productToUpdate != null)
                        {
                            await productService.DeleteAsync(productToUpdate);
                        }
                        else
                        {
                            System.Console.WriteLine("Nenhum produto encontrado com os criterios informados");
                            throw new NullReferenceException("Product not found");
                        }

                        
                        
                    #endregion
                    
                    #region Read All

                        var allProducts = await productService.GetAllAsync();
                        
                        System.Console.WriteLine("Todos os produtos");
                        System.Console.WriteLine("");

                        foreach(Product p in allProducts)
                        {
                            Console.WriteLine(p);
                        }

                    #endregion
                    
                    #region Search

                        Console.WriteLine("Insira o nome do produto para buscar: ");
                        string buscarNome = Console.ReadLine();

                        List<Product> productsFound = dbContext.Product.Where(x => x.Name.Contains(buscarNome)).ToList();

                        if(productsFound.Count <= 0)
                        {
                            System.Console.WriteLine("Nenhum produto encontrado com os criterios informados");
                        }

                        System.Console.WriteLine("Produtos encontrados");
                        foreach(Product pf in productsFound)
                        {
                            Console.WriteLine(pf);
                        }

                    #endregion

                }
            }
            catch(Exception e)
            {
                System.Console.WriteLine("An Exception Ocurred");
                System.Console.WriteLine($"Type: {e.GetType()}");
                System.Console.WriteLine($"Message: {e.Message}");
            }
            

            
        }
    }

    #region Basic Commands for VS Code

        // dotnet add package MySql.Data.EntityFrameworkCore - provedor do banco
        // dotnet add package Microsoft.EntityFrameworkCore.Tools - ferramentas
        // dotnet add package Microsoft.EntityFrameworkCore.Design - habilita comandos dotnet ef (migrations, etc)

        // dotnet ef migrations add InitialCreate - cria migration
        // dotnet ef database update - atualiza o banco

    #endregion
}
