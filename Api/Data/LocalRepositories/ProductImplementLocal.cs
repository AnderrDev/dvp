using Api.Models;
using Api.Repositories.Contract;

namespace Api.Data.Repositories
{
    public class ProductImplementLocal : IProductContract
    {

        private List<ProductModel> _products = new List<ProductModel>()
        {
            new ProductModel()
            {
                Id = 1,
                NombreProducto = "Producto 1",
                ImagenProducto = "https://randompicturegenerator.com/img/dragon-generator/g859dce7b1ba7921d1848826a290c16ae4d3be697c760328b7a643cefdf660cd24703b2a63fd6a18ab33149f75dfefef3_640.png",
                Precio = 1,
                Ext = "Ext 1",
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                DeletedAt = null,
            },
            new ProductModel()
            {
                Id = 2,
                NombreProducto = "Producto 2",
                ImagenProducto = "https://randompicturegenerator.com/img/people-generator/ge3d7bd2358e348fd52b1c5edb962a9212b3f0c27ea5bb2c14835f347c939f3977e78856207d4be1bf93911e38b349d88_640.jpg",
                Precio = 2,
                Ext = "Ext 2",
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                DeletedAt = null,
            },
            new ProductModel()
            {
                Id = 3,
                NombreProducto = "Producto 3",
                ImagenProducto = "https://randompicturegenerator.com/img/dog-generator/g9d2b430c90bf10afc78e598640fec969221fc7f34596a1bc693e6e4d301f1bbc932ed5add92df5ece6cf00503a6f3a1d_640.jpg",
                Precio = 3,
                Ext = "Ext 3",
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                DeletedAt = null,
            },
            new ProductModel()
            {
                Id = 4,
                NombreProducto = "Producto 4",
                ImagenProducto = "https://pixabay.com/photos/forest-dog-canine-wolf-husky-2423921/",
                Precio = 4,
                Ext = "Ext 4",
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                DeletedAt = null,
            },
            new ProductModel()
            {
                Id = 5,
                NombreProducto = "Producto 5",
                ImagenProducto = "https://randompicturegenerator.com/img/cat-generator/g2a694d127df7b140771e9e57694b68cac2dc3d5297a7bb11d994f0ae76d0b931f8012776a6e1a13a844728fd57341840_640.jpg",
                Precio = 5,
                Ext = "Ext 5",
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                DeletedAt = null,
            },
        };

        public Task<ProductModel> Create(ProductModel product)
        {
            _products.Add(product);
            return Task.FromResult(product);
        }

        public Task<ProductModel> Read(int id)
        {
            ProductModel? product = _products.FirstOrDefault(p => p.Id == id);
            if (product != null)
            {
                return Task.FromResult(product);
            }
            return Task.FromResult<ProductModel>(null);
        }

        public Task<IEnumerable<ProductModel>> ReadAll()
        {
            return Task.FromResult(_products.AsEnumerable());
        }

        public Task<ProductModel> Update(ProductModel product, int id)
        {
            ProductModel? productToUpdate = _products.FirstOrDefault(p => p.Id == id);
            if (productToUpdate != null)
            {
                productToUpdate.NombreProducto = product.NombreProducto;
                productToUpdate.ImagenProducto = product.ImagenProducto;
                productToUpdate.Precio = product.Precio;
                productToUpdate.Ext = product.Ext;
                productToUpdate.UpdatedAt = DateTime.Now;
                return Task.FromResult(productToUpdate);
            }
            return Task.FromResult<ProductModel>(null);
        }

        public Task<bool> Delete(int id)
        {
            ProductModel? product = _products.FirstOrDefault(p => p.Id == id);
            if (product != null)
            {
                _products.Remove(product);
                return Task.FromResult(true);
            }
            return Task.FromResult(false);
        }
    }

}