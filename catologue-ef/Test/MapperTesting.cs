using catologue_ef.newEntities;
using Models;
using BusinessLogic;

namespace Test
{
    public class Tests
    {
        [TestFixture]
        public class MapperTests
        {
            [Test]
            public void Model2EF_P_WithValidProductModel_ReturnsMappedProductEntity()
            {
                // Arrange
                var productModel = new Product_m
                {
                    // Set properties for productModel
                };

                // Act
                var result = Mapper.Model2EF_P(productModel);

                // Assert
                Assert.IsNotNull(result);
                Assert.AreEqual(productModel.ProductId, result.ProductId);
                Assert.AreEqual(productModel.ProductBrand, result.ProductBrand);
                Assert.AreEqual(productModel.ProductName, result.ProductName);
                Assert.AreEqual(productModel.ProductPrice, result.ProductPrice);
                Assert.AreEqual(productModel.ProductQuantity, result.ProductQuantity);
                Assert.AreEqual(productModel.CategoryId, result.CategoryId);
            }

            [Test]
            public void EF2Model_P_WithValidProductEntity_ReturnsMappedProductModel()
            {
                // Arrange
                var productEntity = new Product
                {
                    // Set properties for productEntity
                };

                // Act
                var result = Mapper.EF2Model_P(productEntity);

                // Assert
                Assert.IsNotNull(result);
                Assert.AreEqual(productEntity.ProductId, result.ProductId);
                Assert.AreEqual(productEntity.ProductBrand, result.ProductBrand);
                Assert.AreEqual(productEntity.ProductName, result.ProductName);
                Assert.AreEqual(productEntity.ProductPrice, result.ProductPrice);
                Assert.AreEqual(productEntity.ProductQuantity, result.ProductQuantity);
                Assert.AreEqual(productEntity.CategoryId, result.CategoryId);
            }

            [Test]
            public void Model2EF_C_WithValidCategoryModel_ReturnsMappedCategoryEntity()
            {
                // Arrange
                var categoryModel = new Category_m
                {
                    // Set properties for categoryModel
                };

                // Act
                var result = Mapper.Model2EF_C(categoryModel);

                // Assert
                Assert.IsNotNull(result);
                Assert.AreEqual(categoryModel.CategoryId, result.CategoryId);
                Assert.AreEqual(categoryModel.CategoryName, result.CategoryName);
                Assert.AreEqual(categoryModel.CategoryDescription, result.CategoryDescription);
                Assert.AreEqual(categoryModel.CategoryProductCount, result.CategoryProductCount);
            }

            [Test]
            public void EF2Model_C_WithValidCategoryEntity_ReturnsMappedCategoryModel()
            {
                // Arrange
                var categoryEntity = new Category
                {
                    // Set properties for categoryEntity
                };

                // Act
                var result = Mapper.EF2Model_C(categoryEntity);

                // Assert
                Assert.IsNotNull(result);
                Assert.AreEqual(categoryEntity.CategoryId, result.CategoryId);
                Assert.AreEqual(categoryEntity.CategoryName, result.CategoryName);
                Assert.AreEqual(categoryEntity.CategoryDescription, result.CategoryDescription);
                Assert.AreEqual(categoryEntity.CategoryProductCount, result.CategoryProductCount);
            }

            [Test]
            public void EF2Model_PS_WithValidProductSpecEntity_ReturnsMappedProductSpecModel()
            {
                // Arrange
                var productSpecEntity = new ProductSpec
                {
                    // Set properties for productSpecEntity
                };

                // Act
                var result = Mapper.EF2Model_PS(productSpecEntity);

                // Assert
                Assert.IsNotNull(result);
                Assert.AreEqual(productSpecEntity.ProductId, result.ProductId);
                Assert.AreEqual(productSpecEntity.SpecId, result.SpecId);
                Assert.AreEqual(productSpecEntity.SpecName, result.SpecName);
                Assert.AreEqual(productSpecEntity.Value, result.Value);
            }

            [Test]
            public void Model2EF_PS_WithValidProductSpecModel_ReturnsMappedProductSpecEntity()
            {
                // Arrange
                var productSpecModel = new ProductSpec_m
                {
                    // Set properties for productSpecModel
                };

                // Act
                var result = Mapper.Model2EF_PS(productSpecModel);

                // Assert
                Assert.IsNotNull(result);
                Assert.AreEqual(productSpecModel.ProductId, result.ProductId);
                Assert.AreEqual(productSpecModel.SpecId, result.SpecId);
                Assert.AreEqual(productSpecModel.SpecName, result.SpecName);
                Assert.AreEqual(productSpecModel.Value, result.Value);
            }
        }

    }
}