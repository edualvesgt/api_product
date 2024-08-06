using API_Product.Domains;
using API_Product.Interface;
using API_Product.Repository;
using Moq;

namespace api_XUnit
{
    public class ProductsTest
    {
        // Indica que o método é um teste unitário, que será executado pelo framework de testes (neste caso, xUnit).
        [Fact]
        public void Get()
        {
            // Arrange: Configura o cenário de teste, criando uma lista de produtos e configurando o mock do repositório.

            var products = new List<Products>
            {
                // Cria uma lista de objetos Products simulados para serem retornados pelo mock.
                new Products { ID = Guid.NewGuid(), Name = "Notebook Gamer", Price = 15000 },
                new Products { ID = Guid.NewGuid(), Name = "KWID 1.0", Price = 5000000 },
                new Products { ID = Guid.NewGuid(), Name = "Camiseta Off - White", Price = 2500 }
            };

            // Cria um mock do repositório de produtos utilizando a biblioteca Moq.
            var mockRepository = new Mock<IProductsRepository>();

            // Configura o mock para que, quando o método List() for chamado, ele retorne a lista de produtos criada acima.
            mockRepository.Setup(x => x.List()).Returns(products);

            // Act: Executa a ação a ser testada, que neste caso é chamar o método List() no repositório simulado (mock).
            var result = mockRepository.Object.List();

            // Assert: Verifica se o resultado da ação é o esperado.

            // Neste caso, verifica se a lista retornada pelo método List() é igual à lista de produtos esperada.
            Assert.Equal(3, result.Count);
        }



        [Fact]
        public void Post()
        {
            // Arrange: Configura o cenário de teste, criando um novo produto e configurando o mock do repositório.


            var newProduct = new Products { ID = Guid.NewGuid(), Name = "Smartfone", Price = 5000 };

            // Cria um mock do repositório de produtos utilizando a biblioteca Moq.
            var mockRepository = new Mock<IProductsRepository>();

            // Configura o mock para que, quando o método Create() for chamado com o newProduct,
            // ele seja tratado como uma operação válida (Verifiable indica que esta ação será verificada).
            mockRepository.Setup(x => x.Create(newProduct)).Verifiable();

            // Act: Executa a ação que está sendo testada, que neste caso é chamar o método Create() 

            mockRepository.Object.Create(newProduct);

            // Assert: Verifica se o método Create() foi realmente chamado com o produto correto.
            // O Verify() confirma que o método Create() foi chamado exatamente uma vez (Times.Once)
            // com o objeto newProduct durante a execução do teste.
            mockRepository.Verify(x => x.Create(newProduct), Times.Once);
        }

        [Fact]
        public void Delete()
        {
            // Arrange: Configura o cenário de teste, criando um identificador de produto e configurando o mock do repositório.

            // Gera um novo ID único (GUID) para simular o ID do produto que será deletado.
            var productId = Guid.NewGuid();

            // Cria um mock do repositório de produtos utilizando a biblioteca Moq.
            var mockRepository = new Mock<IProductsRepository>();

            // Configura o mock para que, quando o método Delete() for chamado com o productId,
            // ele seja tratado como uma operação válida. Verifiable indica que esta ação será verificada na fase de assert.
            mockRepository.Setup(x => x.Delete(productId)).Verifiable();

            // Act: Executa a ação que está sendo testada, que neste caso é chamar o método Delete() 
            // no repositório simulado (mock) para remover o produto com o ID fornecido.
            mockRepository.Object.Delete(productId);

            // Assert: Verifica se o método Delete() foi realmente chamado com o ID correto.
            // O Verify() confirma que o método Delete() foi chamado exatamente uma vez (Times.Once)
            // com o identificador productId durante a execução do teste.
            mockRepository.Verify(x => x.Delete(productId), Times.Once);

        }
        [Fact]

        public void Update()
        {
            // Arrange: Configura o cenário de teste.

            // Cria uma instância de um produto existente com um ID, nome e preço. 
            // Este será o produto que será atualizado.
            var existProduct = new Products { ID = Guid.NewGuid(), Name = "Tablet", Price = 5000 };

            // Cria uma instância de um novo produto que representa o estado atualizado do produto.
            // O ID deve ser o mesmo do produto existente para simular a atualização correta.
            var updatedProduct = new Products
            {
                ID = existProduct.ID, // O ID do produto atualizado deve ser o mesmo do produto existente.
                Name = "Tablet Pro", // Novo nome para o produto.
                Price = 3500 // Novo preço para o produto.
            };

            var mockRepository = new Mock<IProductsRepository>();

            // Configura o mock para que, quando o método Update() for chamado com o produto atualizado 
            // e o ID do produto existente, ele seja tratado como uma operação válida. 
            // A chamada a Update() será verificada posteriormente.
            mockRepository.Setup(x => x.Update(updatedProduct, existProduct.ID)).Verifiable();

            // Act: Executa a ação que está sendo testada.
            // Chama o método Update() no repositório simulado (mock) com o produto atualizado 
            // e o ID do produto existente.
            mockRepository.Object.Update(updatedProduct, existProduct.ID);

            // Assert: Verifica se o método Update() foi chamado conforme o esperado.

            // Utiliza Verify() para confirmar que o método Update() foi chamado exatamente uma vez 
            // com o produto atualizado e o ID do produto existente.
            // Se a chamada não ocorrer como esperado, o teste falhará.
            mockRepository.Verify(x => x.Update(updatedProduct, existProduct.ID), Times.Once);
        }
    }

}
