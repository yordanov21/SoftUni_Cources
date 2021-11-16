using AutoMapper;
using ProductShop.DTO.Product;
using ProductShop.DTO.User;
using ProductShop.Models;
using System.Linq;

namespace ProductShop
{
    public class ProductShopProfile : Profile
    {
        public ProductShopProfile()
        {
            //configuration for mapper problem 5
            this.CreateMap<Product, ListProductsInRangeDTO>()
                .ForMember(x => x.SellerName, y => y.MapFrom(x => x.Seller.FirstName + ' ' + x.Seller.LastName));

            //configuration for mapper problem 6
            //the internal DTO
            this.CreateMap<Product, UserSoldProductDTO>()
                .ForMember(x => x.BuyerFirstName, y => y.MapFrom(x => x.Buyer.FirstName))
                .ForMember(x => x.BuyerLastName, y => y.MapFrom(x => x.Buyer.LastName));
            //the external DTO
            this.CreateMap<User, UserWithSoldProductDTO>()
                .ForMember(x => x.SoldProducts, y => y.MapFrom(x => x.ProductsSold.Where(p=>p.Buyer!=null)));
        }
    }
}
