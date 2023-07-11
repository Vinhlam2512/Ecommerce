using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BusinessObject.Models;

namespace DataAccess.Interface {
    public interface ICartRepository : IRepository<Cart, int> {
        public List<Cart> GetCartByUid(int id);
		public Cart IsCartExistByUid(int id, int uid);
		public Cart DeleteCart(int id, int uid);
	}
}
