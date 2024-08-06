using API_Product.Domains;
using API_Product.Interface;
using API_Product.Repository;
using Moq;

namespace api_XUnit
{
    public class ProductsTest
    {
        // Indica que o m�todo � um teste unit�rio, que ser� executado pelo framework de testes (neste caso, xUnit).
        [Fact]
        public void Get()
        {
            // Arrange: Configura o cen�rio de teste, criando uma lista de produtos e configurando o mock do reposit�rio.

            var products = new List<Products>
            {
                // Cria uma lista de objetos Products simulados para serem retornados pelo mock.
                new Products { ID = Guid.NewGuid(), Name = "Notebook Gamer", Price = 15000 },
                new Products { ID = Guid.NewGuid(), Name = "KWID 1.0", Price = 5000000 },
                new Products { ID = Guid.NewGuid(), Name = "Camiseta Off - White", Price = 2500 }
            };

            // Cria um mock do reposit�rio de produtos utilizando a biblioteca Moq.
            var mockRepository = new Mock<IProductsRepository>();

            // Configura o mock para que, quando o m�todo List() for chamado, ele retorne a lista de produtos criada acima.
            mockRepository.Setup(x => x.List()).Returns(products);

            // Act: Executa a a��o a ser testada, que neste caso � chamar o m�todo List() no reposit�rio simulado (mock).
            var result = mockRepository.Object.List();

            // Assert: Verifica se o resultado da a��o � o esperado.

            // Neste caso, verifica se a lista retornada pelo m�todo List() � igual � lista de produtos esperada.
            Assert.Equal(3, result.Count);
        }



        [Fact]
        public void Post()
        {
            // Arrange: Configura o cen�rio de teste, criando um novo produto e configurando o mock do reposit�rio.


            var newProduct = new Products { ID = Guid.NewGuid(), Name = "Smartfone", Price = 5000 };

            // Cria um mock do reposit�rio de produtos utilizando a biblioteca Moq.
            var mockRepository = new Mock<IProductsRepository>();

            // Configura o mock para que, quando o m�todo Create() for chamado com o newProduct,
            // ele seja tratado como uma opera��o v�lida (Verifiable indica que esta a��o ser� verificada).
            mockRepository.Setup(x => x.Create(newProduct)).Verifiable();

            // Act: Executa a a��o que est� sendo testada, que neste caso � chamar o m�todo Create() 

            mockRepository.Object.Create(newProduct);

            // Assert: Verifica se o m�todo Create() foi realmente chamado com o produto correto.
            // O Verify() confirma que o m�todo Create() foi chamado exatamente uma vez (Times.Once)
            // com o objeto newProduct durante a execu��o do teste.
            mockRepository.Verify(x => x.Create(newProduct), Times.Once);
        }

        [Fact]
        public void Delete()
        {
            // Arrange: Configura o cen�rio de teste, criando um identificador de produto e configurando o mock do reposit�rio.

            // Gera um novo ID �nico (GUID) para simular o ID do produto que ser� deletado.
            var productId = Guid.NewGuid();

            // Cria um mock do reposit�rio de produtos utilizando a biblioteca Moq.
            var mockRepository = new Mock<IProductsRepository>();

            // Configura o mock para que, quando o m�todo Delete() for chamado com o productId,
            // ele seja tratado como uma opera��o v�lida. Verifiable indica que esta a��o ser� verificada na fase de assert.
            mockRepository.Setup(x => x.Delete(productId)).Verifiable();

            // Act: Executa a a��o que est� sendo testada, que neste caso � chamar o m�todo Delete() 
            // no reposit�rio simulado (mock) para remover o produto com o ID fornecido.
            mockRepository.Object.Delete(productId);

            // Assert: Verifica se o m�todo Delete() foi realmente chamado com o ID correto.
            // O Verify() confirma que o m�todo Delete() foi chamado exatamente uma vez (Times.Once)
            // com o identificador productId durante a execu��o do teste.
            mockRepository.Verify(x => x.Delete(productId), Times.Once);

        }
        [Fact]

        public void Update()
        {
            // Arrange: Configura o cen�rio de teste.

            // Cria uma inst�ncia de um produto existente com um ID, nome e pre�o. 
            // Este ser� o produto que ser� atualizado.
            var existProduct = new Products { ID = Guid.NewGuid(), Name = "Tablet", Price = 5000 };

            // Cria uma inst�ncia de um novo produto que representa o estado atualizado do produto.
            // O ID deve ser o mesmo do produto existente para simular a atualiza��o correta.
            var updatedProduct = new Products
            {
                ID = existProduct.ID, // O ID do produto atualizado deve ser o mesmo do produto existente.
                Name = "Tablet Pro", // Novo nome para o produto.
                Price = 3500 // Novo pre�o para o produto.
            };

            var mockRepository = new Mock<IProductsRepository>();

            // Configura o mock para que, quando o m�todo Update() for chamado com o produto atualizado 
            // e o ID do produto existente, ele seja tratado como uma opera��o v�lida. 
            // A chamada a Update() ser� verificada posteriormente.
            mockRepository.Setup(x => x.Update(updatedProduct, existProduct.ID)).Verifiable();

            // Act: Executa a a��o que est� sendo testada.
            // Chama o m�todo Update() no reposit�rio simulado (mock) com o produto atualizado 
            // e o ID do produto existente.
            mockRepository.Object.Update(updatedProduct, existProduct.ID);

            // Assert: Verifica se o m�todo Update() foi chamado conforme o esperado.

            // Utiliza Verify() para confirmar que o m�todo Update() foi chamado exatamente uma vez 
            // com o produto atualizado e o ID do produto existente.
            // Se a chamada n�o ocorrer como esperado, o teste falhar�.
            mockRepository.Verify(x => x.Update(updatedProduct, existProduct.ID), Times.Once);
        }
    }

}
